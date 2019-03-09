using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;
using System.Runtime.InteropServices;
using System.Threading;
using System;
public class webcamstream : MonoBehaviour {
    [StructLayout(LayoutKind.Explicit)]
public struct Color32Array
{
    [FieldOffset(0)]
    public byte[] byteArray;

    [FieldOffset(0)]
    public Color32[] colors;
}
	WebCamTexture webcam;
     byte[] bytes;
     public bool connest;
	 private WebSocket ws;
     Color32Array colorArray;
     Texture2D currentTexture;

     int i = 0;
    const int SEND_RECEIVE_COUNT = 15;

    //Converts the data size to byte array and put result to the fullBytes array
    void byteLengthToFrameByteArray(int byteLength, byte[] fullBytes)
    {
        //Clear old data
        Array.Clear(fullBytes, 0, fullBytes.Length);
        //Convert int to bytes
        byte[] bytesToSendCount = BitConverter.GetBytes(byteLength);
        //Copy result to fullBytes
        bytesToSendCount.CopyTo(fullBytes, 0);
    }
    void Start()
    {	
		WebCamDevice[] devices = WebCamTexture.devices;
		webcam = new WebCamTexture(WebCamTexture.devices [0].name, 640, 480, 60);
        if (devices.Length > 0)
        {
            webcam.deviceName = devices[0].name;
            GetComponent<Renderer>().material.mainTexture=webcam;
			webcam.Play();
        }
		
        //ws = new WebSocket("ws://localhost:10000/");
        ws = new WebSocket("127.0.0.1:5000/");
        currentTexture = new Texture2D(webcam.width, webcam.height);

        colorArray = new Color32Array();
        colorArray.colors = new Color32[webcam.width * webcam.height];
        ws.OnOpen += OnOpenHandler;
        ws.OnMessage += OnMessageHandler;
       // ws.OnClose += OnCloseHandler;
        InvokeRepeating("sendvid",2.0f,0.1f);
        // Invoke("sendvid",2.0f);
        ws.ConnectAsync(); 
        // StartCoroutine("sendvid");   
    }
	void sendvid()
    {       
            webcam.GetPixels32(colorArray.colors);

            byte[] pngBytes = currentTexture.EncodeToPNG();
             byte[] frameBytesLength = new byte[SEND_RECEIVE_COUNT];
            //Fill total byte length to send. Result is stored in frameBytesLength
            byteLengthToFrameByteArray(pngBytes.Length, frameBytesLength);


			//Color32[] rawImg = webcam.GetPixels32 ();
            //bytes=Color32ArrayToByteArray(rawImg);
            string result = System.Text.Encoding.UTF8.GetString(colorArray.byteArray);
           // ws.SendAsync(result, OnSendComplete);
            ws.SendAsync("chutiya " + i,  OnSendComplete);
            i++;
            // ws.SendAsync(colorArray.colors.ToString(), OnSendComplete);
            ws.SendAsync(pngBytes, OnSendComplete);
            Debug.Log(colorArray.colors.ToString());
            // for()
    }
    


	// Update is called once per frame
	void Update () {
		
	}
    
   
	  private void OnOpenHandler(object sender, System.EventArgs e) {
        Debug.Log("WebSocket connected!");
        Thread.Sleep(3000);
        ws.SendAsync("hi there", OnSendComplete);
       
    }

    private void OnMessageHandler(object sender, MessageEventArgs e) {
        Debug.Log("WebSocket server said: " + e.Data);
		//float x = float.Parse (e.Data);
        //Thread.Sleep(3000);
        //ws.CloseAsync();
    }

    private void OnCloseHandler(object sender, CloseEventArgs e) {
        Debug.Log("WebSocket closed with reason: " + e.Reason);
    }

    private void OnSendComplete(bool success) {
        // Debug.Log("Message sent successfully? " + success);
    }

	private static byte[] Color32ArrayToByteArray(Color32[] colors)
{
    if (colors == null || colors.Length == 0)
        return null;

    int lengthOfColor32 = Marshal.SizeOf(typeof(Color32));
    int length = lengthOfColor32 * colors.Length;
    byte[] bytes = new byte[length];

    GCHandle handle = default(GCHandle);
    try
    {
        handle = GCHandle.Alloc(colors, GCHandleType.Pinned);
        IntPtr ptr = handle.AddrOfPinnedObject();
        Marshal.Copy(ptr, bytes, 0, length);
    }
    finally
    {
        if (handle != default(GCHandle))
            handle.Free();
    }

    return bytes;
}

}

		