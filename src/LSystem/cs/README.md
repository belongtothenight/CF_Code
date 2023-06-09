# Draw with Unity

## Environment

1. Install VScode.
2. Install .NET framework.
3. Install Unity Hub.
4. Set up VScode as IDE. <https://www.youtube.com/watch?v=1saf4ahn-ek&pp=ygUMdW5pdHkgdnNjb2Rl>
5. In "Window/Package Manager", install "Recorder".

Entire setup process in video is available at <https://www.youtube.com/watch?v=exSkbJKT_7w>.
## Steps

1. Generate coordinate list stored with CSV by using [exportLSystemToCo.py](https://github.com/belongtothenight/CF_Code/blob/main/src/LSystem/python/exportLSystemToCo.py)
2. Create a C# script named "line" and paste [line.cs](https://github.com/belongtothenight/CF_Code/blob/main/src/LSystem/cs/line.cs) into it.
3. Create an empty object and add a component of C# script, attaches "line" to it.
4. Create a C# script named "camera" and paste [camera.cs](https://github.com/belongtothenight/CF_Code/blob/main/src/LSystem/cs/camera.cs) into it.
5. In the Main Camera object, add a component of C# script, attaches "camera" to it.
6. Open "Window/General/Recorder/Recorder Window/", set recording mode as "Frame Interval", set start and end, set FPS, add recorder "Movie", set source as "Texture Sampling", set aspect ratio, and set resolution.
7. Switch to function "DrawAllLines" in [line.cs](https://github.com/belongtothenight/CF_Code/blob/main/src/LSystem/cs/line.cs) to check the entire dimension.
8. Set camera settings to include all coordinates.
9. Switch to function "UpdateLine" in [line.cs](https://github.com/belongtothenight/CF_Code/blob/main/src/LSystem/cs/line.cs) to draw each segment based on the frame count.
10. Click the record button when the game is not playing.

## Result

Of the L-Systems setups in [LSystem.py](https://github.com/belongtothenight/CF_Code/blob/main/src/LSystem/python/LSystem.py), all four of them are animated and uploaded in the following links:

1. [L-System Q0 l5 unity](https://www.youtube.com/watch?v=7chhIO9W9Yk)
2. [L-System Q1 l5 unity](https://www.youtube.com/watch?v=HrRso8d2wXs)
3. [L-System Q2 l5 unity](https://www.youtube.com/watch?v=z62aBnNVySA)
4. [L-System Q3 l5 unity](https://www.youtube.com/watch?v=JSeMYMtlbO8)

<details open><summary>Click to see drawn LSystems</summary>
<table>
    <tr>
        <th>Question</th>
        <th>Level 1</th>
        <th>Level 2</th>
        <th>Level 3</th>
        <th>Level 4</th>
        <th>Level 5</th>
    </tr>
    <tr>
        <td>Q0</td>
        <td width="20%"><img src="pic/Q0_1.png"></td>
        <td width="20%"><img src="pic/Q0_2.png"></td>
        <td width="20%"><img src="pic/Q0_3.png"></td>
        <td width="20%"><img src="pic/Q0_4.png"></td>
        <td width="20%"><img src="pic/Q0_5.png"></td>
    </tr>
    <tr>
        <td>Q1 (2)</td>
        <td width="20%"><img src="pic/Q1_1.png"></td>
        <td width="20%"><img src="pic/Q1_2.png"></td>
        <td width="20%"><img src="pic/Q1_3.png"></td>
        <td width="20%"><img src="pic/Q1_4.png"></td>
        <td width="20%"><img src="pic/Q1_5.png"></td>
    </tr>
    <tr>
        <td>Q2 (3)</td>
        <td width="20%"><img src="pic/Q2_1.png"></td>
        <td width="20%"><img src="pic/Q2_2.png"></td>
        <td width="20%"><img src="pic/Q2_3.png"></td>
        <td width="20%"><img src="pic/Q2_4.png"></td>
        <td width="20%"><img src="pic/Q2_5.png"></td>
    </tr>
    <tr>
        <td>Q3</td>
        <td width="20%"><img src="pic/Q3_1.png"></td>
        <td width="20%"><img src="pic/Q3_2.png"></td>
        <td width="20%"><img src="pic/Q3_3.png"></td>
        <td width="20%"><img src="pic/Q3_4.png"></td>
        <td width="20%"><img src="pic/Q3_5.png"></td>
    </tr>
    <tr>
        <td>Q4 (1)</td>
        <td width="20%"><img src="pic/Q4_1.png"></td>
        <td width="20%"><img src="pic/Q4_2.png"></td>
        <td width="20%"><img src="pic/Q4_3.png"></td>
        <td width="20%"><img src="pic/Q4_4.png"></td>
        <td width="20%"><img src="pic/Q4_5.png"></td>
    </tr>
    <tr>
        <td>Q5 (4)</td>
        <td width="20%"><img src="pic/Q5_1.png"></td>
        <td width="20%"><img src="pic/Q5_2.png"></td>
        <td width="20%"><img src="pic/Q5_3.png"></td>
        <td width="20%"><img src="pic/Q5_4.png"></td>
        <!-- <td width="20%"><img src="pic/Q5_5.png"></td> -->
    </tr>
    <tr>
        <td>Q6 (5)</td>
        <td width="20%"><img src="pic/Q6_1.png"></td>
        <td width="20%"><img src="pic/Q6_2.png"></td>
        <td width="20%"><img src="pic/Q6_3.png"></td>
        <td width="20%"><img src="pic/Q6_4.png"></td>
        <td width="20%"><img src="pic/Q6_5.png"></td>
    </tr>
</table>
</details>
