#include "rotational_cipher.h"
#include <stdio.h>

char *rotate(const char *text, int shift_key) {
    while (*text != '\0') {
        printf("%c\n", *text);
        text++;
    }

    return *text;
}
