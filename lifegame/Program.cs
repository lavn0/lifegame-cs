using System;

class MainClass {
  public static void Main() {
    String[][] b = new String[5][];

    for (int i = 0; i < 5; i++) {
      b[i] = new String[5];
      for (int j = 0; j < 5; j++) {
        b[i][j] = "□";
      }
    }

    b[2][1] = "■";
    b[2][2] = "■";
    b[2][3] = "■";

    for (int i = 0; i < 5; i++) {
      String line = "";
      for (int j = 0; j < 5; j++) {
        line = line + b[i][j];
      }
      Console.WriteLine(line);
    }

    for (int times = 0; times < 3; times++) {
      String[][] bb = new String[5][];
      for (int i = 0; i < 5; i++) {
        bb[i] = new String[5];
        for (int j = 0; j < 5; j++) {
          if (b[i][j] == "□") {
            // 誕生の場合
            int count = 0;
            if (i > 0 && j > 0 && b[i-1][j-1] == "■") count += 1;
            if (i > 0 && b[i-1][j] == "■") count += 1;
            if (i > 0 && j < 4 && b[i-1][j+1] == "■") count += 1;

            if (j > 0 && b[i][j-1] == "■") count += 1;
            if (b[i][j] == "■") count += 1;
            if (j < 4 && b[i][j+1] == "■") count += 1;

            if (i < 4 && j > 0 && b[i+1][j-1] == "■") count += 1;
            if (i < 4 && b[i+1][j] == "■") count += 1;
            if (i < 4 && j < 4 && b[i+1][j+1] == "■") count += 1;

            if (count >= 3) {
              bb[i][j] = "■";
            } else {
              bb[i][j] = "□";
            }
          }
          if (b[i][j] == "■") {
            // 生存・過疎・過密の場合
            int count = 0;
            
            if (i > 0 && b[i-1][j] == "■") count += 1;
            if (j > 0 && b[i][j-1] == "■") count += 1;
            if (j < 4 && b[i][j+1] == "■") count += 1;
            if (i < 4 && b[i+1][j] == "■") count += 1;

            if (count == 2) {
              bb[i][j] = b[i][j];
            } else {
              bb[i][j] = "□";
            }
          }
        }
      }
      b = bb;

      Console.WriteLine(times + "==========");

      for (int i = 0; i < 5; i++) {
        String line = "";
        for (int j = 0; j < 5; j++) {
          line = line + b[i][j];
        }
        Console.WriteLine(line);
      }
    }
  }
}
