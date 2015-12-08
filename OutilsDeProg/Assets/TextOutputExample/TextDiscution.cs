//INFO: CECI EST UNE VERSION TEST DES DIALOGUES, Actuellement il est possible de donner le nom de la personne + son dialogue et faire suivre celui-ci
//INFO: LE DIALOGUE ECRIT DE CETTE FAÇON ANIMEE PEUT PAS AVOIR DES EFFETS DE GRAS CHANGEMENT DE COULEUR... SI BESOIN JE CHERCHERAIS UNE FAÇON DE LE FAIRE
//INFO: ICI LE DIALOGUE COMMENCE AU START PUIS SUIS UN NOMBRE DE DIALOGUE AU DERNIER LA FENETRE SE FERME
//INFO: L'IDEE C'EST D'APPELLER CE SCRIPT LORSQUE ON VEUT A NOUVEAU FAIRE APPARAITRE DU DIALOGUE EN UTILISANT LE NOMBRE DANS TEXTTOSAY
//IDEE: ON POURRAIT FAIRE UN PETIT RANDOM A LA VITESSE DU TEXTE POUR DONNER PLUS DE VIE A L'APPARITION DES LETTRES
//IDEE: ON PEUT PARFAITEMENT SEPARER LES TEXTES POUT LES FAIRE APPARAITRE PLUS VITE SI LE PERSO EST STRESSE OU AUTRE
//INFO: POUR AUTRES EFFETS CE SERAIT PLUS SIMPLE D'ACTIVER DES ANIMATIONS DE PERSONNAGE OU SON QUE D'ANIMER LE TEXTE

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextDiscution : MonoBehaviour
{
	[Header("Typo a utiliser dans le document.txt a mettre a chaque bout du texte a modifier:")]
	[Header("Bleu:$ Rouge:| Bold:@ Italique:# Retour a la ligne:%")]
	[Header(" ")]
	
	//La vitesse d'apparition des lettes
	public float letterPause = 0.2f;
	private float _letPause;
	
	//Le message qui va etre reproduit
	string message;
	
	//Text affiche sur l'UI
	//Text textComp;
	
	//text to say number
	int textToSay;
	
	//button to next
	GameObject _ButtonToNextText;
	
	//person talking
	GameObject _personTalking;
	
	//Whole canvas
	GameObject _wholeCanvas;
	
	//Faster canvas
	GameObject _fastForwardText;
	
	string _blackStart = "<b>";
	string _blackEnd = "</b>";

	//Message 
	public TextAsset textFile;
	string[] dialogLines;
	
	// Use this for initialization
	void Start ()
	{
		// Make sure there this a text
		// file assigned before continuing
		if(textFile != null)
		{
			// Add each line of the text file to
			// the array using the new line
			// as the delimiter
			dialogLines = ( textFile.text.Split( '\n' ) );
		}

		_ButtonToNextText = GameObject.Find ("ButtonToNextText");
		_personTalking = GameObject.Find ("TextPerson");
		_wholeCanvas = GameObject.Find ("CanvasText");
		_fastForwardText = GameObject.Find ("ButtonFast");
		
		_personTalking.GetComponent<Text> ().text = "";
		//message = "This text is @bold@ and this text is #italic# and this one is |red| %a%nd the last one is $blue$";
		message = dialogLines[0];
		
		StartCoroutine (TypeText ());
	}
	
	
	/// <summary>
	/// Types the text.
	/// </summary>
	/// <returns>The text.</returns>
	IEnumerator TypeText ()
	{
		
		bool red = false; // toggle red
		bool blue = false; // toggle blue
		bool bold = false; //toggles the style for bold;
		bool italics = false; //toggles itlic style
		bool entreLine = false; //go to the line
		
		bool ignore = false; //for ignoring special characters that toggle styles
		
		_fastForwardText.GetComponent<CanvasGroup> ().alpha = 1;
		_fastForwardText.GetComponent<CanvasGroup> ().blocksRaycasts = true;
		_fastForwardText.GetComponent<CanvasGroup> ().interactable = true;
		
		foreach (char letter in message.ToCharArray()) {
			
			switch (letter) {
				
			case '|':
				ignore = true; //make sure this character isn't printed by ignoring it
				red = !red; //toggle red styling
				break;
			case '$':
				ignore = true; //make sure this character isn't printed by ignoring it
				blue = !blue; //toggle red styling
				break;
				
			case '@':
				ignore = true; //make sure this character isn't printed by ignoring it
				bold = !bold; //toggle bold styling
				break;
			case '#':
				ignore = true; //make sure this character isn't printed by ignoring it
				italics = !italics; //toggle italic styling
				break;
				
			case '%':
				ignore = true; //make sure this character isn't printed by ignoring it
				entreLine = !entreLine; //toggle red styling
				break;
			}
			
			
			string _letter = letter.ToString ();
			
			if (!ignore) {
				
				if (bold) {
					
					_letter = "<b>" + letter + "</b>";
					
				}
				if (italics) {
					
					_letter = "<i>" + letter + "</i>";
					
				}
				if (red) {
					
					_letter = "<color=#fa5d5d>" + letter + "</color>";
					
				}
				if (blue) {
					
					_letter = "<color=#5d7cfa>" + letter + "</color>";
					
				}
				if (entreLine) {
					
					_letter = "\n" + letter;
					
				}
				//textComp.text += _letter;
				_personTalking.GetComponent<Text>().text += _letter;
			}
			ignore = false;
			yield return 0;
			yield return new WaitForSeconds (_letPause);
		}
		Debug.Log ("Finished");
		_ButtonToNextText.GetComponent<CanvasGroup> ().alpha = 1;
		_ButtonToNextText.GetComponent<CanvasGroup> ().blocksRaycasts = true;
		_ButtonToNextText.GetComponent<CanvasGroup> ().interactable = true;
		
		_fastForwardText.GetComponent<CanvasGroup> ().alpha = 0;
		_fastForwardText.GetComponent<CanvasGroup> ().blocksRaycasts = false;
		_fastForwardText.GetComponent<CanvasGroup> ().interactable = false;
	}
	
	
	/// <summary>
	/// Appelle par le button next dans le canvas cette fonction permet de changer de texte
	/// Peut aussi etre appelle par d'autres scripts comme par exemple reactiver le canvas et suivre l'histoire
	/// </summary>
	public void nextText ()
	{
		_wholeCanvas.GetComponent<CanvasGroup> ().alpha = 1;
		_wholeCanvas.GetComponent<CanvasGroup> ().blocksRaycasts = true;
		_wholeCanvas.GetComponent<CanvasGroup> ().interactable = true;
		
		_ButtonToNextText.GetComponent<CanvasGroup> ().alpha = 0;
		_ButtonToNextText.GetComponent<CanvasGroup> ().blocksRaycasts = false;
		_ButtonToNextText.GetComponent<CanvasGroup> ().interactable = false;
		
		textToSay ++;

		if(textToSay < dialogLines.Length)
		{
			//_personTalking.GetComponent<Text> ().text = dialogLines[textToSay]/*"<b>INSTRUCTOR</b>"*/;
			message = dialogLines[textToSay];
			DoText ();
		}else
		{
			//trigger event suivant
			//
			//trigger event suivant
			Debug.Log ("Close");
			_wholeCanvas.GetComponent<CanvasGroup> ().alpha = 0;
			_wholeCanvas.GetComponent<CanvasGroup> ().blocksRaycasts = false;
			_wholeCanvas.GetComponent<CanvasGroup> ().interactable = false;
			
		}
	}
	
	
	/// <summary>
	/// Ceci lance l'animation du text actuel sauvegarde dans message
	/// </summary>
	public void DoText ()
	{
		_letPause = letterPause;
		
		//textComp.text = "";
		_personTalking.GetComponent<Text>().text = "";
		
		StartCoroutine (TypeText ());
	}
	
	
	public void FastThatText ()
	{
		StopAllCoroutines ();
		//textComp.text = message;
		//_personTalking.GetComponent<Text>().text = message;
		_personTalking.GetComponent<Text>().text = "";

		bool red = false; // toggle red
		bool blue = false; // toggle blue
		bool bold = false; //toggles the style for bold;
		bool italics = false; //toggles itlic style
		bool entreLine = false; //go to the line
		
		bool ignore = false; //for ignoring special characters that toggle styles
		
		foreach (char letter in message.ToCharArray()) {
			
			switch (letter) {
				
			case '|':
				ignore = true; //make sure this character isn't printed by ignoring it
				red = !red; //toggle red styling
				break;
			case '$':
				ignore = true; //make sure this character isn't printed by ignoring it
				blue = !blue; //toggle red styling
				break;
				
			case '@':
				ignore = true; //make sure this character isn't printed by ignoring it
				bold = !bold; //toggle bold styling
				break;
			case '#':
				ignore = true; //make sure this character isn't printed by ignoring it
				italics = !italics; //toggle italic styling
				break;
				
			case '%':
				ignore = true; //make sure this character isn't printed by ignoring it
				entreLine = !entreLine; //toggle red styling
				break;
			}
			
			
			string _letter = letter.ToString ();
			
			if (!ignore) {
				
				if (bold) {
					
					_letter = "<b>" + letter + "</b>";
					
				}
				if (italics) {
					
					_letter = "<i>" + letter + "</i>";
					
				}
				if (red) {
					
					_letter = "<color=#fa5d5d>" + letter + "</color>";
					
				}
				if (blue) {
					
					_letter = "<color=#5d7cfa>" + letter + "</color>";
					
				}
				if (entreLine) {
					
					_letter = "\n" + letter;
					
				}
				_personTalking.GetComponent<Text>().text += _letter;
			}
			ignore = false;
		}

		_ButtonToNextText.GetComponent<CanvasGroup> ().alpha = 1;
		_ButtonToNextText.GetComponent<CanvasGroup> ().blocksRaycasts = true;
		_ButtonToNextText.GetComponent<CanvasGroup> ().interactable = true;
		
		_fastForwardText.GetComponent<CanvasGroup> ().alpha = 0;
		_fastForwardText.GetComponent<CanvasGroup> ().blocksRaycasts = false;
		_fastForwardText.GetComponent<CanvasGroup> ().interactable = false;
	}
}
