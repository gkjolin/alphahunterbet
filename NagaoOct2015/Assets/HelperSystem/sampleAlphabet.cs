using UnityEngine;
using System.Collections;

public class sampleAlphabet : MonoBehaviour {

	public string alphabet;
	public HelperText_Sample helperText_Sample;

	public void setAlphabet(){
		helperText_Sample.getAlphabet = alphabet;
	}
}
