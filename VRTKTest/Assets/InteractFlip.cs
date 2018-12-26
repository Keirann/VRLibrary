using System.Collections;
 
namespace VRTK.Examples
{
    using UnityEngine;

    public class InteractFlip : VRTK_InteractableObject
    {
        public float fuseTime;//time between clicking the use button and detonation
        private bool isActivated = false;//true when use button is clicked, indicates that the "fuse has been lit"
        public ParticleSystem explosion;//explosion visual effects

        public float radius = 1000.0F;//radius to check for objects affected by explosion
        public float power = 1000.0F;//energy of explosion

        public override void StartUsing(VRTK_InteractUse usingObject)
        {
            base.StartUsing(usingObject);
            isActivated = true;//bomb state set to "lit"
        }

        public override void StopUsing(VRTK_InteractUse usingObject)
        {
            base.StopUsing(usingObject);
            isActivated = false;//bomb no longer "lit"
        }

        protected void Start()
        {
        }

        protected override void Update()
        {
            base.Update();
            if (isActivated)
            {//if use button has been clicked
                Invoke("Detonate", fuseTime);
                isActivated = false;
            }
        }

        void Detonate()
        {
            
        }

    }
}