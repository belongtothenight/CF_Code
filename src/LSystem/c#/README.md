# Draw with Unity

## Environment

1. Install VScode.
2. Install .NET framework.
3. Install Unity Hub.
4. Setup VScode as IDE. <https://www.youtube.com/watch?v=1saf4ahn-ek&pp=ygUMdW5pdHkgdnNjb2Rl>
5. In "Window/Package Manager", install "Recorder".

## Steps

1. Generate coordinate list stored with CSV by using [exportLSystemToCo.cs](https://github.com/belongtothenight/CF_Code/blob/main/src/LSystem/c#/exportLSystemToCo.cs)
2. Create a C# script named "line" and paste [line.cs](https://github.com/belongtothenight/CF_Code/blob/main/src/LSystem/c#/line.cs) into it.
3. Create an empty object and add a component of C# script, attaches "line" to it.
4. Create a C# script named "camera" and paste [camera.cs](https://github.com/belongtothenight/CF_Code/blob/main/src/LSystem/c#/camera.cs) into it.
5. In the Main Camera object, add a component of C# script, attaches "camera" to it.
6. Open "Window/General/Recorder/Recorder Window/", set recording mode as "Frame Interval", set start and end, set FPS, add recorder "Movie", set source as "Texture Sampling", set aspect ratio, and set resolution.
7. Switch to function "DrawAllLines" in [line.cs](https://github.com/belongtothenight/CF_Code/blob/main/src/LSystem/c#/line.cs) to check the entire dimension.
8. Set camera settings to include all coordinates.
9. Switch to function "UpdateLine" in [line.cs](https://github.com/belongtothenight/CF_Code/blob/main/src/LSystem/c#/line.cs) to draw each segment based on the frame count.
10. Click the record button when the game is not playing.
