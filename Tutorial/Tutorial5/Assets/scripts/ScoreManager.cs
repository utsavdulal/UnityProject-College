using UnityEngine;
public class ScoreManager : MonoBehaviour
{
private int score = 0;
public int Score // property
{
get { return score; } // get method
set { score = Mathf.Clamp(value, 0, 100); } // set method
}
private string strScore;
// Start is called once before the first
// execution of Update after the MonoBehaviour is created
void Start()
{
strScore = "Score: " + score;
}
// Update is called once per frame
void Update()
{
}
void OnTriggerEnter(Collider other)
{
if (other.gameObject.tag.Equals("Coin"))
{
score++;
strScore = "Score: " + score;
}
}
private void OnGUI()
{
GUI.color = Color.red;
GUI.Label(new Rect(10, 10, Screen.width, Screen.height), strScore);
}
}