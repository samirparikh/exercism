#include "pangram.h"
#include <stddef.h>

bool is_pangram(const char *sentence) {
    // test null
    if (sentence == NULL) return false;

    // test empty sentence
    if (sentence[0] == '\0') return false;

    bool letter[26] = {false};

    for (int i = 0; sentence[i] != '\0'; i++) {
        int ch = sentence[i];
        // process capital letters A (65) through Z (90)
        if (ch >= 65 && ch <= 90) {
            letter[ch - 65] = true;
        // process lower case letters a (97) through z (122)
        } else if (ch >= 97 && ch <= 122) {
            letter[ch - 97] = true;
        }
    }

    for (int i = 0; i < 26; i++) {
        if (letter[i] == false)
            return false;
    }

    return true;
}
