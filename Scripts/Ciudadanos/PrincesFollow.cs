using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrincesFollow : MonoBehaviour
{
    private Animator animator;
    private bool following;
    void Start()
    {
        animator = GetComponent<Animator>();
        following = false;
    }

    void Update()
    {
        if (following) {
            float horizontalAxis = Input.GetAxisRaw("Horizontal");
            float verticalAxis = Input.GetAxisRaw("Vertical");

            if (horizontalAxis == 0) {
                animator.SetBool("movingLeft", false);
                animator.SetBool("movingRight", false);
                animator.SetBool("talking", true);
            } else if (horizontalAxis < 0) {
                animator.SetBool("movingLeft", true);
                animator.SetBool("movingRight", false);
            } else {
                animator.SetBool("movingLeft", false);
                animator.SetBool("movingRight", true);
            }

            if (verticalAxis == 0) {
                animator.SetBool("movingUp", false);
                animator.SetBool("movingDown", false);
                animator.SetBool("talking", true);
            } else if (verticalAxis < 0) {
                animator.SetBool("movingUp", false);
                animator.SetBool("movingDown", true);
            } else {
                animator.SetBool("movingUp", true);
                animator.SetBool("movingDown", false);
            }
        } else {
            animator.SetBool("talking", true);
            animator.SetBool("movingLeft", false);
            animator.SetBool("movingRight", false);
            animator.SetBool("movingUp", false);
            animator.SetBool("movingDown", false);
        }
    }

    public void ChangeParent(string parent)
    {
        if (parent == "Player") {
            following = true;
            GetComponent<BoxCollider2D>().isTrigger = true;
            this.transform.parent = GameObject.FindWithTag("Player").transform;
            GameObject.FindWithTag("Player").GetComponent<PlayerPoints>().SetPlayerHasPrincess(true);
        } else if (parent == "Alcalde") {
            following = false;
            this.transform.parent = GameObject.FindWithTag("Alcalde").transform;
            this.transform.position += new Vector3(1.0f, 0.0f, 0.0f);
            GameObject.FindWithTag("Player").GetComponent<PlayerPoints>().SetPlayerHasPrincess(false);
        }
    }

    public void SetNewDialogue()
    {
        string[] sentences = new string[] {
            "Ooooohhhhhhhhhhh es mi hija",
            "¿Que tal cariño, estas bien? ¿Te han hecho algo?",
            "Muchas gracias capitan, ha salvado la vida de mi hija",
            "Como le dije, si recuperaba a mi hija, le daria lo que necesitase",
            "Veo que su barco se ha quedado sin combustible. Le daremos combustible para que pueda seguir con su mision",
            "Muchas gracias por su ayuda, y que sepa que es bienvenido en nuestor pueblo"
        };

        GameObject.FindWithTag("Alcalde").GetComponent<DialogueManager>().SetNewSentences(sentences);
    }
}
