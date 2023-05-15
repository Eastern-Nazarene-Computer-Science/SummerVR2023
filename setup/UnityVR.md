1. Ensure you have Unity 2021.3.25f1 or latest LTS, Oculus software, and Github setup and make sure they are up-to-date
2. Download and extract the file from https://connect-prd-cdn.unity.com/20220831/e04bb203-c0a3-4ae3-b1f3-28c32794581d/Create-with-VR_2021LTS.zip
3. Put this folder in a logical location and change the name if you want
4. In Unity Hub, click the arrow next to "Open" and select "add project from disk"
5. Find and select the project file you extracted and confirm
6. The new project should appear with the folder name you selected. Make sure 2021.3.25f1 or the latest LTS release is selected in the "Editor Version" column
6a. Accept any pop-ups it gives about changing versions and continue
7. Open the new project
8. Once open, select Window > Package manager from the Unity toolbar at the top
9. In the left panel, locate and install the following packages:
  - XR Plugin Manager
  - XR Interaction Toolkit
  - Universal RP ( Render Pipeline )
10. Once the packages are installed, open the "Project" window in Unity and open the "Scenes" folder
11. Double-click to open the scene "Create-With-VR-Starter-Scene"
12. In the hierarchy window ( on the top-right by default ), click the different objects to inspect them. Their properties will appear in the properties window ( bottom-right by default )
== We will now add a prefabricated, or Prefab, object. We will add a room environment that came with this project file.
** Open Edit > Project settings and check for errors in the XR Interaction Toolkit. If there is an error, check the "Use XR Device Simulator in scenes" box and click continue
13. In the project window, select the Course Library folder in the left pane
14. Enter the _Prefabs then Environments folders
15. Drag one foreground object, then one background object, into the Viewport(the Scene window), to add an Instance of that Prefab into the scene
15a. You can also add a room from the Prefab > Rooms folder
16. Select the "Directional Light" object in the Hierarchy
17. Select the Rotation tool in the viewport ( top-left by default ) and edit the rotation of the light
== We will now make this a playable environment
19. Click Edit > Project Settings and select the XR Plugin Management panel
20. Select OpenXR from the list of Plugin Providers
21. Click the Android icon and select OpenXR
22. Make sure you connected your device through the Quest Link software
23. Click the yellow error icon next to OpenXR
