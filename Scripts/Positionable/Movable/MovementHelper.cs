using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementHelper {

    public static Vector3 noMovement = new Vector3(0, 0, 0);

    public enum Orientation { NORTH, SOUTH, EAST, WEST };
    public enum Direction { TURN_RIGHT, TURN_LEFT, MOVE_FORWARD, MOVE_BACKWARD, NONE };


    public static Orientation GetOrientation(Transform entity, int ajust = 0)
    {
        float orientation = (entity.rotation.eulerAngles.y + ajust) % 360;

        if (orientation > 359 || orientation < 1)
            return Orientation.NORTH;
        else if (orientation > 89 && orientation < 91)
            return Orientation.EAST;
        else if (orientation > 269 && orientation < 271)
            return Orientation.WEST;
        else
            return Orientation.SOUTH;
    }

    public static bool CanMoveInDirection(int posX, int posY, Orientation orientation)
    {

        Tile currentTile = Laby.board[posX, posY];

        if (orientation == Orientation.NORTH && !currentTile.hasWall(Wall.NORTH))
            return true;
        else if (orientation == Orientation.EAST && !currentTile.hasWall(Wall.EAST))
            return true;
        else if (orientation == Orientation.WEST && !currentTile.hasWall(Wall.WEST))
            return true;
        else if (orientation == Orientation.SOUTH && !currentTile.hasWall(Wall.SOUTH))
            return true;

        return false;
    }



}
