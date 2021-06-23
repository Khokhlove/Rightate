using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class MusicWizard : EditorWindow
{
    public Sprite defaultIcon;
    public List<AudioClip> musicTracks = new List<AudioClip>();

    string path = "/Music";

    [MenuItem("Rightate/MusicWizard")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(MusicWizard));
    }

    private void Awake()
    {
        defaultIcon = AssetDatabase.LoadAssetAtPath<Sprite>($"Assets{path}/NCS.jpg");
    }

    void OnGUI()
    {
        GUILayout.Label("Music folder path", EditorStyles.boldLabel);
        path = EditorGUILayout.TextField("", path);
        Editor editor = Editor.CreateEditor(this);
        editor.OnInspectorGUI();

        if (GUILayout.Button("Invoke"))
        {
            ProcessTracks();
        }
    }

    void ProcessTracks()
    {
        if (musicTracks.Count > 0)
        {
            musicTracks.ForEach(t =>
            {
                string filePath = AssetDatabase.GetAssetPath(t);
                string[] fileInfo = filePath.Split('/');

                string fileFullName = fileInfo[fileInfo.Length - 1];
                string dirPath = $"{Application.dataPath}{path}/{t.name}";

                DirectoryInfo directory = Directory.CreateDirectory(dirPath);
                if (directory.Exists)
                {
                    string audioFilePath = $"{dirPath}/{fileFullName}";
                    string audioFileAssetPath = $"Assets{path}/{t.name}/{fileFullName}";

                    AssetDatabase.CopyAsset(AssetDatabase.GetAssetPath(t), audioFileAssetPath);
                    AudioClip audioClip = AssetDatabase.LoadAssetAtPath<AudioClip>(audioFileAssetPath);

                    AudioTrack audioTrack = CreateAudioTrack(audioClip, path);

                    if (audioTrack)
                    {
                        if (SetTrackInMusicContainer(audioTrack))
                        {
                            Debug.Log($"Track {t.name} added to MusicContainer!");
                        }
                    }
                    else
                    {
                        Debug.LogError($"AudioTrack {t.name} is not created!");
                        return;
                    }
                }
                else
                {
                    Debug.LogError($"Folder {dirPath} does not exists!");
                    return;
                }
            });

            string successMessage = $"{musicTracks.Count} track(s) was added!";
            Debug.Log(successMessage);
            PopupWindow.Show("Success!", successMessage, "OK");
        }
        else
        {
            string successMessage = "List of tracks is empty!";
            Debug.LogError(successMessage);
            PopupWindow.Show("Error!", successMessage, "OK");
        }
    }

    AudioTrack CreateAudioTrack(AudioClip audioClip, string path)
    {
        if (Directory.Exists($"Assets{path}"))
        {
            AudioTrack audioTrack = ScriptableObject.CreateInstance<AudioTrack>();
            string[] trackInfo = audioClip.name.Split('-');

            if (trackInfo.Length == 2)
            {
                audioTrack.artistName = trackInfo[0].Trim();
                audioTrack.songName = trackInfo[1].Trim();
                audioTrack.track = audioClip;
                audioTrack.image = defaultIcon;

                string assetPath = $"Assets{path}/{audioClip.name}/{audioClip.name}.asset";
                AssetDatabase.CreateAsset(audioTrack, assetPath);
                AssetDatabase.SaveAssets();

                return audioTrack;
            }
            else
            {
                return null;
            }
        }
        else
        {
            Debug.LogError($"Folder {path} does not exists!");
            return null;
        }     
    }

    bool SetTrackInMusicContainer(AudioTrack audioTrack)
    {
        MusicContainer musicContainer = MusicContainer.GetInstance();
        if (musicContainer)
        {
            musicContainer.audioTracks.Add(audioTrack);
            return true;
        }
        else
        {
            Debug.LogError("Music container instance is null!");
            return false;
        }
    }
}