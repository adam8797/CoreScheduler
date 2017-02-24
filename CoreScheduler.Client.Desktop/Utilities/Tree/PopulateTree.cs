using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoreScheduler.Api;
using CoreScheduler.Client.Desktop.Serializer;
using CoreScheduler.Server;
using CoreScheduler.Server.Database;
using CoreScheduler.Server.Options;
using CronExpressionDescriptor;
using Quartz;
using Quartz.Impl.Matchers;

namespace CoreScheduler.Client.Desktop.Utilities.Tree
{
    public static class PopulateTree
    {
        /// <summary>
        /// Builds a run tree on the specified root. A run tree is a tree with a list of all times a job has been run, with the enents that it produced
        /// </summary>
        /// <param name="root">Root node of this tree</param>
        /// <param name="runs">List of runs, binned by Run ID</param>
        public static void WithRunTree(this ITreeWrapper root, Dictionary<Guid, List<JobEvent>> runs)
        {
            root.Clear();

            foreach (var runKey in runs.Keys.OrderByDescending(x => runs[x].First().Timestamp))
            {
                var events = runs[runKey].OrderBy(x => x.RunOrder);

                var time = events.First().Timestamp;
                var n = new TreeNode(String.Format("Run at {0:G}", time));

                if (events.Any(x => x.EventLevel >= EventLevel.Error))
                {
                    n.ImageIndex = n.SelectedImageIndex = 2; // Error
                }
                else if (events.Any(x => x.EventLevel == EventLevel.Warning))
                {
                    n.ImageIndex = n.SelectedImageIndex = 4; // Success With Warnings
                }
                else
                {
                    n.ImageIndex = n.SelectedImageIndex = 3; // Success
                }

                foreach (var jobEvent in events.Where(x => x.ParentId == null || x.ParentId.Value == Guid.Empty))
                {
                    var sub = new TreeNode(jobEvent.Timestamp.ToString("h:mm:ss.fff tt") + " " + jobEvent.Message);
                    TreeUtils.SetEventLevelImageIndex(sub, jobEvent.EventLevel);
                    foreach (var l3Event in events.Where(x => x.ParentId.HasValue && x.ParentId.Value == jobEvent.Id).OrderBy(x => x.RunOrder))
                    {
                        var l3 = new TreeNode(l3Event.Timestamp.ToString("h:mm:ss.fff tt") + " " + l3Event.Message);
                        TreeUtils.SetEventLevelImageIndex(l3, l3Event.EventLevel);
                        sub.Nodes.Add(l3);
                    }
                    n.Nodes.Add(sub);
                }

                root.Nodes.Add(n);
            }
        }

        /// <summary>
        /// Builds a tree for base jobs. Lists all job types, with all jobs of that type.
        /// </summary>
        /// <remarks>
        /// This tree type will override the image list of whatever tree it is built on.
        /// It expects an image list that is made with TreeUtils.WithBaseJobTreeImageListBuilder().
        /// 
        /// To use your own image list, start a new builder with TreeUtils.WithBaseJobTreeImageListBuilder() and add what you need onto it.
        /// </remarks>
        /// <param name="root">Root node of this tree</param>
        /// <param name="addLoading">If true, for each job a child node will be added that says "Loading..."</param>
        public static void WithBaseJobTree(this IImageTreeWrapper root, bool addLoading = true)
        {
            root.Nodes.Clear();
            var imgList = TreeUtils.WithBaseJobTreeImageListBuilder(); 

            foreach (var registeredType in CoreRuntime.GetRegisteredTypes())
            {
                int index;
                imgList.WithExtensionIcon(registeredType.IconFileExtension, out index);

                root.Nodes.Add(registeredType.Guid.ToString(), registeredType.Name, index, index);
            }
            root.ImageList = imgList.Build();

            var jobKeys = CoreSchedulerProxy.GetJobKeys(GroupMatcher<JobKey>.AnyGroup());

            foreach (var jobKey in jobKeys)
            {
                var jobDetail = CoreSchedulerProxy.GetJobDetail(jobKey);
                var typeInfo = CoreRuntime.GetRegisteredType(jobDetail.JobType.GUID);
                var imgIndex = root.Nodes[typeInfo.Guid.ToString()].ImageIndex;
                var jobNode = root.Nodes[typeInfo.Guid.ToString()].Nodes.Add(jobKey.Name, jobDetail.Description, imgIndex, imgIndex);

                if (addLoading)
                    jobNode.Nodes.Add("loading", "Loading...", 999);
            }
        }

