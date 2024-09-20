using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Utils.GenericSelection { 

    public enum SelectionType { List, Grid}

public class SelectionUI<T> : MonoBehaviour where T : ISelectHandler, IDeselectHandler
    {
   List<T> items = new List<T>();
   protected int selectedItem = 0;

     SelectionType selectionType;
       
    int gridWidth = 2;

    float selectionTimer = 0;

    const float selectionSpeed = 5;

    public event Action<int> OnSelected;

    public event Action OnBack;

    public float onMenuTimer;

        public void SetSelectionSettings(SelectionType selectionType, int gridWidth)
        {
            this.selectionType = selectionType;
            this.gridWidth = gridWidth;
        }


        public virtual void HandleUpdate()
        {
            UpdateSelectionTimer();

            int prevSelection = selectedItem;

            if (selectionType == SelectionType.List)
                HandleListSelection();
            else if (selectionType == SelectionType.Grid)
                HandleGridSelection();

            

            if (items.Count > 0)
            {
                selectedItem = Mathf.Clamp(selectedItem, 0, items.Count - 1);
            }

            if (selectedItem != prevSelection)
                UpdateSelectionUI();
            if(onMenuTimer < 1f)
            {
                return;
            }

            if (Input.GetButtonDown("Action") ||Input.GetMouseButtonDown(0) )
            {
                OnSelected?.Invoke(selectedItem);
                Debug.Log("Selected");
            }       
            else if (Input.GetButtonDown("Back") || Input.GetMouseButtonDown(1))
               OnBack?.Invoke();
        }

        public virtual void HandleListSelection()
        {
            float v = Input.GetAxisRaw("Vertical");

            if (selectionTimer == 0 && Mathf.Abs(v) > 0.2f)
            {
                 selectedItem += -(int)Mathf.Sign(v);

                selectionTimer = 0.2f;

                selectionTimer = 1 / selectionSpeed;
            }
        }

        public virtual void HandleGridSelection()
        {
            float v = Input.GetAxisRaw("Vertical");
            float h = Input.GetAxisRaw("Horizontal");

            if (selectionTimer == 0 && Mathf.Abs(v) > 0.2f || MathF.Abs(h) > 0.2f)
            {

                if(MathF.Abs(h) > MathF.Abs(v))
                 selectedItem += (int)Mathf.Sign(h);
                else
                    selectedItem += -(int)Mathf.Sign(v) * gridWidth;

                selectionTimer = 1 / selectionSpeed;
            }
        }

        public void SetItems(List<T> items)
        {
            this.items = items;
           
         //   items.ForEach(i => i.Init());
            UpdateSelectionUI();

        }   



        public virtual void UpdateSelectionUI()
        {
            for (int i = 0; i < items.Count; i++)
            {
                //items[i].OnSelectionChanged(i == selectedItem);
            }
        }

        void UpdateSelectionTimer()
        {
            onMenuTimer += Time.deltaTime;
            if (selectionTimer > 0)
                selectionTimer = Mathf.Clamp(selectionTimer - Time.deltaTime, 0, selectionTimer);
        }
    }
}
