#include "queen_attack.h"

#include <stdlib.h>

attack_status_t can_attack(position_t queen_1, position_t queen_2) {

    // check for both queens on same position
    if (queen_1.row == queen_2.row && queen_1.column == queen_2.column)
        return INVALID_POSITION;

    // check that pieces are on the board
    if (queen_1.row > 7 || queen_1.column > 7 ||
        queen_2.row > 7 || queen_2.column > 7)
        return INVALID_POSITION;

    // check for same row or column
    if (queen_1.row == queen_2.row || queen_1.column == queen_2.column)
        return CAN_ATTACK;

    // check for diagonals
    if (abs(queen_1.row - queen_2.row) == abs(queen_1.column - queen_2.column))
        return CAN_ATTACK;

    return CAN_NOT_ATTACK;
}