        /// <summary>
        /// Builds a tree for representing a file structure, including folders and the files themselves.
        /// </summary>
        /// <remarks>
        /// Unlike WithBaseJobTree(), this does not require a set position for some icons.
        /// If you've already built an ImageList for the tree, this will simply append its needed values
        /// </remarks>
        /// <param name="root">Root node of this tree</param>
        /// <param name="imgList">Your current image list</param>
        /// <param name="files">List of IFiles that will be added to the tree</param>
        public static void WithFileTree(this ITreeWrapper root, ImageListBuilder imgList, IList<IFile> files)
        {
            int folderIcon;
            imgList.WithStockIcon(SHStockIconId.Folder, out folderIcon);

            int dllIcon = 0;
            if (files.OfType<ReferenceAssemblyInfo>().Any())
            {
                imgList.WithExtensionIcon(".dll", out dllIcon);
            }

            if (files.OfType<Script>().Any())
                WithJobTypes(root, imgList);

            // Populate the tree with folders
            foreach (var file in files)
            {
                TreeNode baseNode = null;
                TreeNode newNode = null;
                if (file is Script)
                {
                    var script = (Script) file;
                    baseNode = root.Nodes[script.JobTypeGuid.ToString()];
                    var img = baseNode.ImageIndex;
                    newNode = new TreeNode(file.Name, img, img) {Name = file.Id.ToString()};
                }
                else if (file is ReferenceAssemblyInfo)
                {
                    var info = (ReferenceAssemblyInfo) file;
                    newNode = new TreeNode(file.Name, dllIcon, dllIcon) {Name = file.Id.ToString()};
                }



                if (!string.IsNullOrEmpty(file.TreeDirectory))
                {
                    var pathComponents = file.TreeDirectory.Split('/').Where(x => !string.IsNullOrEmpty(x)).ToArray();
                    if (baseNode == null)
                        TreeUtils.DrillAndPlaceNode(root, newNode, pathComponents, folderIcon);
                    else
                        TreeUtils.DrillAndPlaceNode(baseNode.Wrap(), newNode, pathComponents, folderIcon);
                }
                else if(newNode != null)
                {
                    if (baseNode == null)
                        root.Nodes.Add(newNode);
                    else
                        baseNode.Nodes.Add(newNode);
                }

            }

        }

        /// <summary>
        /// Builds a tree for representing a file structure, including folders and the files themselves. Creates a blank ImageListBuilder.
        /// </summary>
        /// <param name="root">Root node of this tree</param>
        /// <param name="files">List of IFiles that will be added to the tree</param>
        public static void WithFileTree(this IImageTreeWrapper root, IList<IFile> files)
        {
            // Clear old info
            root.Nodes.Clear();

            // Start building the new image list
            var imgList = ImageListBuilder.Create();

            WithFileTree(root, imgList, files);

            // Assign the image list
            root.ImageList = imgList.Build();
        }

        /// <summary>
        /// Builds a tree that lists all Job Types, but no jobs.
        /// </summary>
        /// <param name="root">Root node of this tree</param>
        public static void WithJobTypes(this IImageTreeWrapper root)
        {
            var imgList = ImageListBuilder.Create();
            WithJobTypes(root, imgList);
            root.ImageList = imgList.Build();
        }

        /// <summary>
        /// Builds a tree that lists all Job Types, but no jobs.
        /// </summary>
        /// <param name="root">Root node of this tree</param>
        /// <param name="imgList">Preexisting Image List that will be appended to.</param>
        public static void WithJobTypes(this ITreeWrapper root, ImageListBuilder imgList)
        {
            // Loop each type of job
            foreach (var registeredType in CoreRuntime.GetRegisteredTypes())
            {
                // Add the icon for the job's extension
                int index;
                imgList.WithExtensionIcon(registeredType.SourceFileExtension, out index);

                // Add the job type to the tree
                root.Nodes.Add(registeredType.Guid.ToString(), registeredType.Name, index, index);
            }
        }

        /// <summary>
        /// Builds a dependency tree that lists all dependencies for a given JobKey and JobOptions
        /// </summary>
        /// <param name="root">Root node of this tree</param>
        /// <param name="builder">Image List builder to append images to</param>
        /// <param name="jobKey"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static async Task WithJobDependencyTreeAsync(this IImageTreeWrapper root, JobKey jobKey, JobOptions options)
        {
            var img = ImageListBuilder.Create();
            await WithJobDependencyTreeAsync(root, img, jobKey, options);
            root.ImageList = img.Build();
        }

