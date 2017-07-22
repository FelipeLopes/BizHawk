CC = gcc

CFLAGS = -Wall -Wextra -O3
LFLAGS = -shared

ifeq ($(OS),Windows_NT)
	SHAREDPREFIX = 
	SHAREDEXT = dll
	LFLAGS = -shared
else
	SHAREDPREFIX = lib
	SHAREDEXT = so
	LFLAGS = -shared -fPIC
endif

all:	blip_buf

blip_buf: blip_buf.c blip_buf.h
	$(CC) $(CFLAGS) blip_buf.c -o $(SHAREDPREFIX)blip_buf.$(SHAREDEXT) $(LFLAGS)
