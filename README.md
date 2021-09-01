# ColorPickerDialog
取色专用，模仿现存的颜色板
![ColorPicker](/ColorPicker.png)

该取色界面具备以下特点：
1. 高速化了RGB转换HSV的速度，大约有6成的提升（比起使用浮动小数和Class结构而言） ->  [HSV.cs](ColorPickerDialog/Plugin/HSV.cs)
2. 采用了FastBitmapLib的方法进行图像的处理，请参考：[FastBitmap](https://github.com/LuizZak/FastBitmap)
3. 全图像界面以鼠标反馈来改变图像
   1. 为了达成高速反馈，模拟使用了双重缓冲(SquareBitmap.Bitmap -> .clone)
   2. 另外引用时可自由调整GUI界面，无需固定图像大小（未经过大改的尝试，不过还是建议直接使用不要动它）
   3. 改善了画面撕裂，延迟卡顿的现象

## 使用方法
试用时：直接启动[Program.cs](/ColorPickerDialog/Program.cs)
```Cs
// 做好接收Color结构体的准备
Color Picker; 
// 创建取色class，需给予初始状态的颜色
ColorPicker.ColorPickers cp = new ColorPicker.ColorPickers(Color.White);
// 启动取色窗口
if (cp.ShowDialog() == DialogResult.OK)
{
    // 保存你获得的颜色
    Picker = cp.SetColor;
    // 转换颜色为 HTML 代码，比如 #FF0000 (Red)
    Console.WriteLine(ColorPicker.Plugin.HSV.HTMLString(Picker));
}
// 释放内存，避免内存泄漏
cp?.Dispose();
```

