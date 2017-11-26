using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum InventoryStatesID
{
    player,
    chest
}

public class InventoryStateMachine : MonoBehaviour {

    /// <summary>
    /// Save all the available inventory states in a dictionary.
    /// </summary>
    private Dictionary<InventoryStatesID, InventoryState> inventoryStates = new Dictionary<InventoryStatesID, InventoryState>();

    /// <summary>
    /// Save all the script that inherits from InventoryState script.
    /// </summary>
    private List<InventoryState> inventoryScripts = new List<InventoryState>();

    /// <summary>
    /// Reference to the inventoryState script, which will be the currentState.
    /// </summary>
    private InventoryState currentState;

    private void Start()
    {
        getInventoryStateScripts();
        loopThroughInventoryStateID();
    }
    
    /// <summary>
    /// Get every script that inherits from InventoryScript, on the same object.
    /// </summary>
    private void getInventoryStateScripts()
    {
        //create a object[] array.
        object[] script;

        //store the script in script array.
        script = GetComponents<InventoryState>();

        //Loop through the script array.
        for (int i = 0; i < script.Length; i++)
        {
            //adding every script fro mthe array to the list.
            inventoryScripts.Add((InventoryState)script[i]);
        }
        
    }

    /// <summary>
    /// Loop through the available enum types and add the to the inventoryStates.
    /// </summary>
    private void loopThroughInventoryStateID()
    {
        // store all the enum types in a string array.
        string[] availableStates = System.Enum.GetNames(typeof(InventoryStatesID));

        //Loop through the availableStates string array.
        for (int i = 0; i < availableStates.Length; i++)
        {
            addState(availableStates[i], inventoryScripts[i]);
        }
    }

    private void Update()
    {
        //if our current state is NULL, stop.
        if (currentState == null)
            return;

        //Calling our currentState Act function.
        currentState.Act();
    }

    /// <summary>
    /// Adds a new state to the the dictionary.
    /// </summary>
    /// <param name="stateID"></param>
    /// <param name="state"></param>
    private void addState(string id, InventoryState state)
    {
        // convert the string into enum type.
        InventoryStatesID stateID = (InventoryStatesID) System.Enum.Parse(typeof(InventoryStatesID), id);

        //If the inventoryStates does not have the stateID, stop the function.
        if (!inventoryStates.ContainsKey(stateID))
            return;


        //Add the new state in the dictionary.
        inventoryStates.Add(stateID, state);
    }

    /// <summary>
    /// Set a new active state.
    /// </summary>
    /// <param name="stateID"></param>
    private void setState(InventoryStatesID stateID)
    {
        //Check if our currentState is not NULL and access the .Leave() since we're assigning a new state.
        if (currentState != null)
            currentState.Leave();

        //Assign the new state.
        currentState = inventoryStates[stateID];

        //Calling the start function for our new state.
        currentState.Enter();
    }



}
