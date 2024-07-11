// 版权声明及作者的联系信息，说明这段代码的版权归 Argo Zhang 所有，并且使用 Apache License, Version 2.0 授权。提供了官方网站链接。
using BootstrapBlazor.Components; // 引入 BootstrapBlazor 组件库，该库提供了一系列基于 Bootstrap 的 Blazor UI 组件。
using BootstrapBlazor.Maui.Models;
using Microsoft.AspNetCore.Components; // 引入 Blazor 组件开发基础命名空间。
using Microsoft.Extensions.Localization; // 引入本地化服务的命名空间，用于支持多语言。
using System.Collections.Concurrent; // 引入用于线程安全集合的命名空间。

namespace BootstrapBlazor.Maui.Components.Pages; // 定义该组件所属的命名空间。

/// <summary>
/// 表格演示组件的摘要说明，这里没有具体内容，但通常这里会提供关于组件的简介或用途的描述。
/// </summary>
public partial class TableDemo  // 声明一个部分类 TableDemo，继承自 ComponentBase，表示这是一个 Blazor 组件。
{
    [Inject] // 依赖注入特性，Blazor 通过这个特性将所需服务自动注入到组件中。
    [NotNull] // 表示注入的服务不允许为空。
    private IStringLocalizer<Foo>? Localizer { get; set; } // 定义一个本地化字符串服务的属性，用于 Foo 类的本地化字符串加载，这里使用了空安全的写法。

    private readonly ConcurrentDictionary<Foo, IEnumerable<SelectedItem>> _cache = new(); // 定义一个线程安全的字典，键为 Foo 对象，值为 SelectedItem 集合。这个缓存用于存储 Foo 对象对应的爱好列表。

    // 定义一个方法，参数为 Foo 对象，返回值为该 Foo 对象所对应的爱好集合（IEnumerable<SelectedItem>类型）。如果 _cache 中还没有这个对象的数据，就通过调用 Foo.GenerateHobbies(Localizer) 方法生成并添加到 _cache 中。
    private IEnumerable<SelectedItem> GetHobbies(Foo item) => _cache.GetOrAdd(item, f => Foo.GenerateHobbies(Localizer));

    /// <summary>
    /// 这部分没有具体内容，但通常这里会提供关于变量的详细描述或用途的说明。
    /// </summary>
    private static IEnumerable<int> PageItemsSource => new int[] { 10,20, 40 }; // 定义一个静态属性，返回一个整数集合。这个集合可能表示表格分页的每页显示记录数选项。
}
