using System;
using System.Windows.Forms;

public class SodokuField: Button
{
    private int _value;
    public int Value
    {
        get { return _value; }
        set
        {
            _value = value;
            if (_value < 0)
                _value = 9;
            else if (_value > 9)
                _value = 0;

            if (_value == 0)
                Text = "";
            else
                Text = _value.ToString();
        }
    }

    public SodokuField()
    {
        Height = 30;
        Width = Height;
        BackColor = Color.White;
        Value = 0;
        MouseDown += SudokuField_MouseDown;
    }

    private bool _active;
    public bool Active
    {
        get { return _active; }
        set
        {
            _active = value;
            if (_active)
                Font = new Font(FontFamily.GenericSansSerif, 12);
            else
                Font = new Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold);
        }
    }

    private void SodokuField_MouseDown(object sender, MouseEventArgs e)
    {
        if (!Active) return;

        if (e.Button == MouseButtons.Left)
            Value++;
        if (e.Button == MouseButtons.Right)
            Value--;

    }
    int lineWidth = 5;


}


