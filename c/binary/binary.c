#include "binary.h"

int convert(const char *input) {
    int n = 0;
    for (; *input; input++) {
        if (*input > '1') return INVALID;
        n = 2 * n + (*input - '0');
    }
    return n;
}
