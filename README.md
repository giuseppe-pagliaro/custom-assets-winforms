# Custom Assets For Winforms
Adds a series of useful controls to Winforms.
Before starting, make sure you download the **dlls** that correspond to the controls you want to use and their respective **dependencies**. To make sure you have everything, use the **diagram** below.

![Dependency Diagram]()

## Item Datas
If a control **handles data** in any way, it's going to do that through the **Commons::ItemDatas** class. To make your own data type that's compatible with this framework, simply extend said class and add your own fields.

'''cs
public class DataExample : ItemDatas
    {
        public DataExample() : base()
        {
            Value = "";
        }

        public String Value { get; set; }
    }
'''

## Styles
Every component that can be visualized has a style property that accepts an instance of the **Commons::Style** class. And their appearance can be controlled by simply updating said property.

Furthermore, some **static methods** are provided to control the look of some **default Winforms controls**. Simply provide your control and your style and it'll wrap it up nicely for you.
