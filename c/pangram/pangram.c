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
        if (ch >= 'A' && ch <= 'Z') {
            letter[ch - 'A'] = true;
        // process lower case letters a (97) through z (122)
        } else if (ch >= 'a' && ch <= 'z') {
            letter[ch - 'a'] = true;
        }
    }

    for (int i = 0; i < 26; i++) {
        if (letter[i] == false)
            return false;
    }

    return true;
}
