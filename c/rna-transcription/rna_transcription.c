#include "rna_transcription.h"
#include <stdlib.h>
#include <string.h>

char *to_rna(const char *dna) {
    size_t length = strlen(dna);
    char *rna = malloc(length + 1);
    int i = 0;
    while (dna[i] != '\0') {
        switch (dna[i]) {
            case 'G':
                rna[i] = 'C';
                break;
            case 'C':
                rna[i] = 'G';
                break;
            case 'T':
                rna[i] = 'A';
                break;
            case 'A':
                rna[i] = 'U';
                break;
            default:
                free(rna);
                return NULL;
        }
        i++;
    }
    rna[i] = '\0';

    return rna;
}
