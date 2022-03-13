# BarLauncher-Volume

Change/Set volume from bar launchers applications like Wox or Flow Launcher.

* **Home** : https://github.com/gissehel/BarLauncher-Volume
* **Keyword** : `vol`

# Installation

## For Wox

```
wpm install Change volume
```

## For Flow Launcher

Waiting for submission/approval...

# Usage

```
vol
```

![](doc/01_vol.png)

You can see that the current volume is **73**.

Let set it to **41**

```
vol set 41
```

![](doc/02_vol_set_41.png)

Validate the entry.

The bar disapear and the volume is indeed set to 41.

![](doc/03_system_volume_41.png)

Reopen the bar a try a *change*:

```
vol change 
```

![](doc/04_vol_change.png)

Note that the current volume is **41**.

Type `+`

```
vol change +
```

![](doc/05_vol_change_42.png)

The volume has increased to **42** (even without selecting the item).

You can then continue to add some +/- signs

```
vol change ++
```

![](doc/05_vol_change_43.png)

The volume has increased to **43**.

```
vol change +++
```

![](doc/05_vol_change_44.png)

The volume has increased to **44**.

```
vol change ++++
```

![](doc/05_vol_change_45.png)

The volume has increased to **45**.

```
vol change +++++
```

![](doc/05_vol_change_47.png)

The volume has increased to **47** and not **46**. When you're doing a sequence of the same change, after 4 change "by 1", it starts changing "by 2", "by 3", "by 4" and then all the subsquent changes are "by 5".

```
vol change ++++++
```

![](doc/05_vol_change_50.png)

The volume has increased to **50** (+3).

```
vol change +++++++
```

![](doc/05_vol_change_54.png)

The volume has increased to **54** (+4).

```
vol change ++++++++
```

![](doc/05_vol_change_59.png)

The volume has increased to **59** (+5).

```
vol change +++++++++
```

![](doc/05_vol_change_64.png)

The volume has increased to **64** (+5).

```
vol change ++++++++++
```

![](doc/05_vol_change_69.png)

The volume has increased to **69** (+5).


```
vol change ++++++++++-
```

![](doc/06_vol_change_68.png)

The volume has decreased to **68** (-1).

When the sens change, the step goes back to *1* (increase or decrease).

The change is adaptative.

## Quick usage

The parser will try to guess the best command you want if you don't specify the command's name.

If you type

```
vol 82
```

![](doc/07_vol_set_82.png)

The plugin understand you want to set the volume to 82


If you type 

```
vol +
```

The plugin understand you want to increment the volume, and will automatically rewrite your request to `vol change +`

```
vol change +
```

![](doc/08_vol_change_83.png)


