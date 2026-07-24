#include "hamming.h"

int compute(const char *lhs, const char *rhs) {
    // check for empty strings
    if (!lhs || !rhs) return -1;

    int distance = 0;
    while (*lhs && *rhs) {
        if (*lhs != *rhs) distance++;
        lhs++;
        rhs++;
    }

    // check to see if one strand still has characters
    if (*lhs || *rhs) return -1;

    return distance;
}
