#include "rotational_cipher.h"
#include <stdio.h>
#include <string.h>
#include <stdlib.h>
#include <ctype.h>

char *rotate(const char *text, int shift_key) {

    if (text == NULL) return NULL;

    size_t length = strlen(text);
    char *result = malloc(length + 1); // +1 for null terminator
    if (result == NULL) {
        fprintf(stderr, "malloc error\n");
        return NULL;
    }

    for (size_t i = 0; i < length; i++) {
        if (isalpha((unsigned char)text[i])) {
            if (islower(text[i])) {
                result[i] = 'a' + ((text[i] - 'a' + shift_key) % 26);
            }
            else {
                result[i] = 'A' + ((text[i] - 'A' + shift_key) % 26);
            }
        } else {
            result[i] = text[i];
        }
    }

    result[length] = '\0';

    return result;
}
