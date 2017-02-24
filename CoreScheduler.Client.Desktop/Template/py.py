import sys
import clr
from CoreScheduler.Api import *

ctx.Events.Add(EventLevel.Info, "You can just write statements...")

def main():
    ctx.Events.Add(EventLevel.Info, "Or you can use a main function!")

main()
