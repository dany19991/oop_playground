package com.company;

import javax.sound.midi.*;
import java.util.ArrayList;
import java.util.Iterator;

public  class BeatModel implements  BeatModelInterface, MetaEventListener {
    Sequencer sequencer;
    ArrayList beatObservers = new ArrayList();
    ArrayList bpmObservers = new ArrayList();
    int bpm = 90;
    Sequence sequence;
    Track track;

    @Override
    public void initialize() {
        setUpMidi();  // ??
        buildTrackAndStart();
    }

    private void buildTrackAndStart() {
        int[] trackList = {35, 0, 46, 0};
        sequence.deleteTrack(null);
        track = sequence.createTrack();

        makeTracks(trackList);
        track.add(makeEvent(192,9,1,0,4));
        try {
            sequencer.setSequence(sequence);
        }catch (Exception e){
            e.printStackTrace();
        }
    }

    private void makeTracks(int[] trackList) {
        for(int i = 0 ; i<trackList.length;i++){
            int key = trackList[i];
            if(key !=0){
                track.add(makeEvent(144,9,key,100,i));
                track.add(makeEvent(128,9,key,100,i+1));
            }
        }
    }

    private MidiEvent makeEvent(int comd, int chan, int one, int two, int tick) {
        MidiEvent event = null;
        try{
            ShortMessage a = new ShortMessage();
            a.setMessage(comd, chan,one,two);
            event =new MidiEvent(a,tick);
        }catch (Exception e) {
            e.printStackTrace();
        }
        return event;
    }

    private void setUpMidi() {
        try {
            sequencer= MidiSystem.getSequencer();
            sequencer.open();
            sequencer.addMetaEventListener(this);
            buildTrackAndStart();
        }catch (Exception e){
            e.printStackTrace();
        }
    }

    @Override
    public void on() {
        sequencer.start();
        setBPM(90);
    }

    @Override
    public void off() {
        setBPM(0);
        sequencer.stop();
    }

    @Override
    public void setBPM(int bpm) {
        this.bpm = bpm;
        sequencer.setTempoInBPM(getBPM());
        notifyBPMObservers();
    }

    @Override
    public int getBPM() {
        return bpm;
    }

    void beatEvent (){
        notifyBeatObservers();
    }

    @Override
    public void registerObserver(BeatObserver observer) {
        beatObservers.add(observer);
    }

    @Override
    public void removeObserver(BeatObserver observer) {
        beatObservers.remove(observer);
    }

    @Override
    public void registerObserver(BPMObsever observer) {
        bpmObservers.add(observer);
    }

    @Override
    public void removeObserver(BPMObsever observer) {
        bpmObservers.remove(observer);
    }

    private void notifyBPMObservers()
    {
        Iterator<BPMObsever> iterator = bpmObservers.iterator();
        while (iterator.hasNext()){
            BPMObsever bpmObsever=iterator.next();
            bpmObsever.updateBPM();
        }
    }

    private void notifyBeatObservers() {
        Iterator<BeatObserver> iterator = beatObservers.iterator();
        while (iterator.hasNext()){
            BeatObserver beatObserver=iterator.next();
            beatObserver.updateBeat();
        }
    }

    @Override
    public void meta(MetaMessage meta) {
        if(meta.getType() ==47){
            beatEvent();
            sequencer.start();
            setBPM(getBPM());
        }
    }
}