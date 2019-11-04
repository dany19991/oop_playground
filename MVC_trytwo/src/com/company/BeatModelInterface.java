package com.company;

public interface BeatModelInterface
{
    void initialize();
    void on();
    void off();
    void setBPM(int bpm);
    int getBPM();

    void registerObserver(BeatObserver observer);
    void removeObserver(BeatObserver observer);
    void registerObserver(BPMObsever observer);
    void removeObserver(BPMObsever observer);
}