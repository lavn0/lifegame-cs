all: build run

build:
	mcs main.cs
run:
	mono main.exe
