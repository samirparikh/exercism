#include "rotational_cipher.h"
#include <stdio.h>
#include <string.h>
#include <stdlib.h>

char *rotate(const char *text, int shift_key) {

    if (text == NULL) return NULL;

    size_t length = strlen(text);
    char *result = malloc(length + 1); // +1 for null terminator
    if (result == NULL) {
        fprintf(stderr, "malloc error\n");
        return NULL;
    }

    while (*text != '\0') {
        printf("%c\n", *text);
        text++;
    }

    for (size_t i = 0; i < length; i++) {
        result[i] = text[i] + 1;
    }

    return result;
}
