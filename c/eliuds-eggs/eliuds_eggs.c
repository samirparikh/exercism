#include "eliuds_eggs.h"

unsigned int egg_count(int display) {
    unsigned int eggs = 0;

    while (display) {
        eggs += display % 2;
        display = (display - (display % 2)) / 2;
    }

    return eggs;
}
