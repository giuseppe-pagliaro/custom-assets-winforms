# Custom Assets Winforms

This is an old version of Hermo UI Assets and is no longer mantained.

Adds a series of controls to Winforms that will help you create your **REST client**.
Before starting, please download the **NuGet Packages** that contain the controls you want to use and their respective **dependencies**. To make sure you have everything, use the **diagram** below.

![Dependency Diagram](https://github.com/giuseppe-pagliaro/custom-assets-for-winforms/blob/main/.github/DependancyDiagram.jpg)

## Item Datas
If a control **handles data**, in any way, it's going to do that through the `Commons::ItemDatas` class. To make your own data type that's compatible with this framework, simply extend said class and add your own fields.

```csharp
public class DataExample : ItemDatas
    {
        public DataExample() : base()
        {
            Value = "";
        }

        public String Value { get; set; }
    }
```

## Styles
Every component that can be visualized has a style property that accepts an instance of the `Commons::Style` class. And their appearance can be controlled by simply updating said property.

Furthermore, some **static methods** are provided to modify the look of some **default Winforms controls**. Simply provide your control and your style and it'll wrap it up nicely for you.

You can create all your style instances as **static readonly fields** and store them in a class named something like "Styles".

```csharp
public static class Styles
    {
        public static readonly Style LIGHT_MODE = new(
            SystemColors.Control,
            SystemColors.ControlDark,
            "Segoe UI",
            SystemColors.ControlText,
            Color.Teal,
            SystemColors.ControlDark,
            "Segoe UI",
            SystemColors.ControlText,
            Color.Teal,
            FlatStyle.Standard
            );

        public static readonly Style DARK_MODE = new(
            Color.FromArgb(255, 30, 30, 30),
            Color.FromArgb(255, 51, 51, 51),
            "Segoe UI",
            SystemColors.HighlightText,
            Color.Teal,
            Color.FromArgb(255, 51, 51, 51),
            "Segoe UI",
            SystemColors.HighlightText,
            Color.Teal,
            FlatStyle.Standard
            );
    }
```

This way, changing the appearance of a control is as easy as typing somethis like `control.Style = Styles.DARK_MODE`.

(Or `control.Style = Styles.LIGHT_MODE` if you're a maniac!)

## Rest Client
This framework also provides a nicer way to make **http** or **https** requests. First of all, you'll need to create an instance of the `RestClient::CustomEndpoint` class.

```csharp
public static class Endpoints
    {
        static Endpoints()
        {
            UnisSearchResult[] SearchUnisTestResult = { new(), new() };

            SearchUnisTestResult[0].Id = 1;
            SearchUnisTestResult[0].WebPages = new[] { "http://www.angelicum.org/" };
            SearchUnisTestResult[0].Domains = new[] { "angelicum.org" };
            SearchUnisTestResult[0].Country = "Italy";
            SearchUnisTestResult[0].Name = "Pontificia Università S. Tommaso";
            SearchUnisTestResult[0].AlphaTwoCode = "IT";

            SearchUnisTestResult[1].Id = 1;
            SearchUnisTestResult[1].WebPages = new[] { "http://www.antonianum.ofm.org/" };
            SearchUnisTestResult[1].Domains = new[] { "antonianum.ofm.org" };
            SearchUnisTestResult[1].Country = "Italy";
            SearchUnisTestResult[1].Name = "Pontificio Ateneo Antonianum";
            SearchUnisTestResult[1].AlphaTwoCode = "IT";

            SEARCH_UNIS_BY_COUNTRY = new("http://universities.hipolabs.com/search", SearchUnisTestResult);
        }

        // Endpoints
        public static readonly CustomEndpoint<UnisSearchResult> SEARCH_UNIS_BY_COUNTRY;

        // Premade Requests
        public static UnisSearchResult[] SearchUnis(String query)
        {
            return SEARCH_UNIS_BY_COUNTRY.Get(new Arg[] { new("country", query) });
        }
    }
```

Under **Premade Requests**, you can see an example of a GET request. `RestClient::Arg` is a class that allows you to define the arguments accepted by the request.

You can also change the `RestClient::CustomEndpoint.Mode` static property to toggle between **Live** and **Test** mode. When the second one is selected, instead of actually making the request, every call to the method will return the **Test Result** you've provided for that request.

## SearchBar
This control uses the **Http Requests Framework** discussed earlier to implement an extremely easy to use **Search Bar**. All you need to do is drag and drop it into any form, customize any of it's properties and supply it with a compatible function in `CustomSearchBars::CustomSearchBar.SearchMethod`. This is why we've created the funcion **SearchUnis** in `Example::Endpoints`, that uses the **SEARCH_UNIS_BY_COUNTRY** endpoint to make the GET request we need.

```csharp
customSearchBar.SearchMethod = Endpoints.SearchUnis;
```

## Item Managers
Here, you will find everything you need to create forms that will **manage the data classes** you've created by extending `Commons::ItemDatas`.

Simply create a new form which extends `CustomItemManagers::FieldsForm` and then compose it by using the **fields provided** (as well as some default elements, like buttons or labels):

1. `CustomItemManagers::TextField`
2. `CustomItemManagers::CopyableTextField`
3. `CustomItemManagers::TextFieldEditor`
4. `CustomItemManagers::PathFieldEditor`
5. `CustomItemManagers::PhoneFieldEditor`

The **TextFieldEditor** has a property called `CustomItemManagers::TextFieldEditor.FilterType { get; set; }`. By changing it, you can control whether to accept any character (`CustomItemManagers::FilterType.None`), to only accept numbers (`CustomItemManagers::FilterType.NumbersOnly` or `CustomItemManagers::FilterType.DecimalNumbersOnly`) or a date (`CustomItemManagers::FilterType.Date`). There is also a property for the **character limit** (which has no effect if the date filter is set).

Also, don't forget to **override** `CustomItemManagers::FieldsForm.Populate()`, to control how the data gets displayed in the form, and `CustomItemManagers::FieldsForm.ApplyStyle()`, so you can control how the form transforms when it's style is changed.

```csharp
public partial class ExampleViewer : FieldsForm
    {
        public ExampleViewer()
        {
            InitializeComponent();
        }

        protected override void Populate()
        {
            base.Populate();

            if (ItemDatas is null)
            {
                fieldValue.Value = "(Null Object)";
                return;
            }

            if (ItemDatas is not DataExample)
            {
                fieldValue.Value = "(Incompatible Class)";
                return;
            }

            DataExample dataExample = (DataExample)ItemDatas;

            if (dataExample.Value is null)
            {
                fieldValue.Value = "(Null Field)";
            }
            else
            {
                fieldValue.Value = dataExample.Value;
            }
        }

        protected override void ApplyStyle()
        {
            base.ApplyStyle();

            fieldValue.Style = Style;
        }
    }
```

## Items List
Implements a **list control** that displays a set of datas of a class created, as always, by extending `Commons::ItemDatas`.

Before we talk about the list itself, we need to create the item that will be actually displayed by it. To do that, simply create a new control and **extend** `CustomLists::ListItem`. Next, design your control as you please and **override** `CustomLists::ListItem.Populate()` and `CustomLists::ListItem.ApplyStyle()`. Also, unless you want to have a specialized behavour, remember to add the **ListItem_Click** consumer to the **Click Event** of all the controls in the class.

```csharp
public partial class ExampleItem : ListItem
    {
        public ExampleItem()
        {
            InitializeComponent();

            txtValue.Click += ListItem_Click;
        }

        protected override void Populate()
        {
            base.Populate();

            if (ItemDatas is null)
            {
                txtValue.Text = "Value: (Null Object)";
                return;
            }

            if (ItemDatas is not DataExample)
            {
                txtValue.Text = "Value: (Incompatible Class)";
                return;
            }

            DataExample dataExample = (DataExample)ItemDatas;

            if (dataExample.Value is null)
            {
                txtValue.Text = "Value: (Null Field)";
            }
            else
            {
                txtValue.Text = "Value: " + dataExample.Value;
            }
        }

        protected override void ApplyStyle()
        {
            base.ApplyStyle();

            Style.Apply(txtValue, Style, FontStyle.Regular);
        }
    }
```

Now, drag and drop the `CustomLists::CustomList` control into any form and set it up as you please.

If you want it, you can actually specify the form that you want to use to visualize the data and the one you want to use to modify it. In order to do that, create two forms that **extend** `CustomItemManagers::FieldsForm` and provide them to the list by updating the right properties.

```csharp
customList.Viewer = typeof(ExampleViewer);
```

If an editor is provided, an **edit button** will be shown in the top-right corner of every ListItem. By clicking it, the edit screen for that specific item will be displayed.

Finally, to set the data that is to be shown by the list, you can use `CustomLists::CustomList.SetItems<TItemDatas, TListItem>(List<TItemDatas> itemDatas) where TItemDatas : ItemDatas where TListItem : ListItem`.

```csharp
customList.SetItems<DataExample, ExampleItem>(GenPlaceHolderList(10));
```
