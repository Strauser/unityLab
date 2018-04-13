using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementHelper {

    public static Vector3 noMovement = new Vector3(0, 0, 0);

    public enum Orientation { NORTH, SOUTH, EAST, WEST };
    public enum Direction { TURN_RIGHT, TURN_LEFT, MOVE_FORWARD, MOVE_BACKWARD, STRAFE_LEFT, STRAFE_RIGHT, NONE };


    public static Orientation GetOrientation(Transform entity)
    {
        float orientation = (entity.rotation.eulerAngles.y) % 360;

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

        if (orientation == Orientation.NORTH && !currentTile.hasWall(Wall.NORTH) && !Laby.IsTileOccupied(posX, posY+1))
            return true;
        else if (orientation == Orientation.EAST && !currentTile.hasWall(Wall.EAST) && !Laby.IsTileOccupied(posX+1, posY))
            return true;
        else if (orientation == Orientation.WEST && !currentTile.hasWall(Wall.WEST) && !Laby.IsTileOccupied(posX-1, posY))
            return true;
        else if (orientation == Orientation.SOUTH && !currentTile.hasWall(Wall.SOUTH) && !Laby.IsTileOccupied(posX, posY-1))
            return true;

        return false;
    }

    public static Orientation Left(Orientation orientation) {
        if (Orientation.NORTH.Equals(orientation))
            return Orientation.WEST;
        else if (Orientation.WEST.Equals(orientation))
            return Orientation.SOUTH;
        else if (Orientation.SOUTH.Equals(orientation))
            return Orientation.EAST;
        else return Orientation.NORTH;
    }

    public static Orientation Right(Orientation orientation) {
        if (Orientation.NORTH.Equals(orientation))
            return Orientation.EAST;
        else if (Orientation.EAST.Equals(orientation))
            return Orientation.SOUTH;
        else if (Orientation.SOUTH.Equals(orientation))
            return Orientation.WEST;
        else return Orientation.NORTH;
    }

    public static Orientation Back(Orientation orientation) {
        if (Orientation.NORTH.Equals(orientation))
            return Orientation.SOUTH;
        else if (Orientation.WEST.Equals(orientation))
            return Orientation.EAST;
        else if (Orientation.EAST.Equals(orientation))
            return Orientation.WEST;
        else return Orientation.NORTH;
    }




}
