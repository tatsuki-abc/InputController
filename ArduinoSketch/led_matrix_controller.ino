#include <Arduino_LED_Matrix.h>

ArduinoLEDMatrix matrix;
int x = 5;
int y = 5;
byte frame[8][12] = {0}; // LEDがすべて消灯状態の配列

void setup()
{
  Serial.begin(115200);
  matrix.begin();
}

void loop()
{
  if(Serial.available())
  {
    String input = Serial.readStringUntil('\n');
    int commaIndex = input.indexOf(',');

    if(commaIndex != -1)
    {
      x = input.substring(0,commaIndex).toInt();
      y = input.substring(commaIndex + 1).toInt();
      setPixel(x, y, true);
    }
  }
}

void setPixel(int x, int y, bool state)
{
  if(x >= 0 && x < 12 && y >= 0 && y < 8)
  {
    for(int i = 0; i < 8; i++)
    {
      for(int j = 0; j < 12; j++)
      {
        frame[i][j] = 0;
      }
    }
    frame[y][x] = state ? 1: 0;
    matrix.renderBitmap(frame,8,12);
  }
}