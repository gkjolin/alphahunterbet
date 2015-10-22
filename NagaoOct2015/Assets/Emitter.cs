using UnityEngine;
using System.Collections;

public class Emitter : MonoBehaviour {

    public GameObject[] alphabets;

    public ICollisionObservableContainer _ICollisionObservableContainer;

    int alphabetIndex;
    // Use this for initialization
    GameObject alphabetObject;

    IEnumerator Start () {

        while (1 > 0)
        {
            alphabetIndex = Random.Range(0, alphabets.Length);
            alphabetObject = Instantiate(alphabets[alphabetIndex], transform.position, transform.rotation) as GameObject;
            alphabetObject.GetComponent<Enemy>()._ICollisionObservable = _ICollisionObservableContainer;
            alphabetObject.GetComponent<EnemyMove>()._ICollisionObservableContainer = _ICollisionObservableContainer;
            yield return new WaitForSeconds(Random.Range(1, 4));
        }
	
	}

}