        /// <summary>
        /// Builds a dependency tree that lists all dependencies for a given JobKey and JobOptions
        /// </summary>
        /// <param name="root">Root node of this tree</param>
        /// <param name="builder">Image List builder to append images to</param>
        /// <param name="jobKey"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static async Task WithJobDependencyTreeAsync(this ITreeWrapper root, ImageListBuilder builder, JobKey jobKey, JobOptions options)
        {
            int[] imgs = new int[6];

            builder
                .WithDllIcon(239, "shell32.dll", out imgs[0]) // clock
                .WithExtensionIcon(".cs", out imgs[1])
                .WithExtensionIcon(".dll", out imgs[2])
                .WithExtensionIcon(".sql", out imgs[3])
                .WithStockIcon(SHStockIconId.Lock, out imgs[4]) // Lock
                .WithStockIcon(SHStockIconId.Key, out imgs[5]);// Key

            var database = new DatabaseContext();

            var triggerNode = root.Nodes.Add("Triggers", "Triggers", imgs[0], imgs[0]);

            foreach (var trigger in CoreSchedulerProxy.GetTriggersOfJob(jobKey))
            {
                triggerNode.Nodes.Add(trigger.Key.Name,
                    CronExpressionDescriptor.ExpressionDescriptor.GetDescription(
                        ((ICronTrigger)trigger).CronExpressionString));
            }

            if (options is ScriptJobOptions)
            {
                var scriptNode = root.Nodes.Add("Scripts", "Scripts", imgs[1], imgs[1]);

                var files = new List<IFile>();
                var sjo = (ScriptJobOptions)options;

                // Load Scripts
                foreach (var scriptId in sjo.ScriptReferences)
                {
                    files.Add(await database.Scripts.FindAsync(new Guid(scriptId)));
                }

                // Build Script Tree
                scriptNode.Wrap().WithFileTree(builder, files);
                scriptNode.Wrap().Prune(1);

                files.Clear();

                var dllNode = root.Nodes.Add("Assemblies", "Assemblies", imgs[2], imgs[2]);

                // Load Assemblies
                foreach (var dll in sjo.DllReferences)
                {
                    var asmInfo = await database.AssemblyInfo.FindAsync(new Guid(dll));

                    files.Add(asmInfo);
                }

                // Build Assembly Tree
                dllNode.Wrap().WithFileTree(builder, files);

                // Add Credentials
                var credentialNode = root.Nodes.Add("Credentials", "Credentials", imgs[4], imgs[4]);
                foreach (var credId in sjo.Context.Credentials)
                {
                    var cred = await database.Credentials.FindAsync(new Guid(credId));
                    if (cred == null)
                        continue;

                    credentialNode.Nodes.Add(credId, cred.Name + " (" + cred.Username + ")", imgs[5], imgs[5]);
                }

                var connNode = root.Nodes.Add("Connection Strings", "Connection Strings", imgs[3], imgs[3]);
                foreach (var connId in sjo.Context.ConnectionStrings)
                {
                    var conn = await database.ConnectionStrings.FindAsync(new Guid(connId));
                    if (conn == null)
                        continue;

                    connNode.Nodes.Add(connId, conn.Name, imgs[3], imgs[3]);
                }
            }
        }

        public static void WithJobDependencyBundleTree(this IImageTreeWrapper root, JobDependencyBundle bundle)
        {
            var img = ImageListBuilder.Create();
            root.WithJobDependencyBundleTree(bundle, img);
            root.ImageList = img.Build();
        }



