

// 创建一个新的 ResizeObserver 实例，当 .flex-fill.submenu 的大小发生变化时，执行 checkDivWidth 函数
var observer = new ResizeObserver(checkDivWidth);

// checkDivWidth 函数定义如下
function checkDivWidth(entries) {
    console.log("log-1-1111");
    // entries 参数中包含了变化的每一个观察元素的信息
    // 在这里，我们只监听了一个元素，所以只需要用 entries[0] 就可以获取到 .flex-fill.submenu 的信息
    var submenuDiv = entries[0].target;

    // 获取 span 的元素
    var spanElement = submenuDiv.querySelector(".text");

    // 通过 .contentRect.width 获取到 submenuDiv 的宽度
    var divWidth = entries[0].contentRect.width;

    // 如果宽度小于某个值（比如100px），将 span 元素隐藏
    if (divWidth < 100) {
        spanElement.style.display = 'none';
    } else { // 否则显示 span 元素
        spanElement.style.display = 'inline';
    }
}


function listenDiv() {
    // 获取要观察尺寸变化的元素
    var submenuDiv = document.querySelector(".submenuccc");
    if (submenuDiv != null) {
        // 通过 observer.observe 开始观察 submenuDiv 元素的大小变化
        observer.observe(submenuDiv);
    }
}



