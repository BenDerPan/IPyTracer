import os
import sys

from System import EventHandler,EventArgs
from System import DateTime
from System.Collections.Generic import List
from IPyTracer.core.model import ModelObject

DIR_PATH = os.path.dirname(__file__)
sys.path.append(DIR_PATH)
sys.path.append(os.path.dirname(DIR_PATH))

class WatchVariable(object):
    def __init__(self,name,value):
        self.name=name
        self.value=ModelObject(value)
        self.watch_time=DateTime.Now;
    
    @property
    def Name(self):
        return self.name

    @property
    def Value(self):
        return self.value

    @property
    def WatchTime(self):
        return self.watch_time

class Tracer(object):
    def __init__(self):
        self.watch_variables=[]

    def Clear(self):
        self.watch_variables.clear()

    def Watch(self,name,obj):
        w=WatchVariable(name,obj)
        self.watch_variables.append(w)

    @property
    def WatchVariables(self):
        return self.watch_variables