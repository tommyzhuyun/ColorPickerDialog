# ColorPickerDialog
取色专用，模仿现存的颜色板
![ColorPicker](/ColorPicker.png)

该取色界面具备以下特点：
1. 高速化了RGB转换HSV的速度，大约有6成的提升（比起使用浮动小数和Class结构而言） ->  [HSV.cs](/Plugin/HSV.cs)
2. 采用了FastBitmapLib的方法进行图像的处理，请参考：[FastBitmap](https://github.com/LuizZak/FastBitmap)
3. 全图像界面以鼠标反馈来改变图像
   1. 为了达成高速反馈，模拟使用了双重缓冲(SquareBitmap.Bitmap -> .clone)
   2. 可调整GUI界面，无需固定图像大小

## 使用方法
```Cs
// 做好接收Color结构体的准备
Color Picker; 
ColorPicker.ColorPickers cp = new ColorPicker.ColorPickers(Color.White);
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

