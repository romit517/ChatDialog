using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class ServerCamera : NetworkBehaviour
{

    private void MoveCamera() {
        bool isShiftKeyDown = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
        float x_move = 0f;
        float y_move = 0f;
        float z_move = 0f;

        float y_rot = 0.0f;
        float x_rot = 0.0f;

        float movementSpeed = .5f;
        float rotationSpeed = 1f;

        if (Input.GetKeyDown(KeyCode.Space)) {
            if (isShiftKeyDown) {
                y_move = -1f;
            } else {
                y_move = 1f;
            }
        }

        if (isShiftKeyDown) {
            x_move = Input.GetAxis("Horizontal");
            x_rot = Input.GetAxis("Vertical");
        } else {
            y_rot = Input.GetAxis("Horizontal");
            z_move = Input.GetAxis("Vertical");
        }

        Vector3 moveVect = new Vector3(x_move, y_move, z_move);
        moveVect *= movementSpeed;

        Vector3 rotVect = new Vector3(x_rot, y_rot, 0);
        rotVect *= rotationSpeed;

        gameObject.GetComponent<Camera>().transform.Translate(moveVect);
        gameObject.GetComponent<Camera>().transform.Rotate(rotVect);

    }

    public void Update() {
        if (IsServer) {
            MoveCamera();
        }
    }
}
