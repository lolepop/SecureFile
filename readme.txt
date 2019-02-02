removes last bytes for files and encrypts it, generating an encrypted file and the (original file - encrypted bytes).

niche thing that i use when i want to save a local backup on my computer and save space by uploading the large processed encrypted file onto the cloud.

good for high entropy data like encrypted archives and just provides security mostly by obscurity.

im too lazy to write a detailed and coherent readme file.

uses native .net aes implementation and argon2.

batch build in 32 and 64 bit modes break the calling for some reason (dll doesn't change the buffer) so i just built it manually.

made over a span of a week to avoid doing my actual projects.

maybe config files soon