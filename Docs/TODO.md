# ITER
[x] (1 sec) > "use mouse to look around"
[x] return the ashtray filling
[x] add a light switch mesh to the room
[] make the before.ending shorter
[x] door outline (is behind the door)
[x] promo quads' transparent parts are shown by the Secret Sauce shader
	[x] fix poster and vinyl record not being milked
	[x] fix all cutscenes involving the shader sauce
[x] raise the +3db ambient door club music
[x] end of correct.ending - add a black to white fade (0.5sec)
[x] reverse.ending
	[x] loop the phone ring
		[x] turn it off when the cutscene starts
	[x] add a cut phone ring to the start 
[x] show game title in every ending
[x] splash'es "DisIn" title is shared between the splash and the ending, and is placed ABOVE the fade
[] graphics cringe
	[] light / shadow leaks (shadow maps)
[] use headphones for the best experience
[] poster 0.01 alpha lag spike
[] bgm didn't start (hard to track down)
[] club geometry loading (profiling required)
[] crunch all club textures (check the 2d folder as well)
[] move all club assets to the Art/3d.Club folder
[] отписаться от всех событий из AppState

# TBD

## polish iter
[] performance
[] memory consumption
[] build size
[] move gitignore -> art/3d

## mobile iter
[] text size
[] joystick
[] tap to interact
[] rotate phone into horizontal

# INFO

## ideas
[] club ending - music playing from the phone
[] have the logo pop up during the endings
	[] neutral ending - disappearing in
	[] correct ending - disappearing in (track name)
	[] reverse ending - disappearing in (broken telephone)
[] club / correct ending
	[] развернуться и идти в выход в белый свет
	[] идти к сцене, смотря по сторонам (на коробки)
	[] projected image
	[] crunch textures
[] phone / reverse ending
	[] ideally: the door opens, the player walks out into the light
[] clutter disappearance
	[] make a movie w/ an empty-ish room
		[] mb add disappearance in the timeline
[] после последнего взаимодействия включить песню на месте с временем ровно до концовки
	[] на последнем действии музыка затихает
[] на постер приближение сделать подпев
[] performance ideas
[DENY] молоко
	[] твик vfx
	[] исчезновение цели взаимодействия
	

# COMPLETE
## v1
[x] room
	[x] lighting
	[x] fixes (floor, walls, lamp, cigs, books?, the door)
[x] Interactions
	[x] Bed
	[x] Window
	[x] Poster
	[x] Cigarettes
	[x] PC
[x] Neutral ending

## v2
[x] splash screen [1.5h>>3h]
	[x] white fade in
	[x] "press f to start"
	[] poster (i forgot what this point was about)
[x] sfx [3-6h] [blocked]
	[x] footsteps [>>1h]
	[x] room ambient
	[x] cigs
		[x] пачка сигарет
		[x] зажигалка
		[x] вдох / выдох, длинный (2s)
	[x] кровать
		[x] лечь на кровать
		[x] встать с кровати
	[x] poster
		[x] бумага
	[x] window
		[x] outside sfx
	[x] pc
		[x] кнопка
		[x] раскрутка пк / диска
		[deny] монитор
		[x] глюки
[x] interactions [3-6h]
	[x] pc fix
	[x] bed interaction improvement
	[i tweaked the ending but not sure that the issue got resolved] outro -> -5 sec
	[x] cigs -> bigger collider
[x] outline [1.5h]
	[x] suppress outline in cutscenes
	[ignore] outline flicker bug fix
[x] fog / milk
	[x] turn off free roam fog
[x] mouse sens x0.5 [0h]
[x] screen text [3-6h>>4h] [blocked]
	[x] ending tracker [3h>>1.5h]
	[x] in game font
	[x] show "wasd to move" - until moved 1 unit
	[x] show "f to interact" - on first raycast
	[x] inner monologue
		[x] (cutscene sends an event to TURN ON the text for x secs)
		[x] good / bad outcome text
[x] new room clutter [3h>>3h+]
	[x] ceiling plinthuses
	[x] vinyl record rotation
	[x] skateboard
	[x] fpressers stuff
	[x] ukulele
	[x] pen & notebook
	[x] pillows
	[x] vinyl records
		[x] di record
[x] webgl loader mechanism [1.5h>>0.5h]
	[x] посмотреть как работает
	[x] статья на хабре

## v3
[x] build size
	[] do smth about meshes, if willing
	[x] remove all ao, height (?!) maps
	[x] remove most metallic maps, try to remove normal maps
	[x] downres, crunch and cringe all textures as much as possible
[x] performance
	[x] test light bake [>>1.5h]
		* it works, but doesn't improve the performance that much
	[x] replace URP/Lit w/ URP/Simple Lit
		* tested on a test scene, didn't seem to improve performance that much
	[x] win laptop: windows -> graphics perforamnce -> firefox -> high performance
[x] game restart
	[x] restart state fix
[PART] graphics cringe
	[x] door wall scale
	[x] bed / plinthus fog interaction

## v4
[x] playtest
	[x] "WASD" > "W,A,S,D"
	[x] "press f to interact" every time
	[x] "WASD" -> "WASD keys"
[TMP] "bgm interrupted" sfx (vinyl scratch)
[x] club
	[x] preload club
	[x] ceiling white -> black (mb dark)
	[x] stage cables
	[x] bass guitar scene
	[DENY] try a cheap (additive) fog
	[POSSIBLE] laser machines?
		[] make a passable draft to showcase
	[x] more boxes (closer to the entrance)
	[x] paint stage back lights mesh
	[x] try to add more of a lightshow
	[x] add 2 more lights w/ a different color to the lightshow
[IMPOSSIBLE] rescue reverb
	[x] remove reverb and fix cutscenes that rely on it
		[x] Before.Ending
		[x] Neutral.Ending
[x] "change language" color white -> yellow
[x] door club ambience -> rise
[x] phone / reverse ending
	[x] cutscene / separate scene w/ the sfx?
		[x] phone ending
			[x] phone rings
			[x] interact w/ the phone
			[x] message plays
[x] reverse route text
[x] bed cutscene
	[x] longer female sample
[x] room gltf import
[x] some room objects are not getting milked
[ч] club / correct ending
	[x] level design
		[x] confetti / trash on the floor
		[x] instruments
		[x] room layout
	[x] cutscene: включается после порога
		камерой влетает к сцене
		[x] club ending
			[x] 3sec pause
			[x] stop bgm
			[x] turn on door interaction
			[x] player interacts w/ the door
		[x] cutscene
			[x] turn around
			[x] turn off the lights
				[x] sfx
			[x] open the door
				[x] sfx
			[x] enter the nightclub

			[x] подойти к сцене
			[x] посмотреть на надпись на проекторе
		[x] sfx
	[x] move assets to the Art/3d folder
[x] splash
	[x] language selection (splash)
	[x] remove logo from 3d poster -> move to splash ui
	[x] start hint -> 0.5 sec delay
[x] pc cutscene
	[x] pc di logo - +1-2 secs
	[x] overall add a +1 sec to every pc screen?
[x] remove all height maps
[x] intro cutscene
	[x] убрать hold в начале
[x] the poster is too slimy (skyrim-y)
[x] gay lame unknown bug, that lowers some white balance until the first interaction