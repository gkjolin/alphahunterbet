using UnityEngine;
using System.Collections;

public class Emitter : MonoBehaviour {

    public GameObject[] alphabets;
	public bool[] alphabetsDroped;

    public ICollisionObservableContainer _ICollisionObservableContainer;

    int alphabetIndex;
    // Use this for initialization
    GameObject alphabetObject;

	public int cnt = 0;

	IEnumerator Start () {
		SetArray ();

        while (1 > 0)
        {
			alphabetIndex = Random.Range(0, alphabets.Length);
			while(alphabetsDroped[alphabetIndex] == true){
				Debug.Log ("In IEStart's while in while : " + gameObject.name);
				alphabetIndex = Random.Range(0, alphabets.Length);
			}
			alphabetsDroped[alphabetIndex] = true;
			cnt++;

            alphabetObject = Instantiate(alphabets[alphabetIndex], transform.position, transform.rotation) as GameObject;
            alphabetObject.GetComponent<Enemy>()._ICollisionObservable = _ICollisionObservableContainer;
            alphabetObject.GetComponent<EnemyMove>()._ICollisionObservableContainer = _ICollisionObservableContainer;

			if(cnt == alphabets.Length){
				Debug.Log ("In IEStart's while in if : " + gameObject.name);
				ResetArray ();
				cnt = 0;
			}

			yield return new WaitForSeconds(Random.Range(1, 4));
        }
	
	}

	void SetArray ()
	{
		Debug.Log ("In SetArray : " + gameObject.name);
		alphabetsDroped = new bool[alphabets.Length];
		ResetArray ();
	}

	void ResetArray ()
	{
		Debug.Log ("In ResetArray : " + gameObject.name);
		for (int i = 0; i < alphabets.Length; i++)
		{
			alphabetsDroped[i] = false;
		}
	}
}