        /// <summary>
        /// Builds a dependency tree that lists all dependencies for a given JobKey and JobOptions
        /// </summary>
        /// <param name="root">Root node of this tree</param>
        /// <param name="builder">Image List builder to append images to</param>
        /// <param name="jobKey"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static void WithJobDependencyBundleTree(this ITreeWrapper root, JobDependencyBundle bundle, ImageListBuilder builder)
        {
            int[] imgs = new int[9];

            builder
                .WithDllIcon(294, "shell32.dll")
                .WithDllIcon(239, "shell32.dll", out imgs[0]) // clock
                .WithExtensionIcon(".cs", out imgs[1])
                .WithExtensionIcon(".dll", out imgs[2])
                .WithExtensionIcon(".sql", out imgs[3])
                .WithStockIcon(SHStockIconId.Lock, out imgs[4]) // Lock
                .WithStockIcon(SHStockIconId.Key, out imgs[5]) // Key
                .WithStockIcon(SHStockIconId.Folder, out imgs[6]) // Folder
                .WithStockIcon(SHStockIconId.Run, out imgs[7]) // Run
                .WithStockIcon(SHStockIconId.ZipFile, out imgs[8]); // Zip File

            var jobsNode = root.Nodes.Add("Jobs", "Jobs", imgs[7], imgs[7]);

            foreach (var serializedJob in bundle.Jobs)
            {
                var jobNode = jobsNode.Nodes.Add(serializedJob.Name, serializedJob.Name, imgs[7], imgs[7]);
                
                var triggerNode = jobNode.Nodes.Add("Triggers", "Triggers", imgs[0], imgs[0]);

                foreach (var trigger in serializedJob.Triggers)
                {
                    var tn = triggerNode.Nodes.Add(trigger.Name, trigger.Name + ": " + ExpressionDescriptor.GetDescription(trigger.Cron), imgs[0], imgs[0]);
                    tn.Nodes.Add("cron", "Cron: " + trigger.Cron);
                    tn.Nodes.Add("missfire", "Missfire Instruction: " + trigger.Missfire);
                    tn.Nodes.Add("startdate", "Start Date: " + trigger.StartTime.ToLocalTime().ToString("G"));
                }

                var jobDependencies = jobNode.Nodes.Add("dependencies", "Dependencies", imgs[8], imgs[8]);

                if (serializedJob.Dependencies.OfType<ConnectionString>().Any())
                {
                    var node = jobDependencies.Nodes.Add("connectionstrings", "Connection Strings", imgs[3], imgs[3]);
                    foreach (var connectionString in serializedJob.Dependencies.OfType<ConnectionString>())
                    {
                        node.Wrap().BundleConnectionString(imgs[3], connectionString);
                    }
                }

                if (serializedJob.Dependencies.OfType<Credential>().Any())
                {
                    var node = jobDependencies.Nodes.Add("credentials", "Credentials", imgs[4], imgs[4]);
                    foreach (var credential in serializedJob.Dependencies.OfType<Credential>())
                    {
                        node.Wrap().BundleCredential(imgs[5], credential);
                    }
                }

                if (serializedJob.Dependencies.OfType<Script>().Any())
                {
                    var node = jobDependencies.Nodes.Add("scripts", "Scripts", imgs[1], imgs[1]);
                    foreach (var script in serializedJob.Dependencies.OfType<Script>())
                    {
                        node.Wrap().BundleScript(builder, script);
                    }
                }

                if (serializedJob.Dependencies.OfType<ReferenceAssemblyInfo>().Any())
                {
                    var node = jobDependencies.Nodes.Add("assembly", "Assemblies", imgs[2], imgs[2]);
                    bundle.JoinAssemblies();
                    foreach (var assembly in serializedJob.Dependencies.OfType<ReferenceAssemblyInfo>())
                    {
                        node.Wrap().BundleAssembly(imgs[2], assembly);

                    }
                }
            }

            var dependencies = root.Nodes.Add("Dependencies", "Dependencies", imgs[8], imgs[8]);

            var connectionNode = dependencies.Nodes.Add("connectionStrings", "Connection Strings", imgs[3], imgs[3]);
            foreach (var connectionString in bundle.ConnectionStrings)
            {
                connectionNode.Wrap().BundleConnectionString(imgs[3], connectionString);
            }

            var credentialsNode = dependencies.Nodes.Add("credentials", "Credentials", imgs[4], imgs[4]);
            foreach (var credential in bundle.Credentials)
            {
                credentialsNode.Wrap().BundleCredential(imgs[5], credential);
            }

            var scriptsNode = dependencies.Nodes.Add("scripts", "Scripts", imgs[1], imgs[1]);
            foreach (var script in bundle.Scripts)
            {
                scriptsNode.Wrap().BundleScript(builder, script);
            }

            var assembliesNode = dependencies.Nodes.Add("assemblies", "Assemblies", imgs[2], imgs[2]);
            foreach (var assembly in bundle.JoinAssemblies())
            {
                assembliesNode.Wrap().BundleAssembly(imgs[2], assembly);
            }
        }
    }
}
