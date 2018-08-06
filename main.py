from IPyTracer.core.model import ModelObject

class Man:
    def __init__(self,name,age):
        self.name=name
        self.age=age

if __name__=="__main__":
    m=Man("BenDerPan",27)
    model=ModelObject(m)
    print(model)
    input(">")