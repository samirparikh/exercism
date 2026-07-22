#include "grains.h"

#include <math.h>

uint64_t square(uint8_t index) {
    if (index < 1 || index > 64) return 0;
    return pow(2.0, index - 1);
}

uint64_t total(void) {
    uint64_t grains = 0;
    for (int i = 1; i < 65; i++) grains += square(i);
    return grains;
}
