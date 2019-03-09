using UnityEngine;
using WebSocketSharp;

using System.Threading;

public class mySocket : MonoBehaviour {
	private WebSocket ws;
	//System.DateTime epochStart = new System.DateTime(1970, 1, 1, 0, 0, 0, System.DateTimeKind.Utc);
	public float f1 = 0, f2 = 0, f3 = 0, f4 = 0;
	public HandAnimController[] fingers;
	public float threshValue = 0.1f;
	float tf1, tf2, tf3, tf4;
	changePosition cp;
	public float x = 0;
	public float y = 0;
	float time=0;
	float timenew=0;
	float delay=0;
	void Start() {
		ws = new WebSocket("ws://localhost:10000/");
		time = System.DateTime.Now.Millisecond;

		//ws.OnOpen += OnOpenHandler;
		ws.OnMessage += OnMessageHandler;
		ws.OnClose += OnCloseHandler;

		ws.ConnectAsync();        
	}

	private void OnOpenHandler(object sender, System.EventArgs e) {
		Debug.Log("WebSocket connected!");
		Thread.Sleep(3000);
		ws.SendAsync("connected!", OnSendComplete);
	}

	private void OnMessageHandler(object sender, MessageEventArgs e) {
		//Debug.Log("WebSocket server said: " + delay);
		timenew = System.DateTime.Now.Millisecond;
		delay = timenew - time;
		time = System.DateTime.Now.Millisecond;
		string[] vec3 = e.Data.Split (','); 
	 	tf1 = float.Parse (vec3 [0]) / 32000;
		tf2 = float.Parse (vec3 [1]) / 32000;
		tf3 = float.Parse (vec3 [2]) / 32000;
		Debug.Log(tf1);
		//float x = float.Parse (e.Data);
		//cp.changepostion (x);
		//Thread.Sleep(3000);
		//ws.CloseAsync();
	}

	private void OnCloseHandler(object sender, CloseEventArgs e) {
		Debug.Log("WebSocket closed with reason: " + e.Reason);
	}

	private void OnSendComplete(bool success) {
		Debug.Log("Message sent successfully? " + success);
	}

	public void Update()
	{
		fingers [1].animationRange = tf3;
		fingers [2].animationRange = tf2;
		fingers [3].animationRange = tf1;
		//fingers [3].animationRange = tf1;
		gameObject.transform.position = new Vector3 (x-20, 0, y-20);
	}

}