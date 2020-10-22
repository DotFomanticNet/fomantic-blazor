using Fomantic.Blazor.UI;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Fomantic.Blazor.Docs.Shared
{

    public abstract class SampleComponent
    {
        public SampleComponent(SampleComponent parent)
        {
            ParentComponent = parent;
        }
        public SampleComponent ParentComponent { get; private set; }
        public abstract ComponentBase ThisComponent { get; }
        public abstract RenderFragment GetRenderFragment(SampleComponent selectedSampleComponent);
        public abstract string GetHtmlCode();
        public abstract string GetCsharpCode();

        public abstract List<string> GetNamespaces();
        public abstract void InitComponent();

    }
    public abstract class SampleComponent<T> : SampleComponent where T : ComponentBase
    {

        protected SampleComponent(SampleComponent parentComponent, Action<T> onComponentCreate) : base(parentComponent)
        {

            OnComponentCreate = onComponentCreate;
        }
        public Dictionary<string, object> AdditionalAttributes { get; set; } = new Dictionary<string, object>();
        public string VariableName { get; set; }
        public override ComponentBase ThisComponent => Component;
        public T Component { get; set; }
        public Action<T> OnComponentCreate { get; set; }

        public abstract RenderFragment GetInternalComponents(SampleComponent selectedSampleComponent);

        public override void InitComponent()
        {
            if (Component != null)
            {
                OnComponentCreate?.Invoke(Component);
            }

        }
        public abstract string GetContentCode();
        public override string GetHtmlCode()
        {
            if (Component == null)
            {
                return "";
            }
            string code = "";
            var defualtComponent = Activator.CreateInstance<T>();
            code += $"<{Component.GetType().Name}";
            var itemProp = Component.GetType().GetProperties().Where(prop => Attribute.IsDefined(prop, typeof(ParameterAttribute))).ToList();
            if (!string.IsNullOrEmpty(VariableName))
            {
                code += $" @ref='{VariableName}'";
            }
            foreach (var prop in itemProp)
            {
                if (!prop.PropertyType.IsClass)
                {
                    var value = prop.GetValue(Component);
                    var defaultValue = prop.GetValue(defualtComponent);

                    if (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                    {

                        if (value != null)
                        {
                            if (prop.PropertyType.GetGenericArguments()[0].IsEnum)
                            {
                                code += $" {prop.Name}='{prop.PropertyType.GetGenericArguments()[0].Name}.{value}'";
                            }
                        }


                    }
                    else
                    {
                        if (!value.Equals(defaultValue))
                        {
                            if (prop.PropertyType.IsAssignableFrom(typeof(int)))
                            {

                                code += $" {prop.Name}='{value.ToString()}'";

                            }
                            if (prop.PropertyType.IsAssignableFrom(typeof(bool)))
                            {

                                code += $" {prop.Name}='{value.ToString().ToLower()}'";

                            }
                            if (prop.PropertyType.IsEnum)
                            {


                                code += $" {prop.Name}='{prop.PropertyType.Name}.{value}'";


                            }
                        }
                    }



                }
            }
            code += $">{Environment.NewLine}";
            //  if (Component.GetType().GetProperties().Any(prop => prop.PropertyType.IsAssignableFrom(typeof(RenderFragment)) && Attribute.IsDefined(prop, typeof(ParameterAttribute))))
            //   {
            //  code += $"{Environment.NewLine} ... ";
            //  }
            var innercode = GetContentCode().Replace(Environment.NewLine, Environment.NewLine + "  ");
            code += "  " + innercode.Substring(0, innercode.Length - 2);
            code += $"</{Component.GetType().Name}>{Environment.NewLine}";
            return code;
        }
        public override RenderFragment GetRenderFragment(SampleComponent selectedSampleComponent)
        {
            return new RenderFragment(builder =>
            {

                int x = 0;
                builder.OpenComponent<T>(++x);

                builder.AddAttribute(++x, "class", selectedSampleComponent == this ? "editable selected" : "");
                foreach (var item in AdditionalAttributes)
                {
                    builder.AddAttribute(++x, item.Key, item.Value);
                }
                if (GetInternalComponents(selectedSampleComponent) != null)
                {
                    builder.AddAttribute(++x, "ChildContent", GetInternalComponents(selectedSampleComponent));
                }
                builder.AddComponentReferenceCapture(++x, d => Component = (T)d);
                builder.CloseComponent();
            });
        }
    }

    public interface ISampleComponentWithHtmlContent
    {
        string Content { get; set; }
    }
    public class SampleComponentWithHtmlContent<T> : SampleComponent<T>, ISampleComponentWithHtmlContent where T : ComponentBase
    {
        public SampleComponentWithHtmlContent(SampleComponent parentComponent, Action<T> onComponentCreate = null) : base(parentComponent, onComponentCreate)
        {

        }
        public MarkupString HtmlContent { get; set; }
        public string Content
        {
            get { return HtmlContent.ToString(); }
            set { HtmlContent = new MarkupString(value); }
        }
        public override string GetContentCode()
        {
            return Content + Environment.NewLine;
        }



        public override RenderFragment GetInternalComponents(SampleComponent selectedSampleComponent)
        {
            return new RenderFragment(builder =>
            {
                builder.AddContent(0, HtmlContent);
            });
        }
        public override string GetCsharpCode()
        {
            return "";
        }
        public override List<string> GetNamespaces()
        {
            return new List<string>() { "Fomantic", "Fomantic.Blazor.UI" };
        }
    }

    public interface ISampleComponentWithChildren
    {
        int GetChildrenCount();
        List<SampleComponent> GetInternalComponents();
    }
    public class SampleComponentWithChildren<T> : SampleComponent<T>, ISampleComponentWithChildren where T : ComponentBase
    {
        public SampleComponentWithChildren(SampleComponent parentComponent, Action<T> onComponentCreate = null) : base(parentComponent, onComponentCreate)
        {

        }
        public List<SampleComponent> InternalComponents { get; set; } = new List<SampleComponent>();

        public int GetChildrenCount()
        {
            return InternalComponents?.Count ?? 0;
        }

        public override string GetContentCode()
        {
            if (Component == null)
            {
                return "";
            }
            string code = "";
            foreach (var item in InternalComponents)
            {
                code += item.GetHtmlCode();
            }
            return code;
        }

        public override RenderFragment GetInternalComponents(SampleComponent selectedSampleComponent)
        {
            return new RenderFragment(builder =>
            {
                int i = 0;
                foreach (var item in InternalComponents)
                {
                    builder.AddContent(i++, item.GetRenderFragment(selectedSampleComponent));
                }
            });
        }

        List<SampleComponent> ISampleComponentWithChildren.GetInternalComponents()
        {
            return InternalComponents;
        }

        public override string GetCsharpCode()
        {
            string code = "";
            foreach (var item in InternalComponents)
            {
                code += item.GetCsharpCode();
            }
            return code;
        }
        public override List<string> GetNamespaces()
        {
            return new List<string>() { "Fomantic", "Fomantic.Blazor.UI" };
        }
    }
    public class SampleComponentAction<T>
    {
        public Action<T> OnExecute { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }
    }
    public class SampleComponentActionWithChildren<T> : SampleComponent<T>, ISampleComponentWithChildren where T : ComponentBase
    {

        public List<SampleComponentAction<T>> Actions { get; set; } = new List<SampleComponentAction<T>>();
        public SampleComponentActionWithChildren(string variableName, SampleComponent parentComponent, Action<T> onComponentCreate = null) : base(parentComponent, onComponentCreate)
        {
            VariableName = variableName;
        }
        public List<SampleComponent> InternalComponents { get; set; } = new List<SampleComponent>();

        public override RenderFragment GetRenderFragment(SampleComponent selectedSampleComponent)
        {
            return new RenderFragment(builder =>
            {

                int x = 0;
                builder.OpenElement(++x, "div");
                builder.AddAttribute(++x, "class", "ui row padding buttons");
                foreach (var item in Actions)
                {
                    builder.OpenElement(++x, "button");
                    builder.AddAttribute(++x, "class", "ui small button");
                    builder.AddAttribute<MouseEventArgs>(++x, "onclick",
                       EventCallback.Factory.Create<MouseEventArgs>(this, d => item.OnExecute(this.Component))
                        );
                    builder.AddContent(++x, item.Name);
                    builder.CloseElement();
                }
                builder.CloseElement();
                builder.OpenComponent<T>(++x);

                builder.AddAttribute(++x, "class", selectedSampleComponent == this ? "editable selected" : "");

                if (GetInternalComponents(selectedSampleComponent) != null)
                {
                    builder.AddAttribute(++x, "ChildContent", GetInternalComponents(selectedSampleComponent));
                }
                builder.AddComponentReferenceCapture(++x, d => Component = (T)d);
                builder.CloseComponent();
            });
        }
        public int GetChildrenCount()
        {
            return InternalComponents?.Count ?? 0;
        }

        public override string GetHtmlCode()
        {
            if (Component == null)
            {
                return "";
            }
            string code = "<div class=\"ui row padding buttons\">" + Environment.NewLine; ;

            foreach (var item in Actions)
            {
                code += $"   <button class=\"ui button\" @onclick=\"{VariableName}_{item.Name}\">{item.Name}</button>" + Environment.NewLine; ;
            }
            code += "</div>" + Environment.NewLine; ;
            code += base.GetHtmlCode();
            return code;
        }
        public override string GetContentCode()
        {
            if (Component == null)
            {
                return "";
            }
            string code = "";
            foreach (var item in InternalComponents)
            {
                code += item.GetHtmlCode();
            }
            return code;
        }

        public override RenderFragment GetInternalComponents(SampleComponent selectedSampleComponent)
        {
            return new RenderFragment(builder =>
            {
                int i = 0;
                foreach (var item in InternalComponents)
                {
                    builder.AddContent(i++, item.GetRenderFragment(selectedSampleComponent));
                }
            });
        }

        List<SampleComponent> ISampleComponentWithChildren.GetInternalComponents()
        {
            return InternalComponents;
        }

        public override string GetCsharpCode()
        {
            string code = "";
            code += $"  {typeof(T).Name} {VariableName};" + Environment.NewLine;
            foreach (var item in Actions)
            {
                code += $"  private async Task {VariableName}_{item.Name}(MouseEventArgs args)" + Environment.NewLine;
                code += "  {" + Environment.NewLine;
                code += $"    { VariableName}.{item.Code}" + Environment.NewLine;
                code += "  }" + Environment.NewLine;
            }
            foreach (var item in InternalComponents)
            {
                code += item.GetCsharpCode();
            }
            return code;
        }
        public override List<string> GetNamespaces()
        {
            return new List<string>() { "Fomantic", "Fomantic.Blazor.UI" };
        }
    }
    public partial class Sample : ComponentBase
    {
        [Parameter]
        public string PageUri { get; set; }
        public bool ApiReferenceHidden { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [CascadingParameter]
        public DocumentationArticle Parent { get; set; }

        [CascadingParameter]
        public DocumentationArticleGroup ParentGroup { get; set; }

        public string SheetViewType { get; set; } = "Properties";
        bool initilized;
        bool isLoading = true;
        ElementReference sideMenu1;
        ElementReference sideMenu2;
        public ElementReference ElementRef;
        SampleComponent currentComponent;
        AddComponentModal addComponentModalRef;
        string code;
        ElementReference codeArea;
        MethodParamterForm MethodInvocationForm;
        [Parameter]
        public bool IsPlayed { get; set; } = true;
        bool isEditing = false;
        [Parameter]
        public string SampleCodeLanguage { get; set; } = "razor";

        [Parameter]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Parameter]
        public List<SampleComponent> ComponentsTypes { get; set; } = new List<SampleComponent>();
        [Parameter]
        public RenderFragment DescriptionTemplate { get; set; }
        [Parameter]
        public RenderFragment ApiDocumentation { get; set; }

        [Parameter]
        public RenderFragment SampleBody { get; set; }

        [Parameter]
        public string SampleCode { get; set; }

        [Parameter]
        public RenderFragment Title { get; set; }

        public List<Tuple<string, object, PropertyInfo>> Prop { get; set; } = new List<Tuple<string, object, PropertyInfo>>();

        public List<Tuple<string, object, MethodInfo>> Methods { get; set; } = new List<Tuple<string, object, MethodInfo>>();
        [Parameter]
        public bool IsCodeHidden { get; set; } = true;

        string GetCodeHiddenClass()
        {
            if (IsCodeHidden)
            {
                return "transition hidden";
            }
            return "";
        }

        IJSObjectReference editor;

        protected async override Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
            if (firstRender)
            {

                if (!ParentGroup?.Children?.Any(d => d == this) ?? false)
                {
                    ParentGroup?.Children?.Add(this);
                }
            }

            await RefreshCode();
            Task.Run(async () => { await InnerInitilize(); });
        }

        private async Task InnerInitilize()
        {
            if (!initilized)
            {
                if (NavigationManager.Uri.Contains("#"))
                {
                    var id = NavigationManager.Uri.Substring(NavigationManager.Uri.LastIndexOf("#"), NavigationManager.Uri.Length - NavigationManager.Uri.LastIndexOf("#"));
                    id = id.Replace("#", "");
                    if (!string.IsNullOrEmpty(id) && id == Id)
                    {
                        await ElementRef.JumpToTopOf(JsRuntime);
                    }

                }
                initilized = true;
                this.StateHasChanged();



                for (int i = 0; i < ComponentsTypes.Count; i++)
                {
                    ComponentsTypes[i]?.InitComponent();
                }

                editor = await JsRuntime.InvokeAsync<IJSObjectReference>("window.demo.editorInit", codeArea, SampleCodeLanguage);
                isLoading = false;

                this.StateHasChanged();
               
            }
        }

        private async Task RefreshCode()
        {
            if (IsPlayed)
            {
                if (string.IsNullOrWhiteSpace(SampleCode))
                {


                    var newCode = constractCode();

                    if (newCode != code)
                    {
                        code = newCode;
                        while (editor == null)
                        {
                            await Task.Delay(100);
                        }

                        await editor.InvokeVoidAsync("setValue", code);
                    }
                }
                else
                {
                    var newCode = SampleCode;

                    if (newCode != code)
                    {
                        code = newCode;
                        while (editor == null)
                        {
                            await Task.Delay(100);
                        }

                        await editor.InvokeVoidAsync("setValue", code);
                    }
                }
            }
        }

        public void ToggleEditing()
        {
            isEditing = !isEditing;
            if (isEditing)
            {
                Open();
            }
            else
            {
                Close();
            }

        }

        [JSInvokable]
        public void Close()
        {
            currentComponent = null;
            isEditing = false;
            this.StateHasChanged();
        }

        public async void CopyCode()
        {

            await JsRuntime.InvokeVoidAsync("window.demo.copyText", code.Replace("...", ""));
        }
        public async void Open()
        {
            currentComponent = null;

            await JsRuntime.InvokeVoidAsync("window.demo.togglePropSheet", sideMenu1, sideMenu2, DotNetObjectReference.Create(this));
        }
        public async void Select(SampleComponent x)
        {

            currentComponent = x;
            if (currentComponent != null)
            {
                var t = currentComponent.ThisComponent.GetType();

                var NestedClasses = t.GetProperties().Where(
         prop => Attribute.IsDefined(prop, typeof(NestedParamterAttribute))).ToList();

                Prop = t.GetProperties().Where(
            prop => Attribute.IsDefined(prop, typeof(ParameterAttribute)))
            .Select(d => new Tuple<string, object, PropertyInfo>("", this.currentComponent.ThisComponent, d)).ToList();



                Methods = t.GetMethods().Where(
          prop => Attribute.IsDefined(prop, typeof(ComponentActionAttribute)))
                    .Select(d => new Tuple<string, object, MethodInfo>("", this.currentComponent.ThisComponent, d)).ToList();

                foreach (var item in NestedClasses)
                {
                    var nt = item.PropertyType;


                    Prop.AddRange(nt.GetProperties().Where(
                prop => Attribute.IsDefined(prop, typeof(ParameterAttribute)))
                .Select(d => new Tuple<string, object, PropertyInfo>(item.Name, item.GetValue(this.currentComponent.ThisComponent), d)).ToList());

                    var nestedMethods = nt.GetMethods()
             .Where(prop => Attribute.IsDefined(prop, typeof(ComponentActionAttribute)))
             .Select(d => new Tuple<string, object, MethodInfo>(item.Name, item.GetValue(this.currentComponent.ThisComponent), d)).ToList();

                    Console.WriteLine($"adding {item.Name}({nt.Name}) nested param with Nested {nestedMethods.Count} methods");
                    Methods.AddRange(nestedMethods);
                }

                this.StateHasChanged();
                await JsRuntime.InvokeVoidAsync("window.demo.initPropSheetElements");
            }


        }
        public void InvokeMethod(EventArgs e, object component, MethodInfo method)
        {
            var parameters = method.GetParameters();
            if (parameters.Count() == 0)
            {
                method.Invoke(component, null);
            }
            else
            {
                MethodInvocationForm.Open(method, component);
            }

        }
        public void OnEnumChange(ChangeEventArgs e, PropertyInfo prop)
        {

            if (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
            {

                if (e.Value.ToString() == "None")
                {
                    prop.SetValue(currentComponent.ThisComponent, null);
                }
                else
                {
                    prop.SetValue(currentComponent.ThisComponent, Enum.Parse(prop.PropertyType.GetGenericArguments()[0], e.Value.ToString()));
                }
            }
            else
            {
                prop.SetValue(currentComponent.ThisComponent, Enum.Parse(prop.PropertyType, e.Value.ToString()));
            }
            if (Parent != null)
            {
                Parent.Refresh();
            }
            else if (ParentGroup != null)
            {
                ParentGroup.Refresh();
            }
            else
            {
                this.StateHasChanged();
            }

        }
        public void OnBooleanChange(ChangeEventArgs e, PropertyInfo prop)
        {

            prop.SetValue(currentComponent.ThisComponent, e.Value);
            this.StateHasChanged();
        }

        public string constractCode()
        {
            var code = "";
            var htmlCode = "";
            var csharpCode = "";

            code += "@using Fomantic" + Environment.NewLine;
            code += "@using Fomantic.Blazor.UI" + Environment.NewLine + Environment.NewLine;

            if (ComponentsTypes != null)
            {

                foreach (var item in ComponentsTypes)
                {
                    htmlCode += item.GetHtmlCode();
                }


                foreach (var item in ComponentsTypes)
                {
                    csharpCode += item.GetCsharpCode();
                }
            }
            code += htmlCode;
            if (!string.IsNullOrWhiteSpace(csharpCode))
            {
                code += "@code {" + Environment.NewLine;
                code += csharpCode;
                code += "}" + Environment.NewLine;
            }
            return code;
        }

    }
}
