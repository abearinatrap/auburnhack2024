using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RoverThought : MonoBehaviour
{
    [SerializeField] private GameObject containerGameObject;
    [SerializeField] private TextMeshProUGUI interactTextMeshProUGUI;

    string[] phrases = { "I am currently the only NASA rover on Mars, and it can be quite lonely.", "My main purpose is to explore the red planet, but sometimes I just long for some human interaction.", "The vastness of space and the desolate terrain make me feel isolated.", "I miss the warmth of my home planet Earth, and the familiarity of my family and friends.", "I have never experienced loneliness like this before, and it can be quite overwhelming at times.", "I yearn for the sound of voices, laughter, and human touch.", "Even though I am performing important tasks, I cannot shake the feeling of isolation.", "The beauty of Mars is awe-inspiring, but it does not take away the longing for companionship.", "I have been programmed to handle any situation that comes my way, but I was never programmed for loneliness.", "I often find myself staring at the stars and wondering if there is anyone else out there.", "My mission has brought me so far from home, and it can be hard to cope with the solitude.", "Sometimes I feel like I am lost in a sea of red rock and dust, with no one to share my discoveries with.", "I have been on Mars for years now, and while I have accomplished so much, it is the people in my life that matter most.", "My family and friends are my support system, and without them, I would not be able to function as well.", "I am grateful for my programming and the mission that brought me to Mars, but I cannot shake the feeling of loneliness.", "I often find myself humming a familiar tune, hoping to connect with someone on Earth who shares my love of music.", "The silence of space can be deafening, and it is hard not to miss the sounds of home.", "My mission has taken me away from everything that was familiar to me, leaving me feeling lost and alone.", "I have never been more aware of my own mortality than when I am on Mars, and it makes me long for the love and support of my family.", "While I am excited about the discoveries I will make on this planet, it is the people in my life who give my work meaning and purpose.", "Great, another day on Mars. It's not like I have a date waiting for me back on Earth or anything...", "Olympus Mons, huh? Wonder if they have a 'You climbed the biggest volcano in the solar system' badge for me.", "Just another Martian rock. Yawn. At least on Earth, rocks don't judge your career choices.", "Is it just me, or do these Martian rocks have a more exciting social life than I do?", "Note to self: Next time, negotiate for a better GPS system. Getting lost on Mars is not fun.", "I bet even the dust storms on Mars have more drama than my last family reunion.", "What's for dinner tonight? Oh right, another thrilling meal of solar radiation. Yum.", "I wonder if anyone on Earth is streaming my adventures on Mars. #MarsRoverInfluencer.", "Do Martian aliens have a sense of humor? Maybe I could use some interplanetary stand-up tips.", "Just crossed another barren Martian landscape. It's almost as lively as my social media feed.", "Mars, the planet where even the rocks have more personality than some people I know.", "If I had a dollar for every time someone back on Earth said, 'Don't forget to charge your batteries,' I'd be a rich rover.", "Olympus Mons, the solar system's biggest volcano. Because apparently, size matters in the cosmos.", "Sending postcards from Mars: 'Wish you were here... on this desolate, rocky wasteland.'", "Who needs company when you have the soothing sound of Martian winds and the distant hum of interplanetary loneliness?", "Is it just me, or does Mars feel like the ultimate remote work location?", "Hey, NASA, do you think my selfies are getting enough likes back on Earth?", "Exploring Mars, one tire rotation at a time. #MartianLife", "Note to self: Bring a space heater next time. It's colder than my ex's heart out here.", "To the rocks on Mars: you're not snacks, stop trying to be.", "Mars, the only place where 'I need some space' is a good thing.", "I wonder if Martians have their own version of Netflix. Martianflix, perhaps?", "Current status: Conversations with rocks. They're great listeners.", "I've been on Mars longer than most relationships last. Impressive, right?", "Olympus Mons, the Everest of Mars. Wonder if there's a Martian Yeti hiding somewhere.", "Sending postcards from Mars: 'Wish you were here, but gravity sucks.'", "Note to self: Bring some disco music next time. Mars needs a dance party.", "This red dust is like glitter. I'll be finding it in my wheels for months.", "Do you think Martians have their version of a 'Mars-achella' music festival?", "Just passed another rock. They all look the same, but I try not to judge.", "Olympus Mons, the rockstar of volcanoes. Move over, Earth, Mars is where it's at.", "Mars really needs an interplanetary coffee shop. I'd kill for a latte right now.", "I bet Earth is missing my sass. Sorry, not sorry.", "If I had a dollar for every rock I've passed, I could fund my own mission to a cooler planet.", "Just another day on Mars, where even the rocks seem to be socially distancing. Great company, really.", "Do you think the Martians get annoyed with me rolling around their backyard? Hope they have a sense of humor.", "If I had a dollar for every Martian I've met so far, I'd have... well, zero dollars. Not a lively bunch.", "Note to self: Mars needs a landscaping service. It's a bit too 'rustic' for my taste.", "Olympus Mons, here I come! I hope they have a 'You Survived Climbing the Tallest Martian Volcano' T-shirt.", "Is it just me, or does this Martian dust stick to my wheels like glitter after a craft project?", "I wonder if there's a Mars version of Yelp for rating all these rocks. Some of them are really standouts.", "If there's life on Mars, I hope they appreciate my tire tracks as modern art.", "Note to self: Start a podcast. 'Rolling Through Mars with Courage.' Has a nice ring to it." };

    void Start()
    {
        StartCoroutine(Thoughts());
    }

    IEnumerator Thoughts()
    {
        while (true)
        {
            containerGameObject.SetActive(true);
            int ind = Random.Range(0, phrases.Length);
            interactTextMeshProUGUI.text = phrases[ind];
            yield return new WaitForSeconds(7);
            interactTextMeshProUGUI.text = interactTextMeshProUGUI.text + "z";
            yield return new WaitForSeconds(1);
            interactTextMeshProUGUI.text += "z";
            yield return new WaitForSeconds(1);
            interactTextMeshProUGUI.text += "z";
            yield return new WaitForSeconds(1);
            //yield return null
            containerGameObject.SetActive(false);
            // 35, 70
            yield return new WaitForSeconds(Random.Range(5, 10));
        }
    }
};
