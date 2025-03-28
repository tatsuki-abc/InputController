using System;
using System.IO.Ports; //Arduinoとの通信に使う
using System.Threading; //待機処理に使う
using SharpDX.XInput; //ゲームパッドの入力に使う

class Program
{
    static void Main()
    {
        //Arduinoとの接続設定
        SerialPort serial = new SerialPort("COM3", 115200); //COM3はAruduino側の設定？で確認できる。 9600はデータ送信する際に破損しない程度に安定しているが遅いやつ

        try
        {
            serial.Open();
            Console.WriteLine("Arduinoに接続しました");
        }
        catch (Exception e)
        {
            Console.WriteLine($"接続エラー:{e.Message}");
                return;
        }

        // コントローラーの初期化
        var controller = new Controller(UserIndex.One);

        if (!controller.IsConnected)
        {
            Console.WriteLine("ゲームパッドが接続されていません。");
            serial.Close();
            return;
        }

        Console.WriteLine("ゲームパッドが接続されました。入力を監視します...");

        int x = 3;
        int y = 5;

        while (true)
        {
            var state = controller.GetState();
            var gamepad = state.Gamepad;

            // 左スティックのX, Y 値を 0～11 の範囲に変換
            //int x = (gamepad.LeftThumbX + 32768) * 12 / 65536;
            //int y = (gamepad.LeftThumbY + 32768) * 8 / 65536;



            if ((gamepad.Buttons & GamepadButtonFlags.DPadUp) != 0 && y > 0) y--;
            if ((gamepad.Buttons & GamepadButtonFlags.DPadDown) != 0 && y < 7) y++;
            if ((gamepad.Buttons & GamepadButtonFlags.DPadLeft) != 0 && x > 0) x--;
            if ((gamepad.Buttons & GamepadButtonFlags.DPadRight) != 0 && x < 11) x++;

            // Arduino に座標を送信（例: "5,3\n"）
            string message = $"{x},{y}\n";
            serial.Write(message);

            Console.WriteLine("送信: " + message);
            System.Threading.Thread.Sleep(100);
        }
    }
}