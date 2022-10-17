using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{

        public GameObject Chara;
        public float val, lag, Ymax, Ymin, Yval, Ymed;
        Vector3 _PositionPawn;
        float Zpos;
        public bool IsFollowing;

        void Start()
        {
            Zpos = transform.position.z;
        }
        void FixedUpdate()
        {
            if (IsFollowing)
            {
                if (Yval <= Ymin)
                {
                    Yval = Ymin;
                }
                else
                {
                    if (Yval >= Ymax)
                    {
                        Yval = Ymax;
                    }
                    else
                    {
                        Yval = Chara.transform.position.y;
                    }
                }

                if (Chara.GetComponent<Mouvement>().negative == false)
                {
                    _PositionPawn = new Vector3(Chara.transform.position.x + val, Yval, Zpos);
                }
                else
                {
                    _PositionPawn = new Vector3(Chara.transform.position.x - val, Yval, Zpos);
                }

                transform.position = Vector3.Lerp(transform.position, _PositionPawn, Time.deltaTime * lag);
            }

            else
            {

                Yval = Ymed;

                if (Chara.GetComponent<Mouvement>().negative == false)
                {
                    _PositionPawn = new Vector3(Chara.transform.position.x + val, Yval, Zpos);
                }
                else
                {
                    _PositionPawn = new Vector3(Chara.transform.position.x - val, Yval, Zpos);
                }

                transform.position = Vector3.Lerp(transform.position, _PositionPawn, Time.deltaTime * lag);
            }
        }
}
