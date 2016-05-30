using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class SceneController : MonoBehaviour {
    [SerializeField]
    private MemoryCard originalCard;
    [SerializeField]
    private Sprite[] images;
	[SerializeField]
	private TextMesh ScoreLabel;
    private TextMesh level;
	private MemoryCard _firstRevealed;
	private MemoryCard _secondRevealed;
	private int _score = 0;

	public int gridRows=2;
	public int gridCols=4;
	public const float offsetX = 1.50f;
	public const float offsetY = 2.5f;


	public bool canReveal {
		get { return _secondRevealed == null;}
	}

	public void cardRevealed(MemoryCard card)
	{
		if (_firstRevealed == null) {
			_firstRevealed = card;
		} 
		else {
			_secondRevealed = card;
			StartCoroutine(CheckMatch());
			//Debug.Log("Match? " + (_firstRevealed.id == _secondRevealed.id));
		}
	}

	public void Restart()
	{
	SceneManager.LoadScene (SceneManager.GetActiveScene().name);
	}

	void Start () {

		Vector3 startPos = originalCard.transform.position;

        int[] numbers = {0,0,1,1,2,2,3,3};
		numbers = ShuffleArray (numbers);

		for (int i = 0; i < gridCols; i++) {
			for (int j = 0; j < gridRows; j++) {

				MemoryCard card;
				if(i == 0 && j == 0)
					card = originalCard;
				else
					card = Instantiate(originalCard) as MemoryCard;

				int index = j * gridCols + i;
				int id = numbers[index];
				card.SetCard(id,images[id]);
				float posX = (offsetX * i) + startPos.x;
				float posY = -(offsetY * j) + startPos.y;
				card.transform.position = new Vector3(posX,posY,startPos.z);
			}
		}
        
	}
	private int[] ShuffleArray(int[] numbers)
	{
		int[] newArray = numbers.Clone () as int[];
		for (int i = 0; i < newArray.Length; i++) {
			int tmp = newArray[i];
			int r = Random.Range(i,newArray.Length);
			newArray[i] = newArray[r];
			newArray[r] = tmp;
		}
		return newArray;
	}

	private IEnumerator CheckMatch(){
		if (_firstRevealed.id == _secondRevealed.id) {
			_score++;
			ScoreLabel.text = "Rezultat: " + _score;
			Debug.Log ("Rezultat: " + _score);
			if(_score == 4)
			{
				Debug.Log("Game Won!");
                StartCoroutine(sacekaj());			}
		} 
		else {
			yield return new WaitForSeconds (.5f);

			_firstRevealed.Unreveal ();
			_secondRevealed.Unreveal ();
		}

		_firstRevealed = null;
		_secondRevealed = null;
	}

	public void Quit()
	{
		Application.Quit ();
	}

    IEnumerator sacekaj()
    {
        while (true)
        {
            yield return new WaitForSeconds(3.0f);
            SceneManager.LoadScene("Level");
        }
    }



}
