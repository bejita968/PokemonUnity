﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PokemonUnity;
using PokemonUnity.Interface;
using PokemonUnity.Attack.Data;
using PokemonUnity.Combat;
using PokemonUnity.Inventory;
using PokemonUnity.Overworld;
using PokemonEssentials.Interface;
using PokemonEssentials.Interface.Battle;
using PokemonEssentials.Interface.Item;
using PokemonEssentials.Interface.Field;
using PokemonEssentials.Interface.Screen;
using PokemonEssentials.Interface.PokeBattle;
using PokemonEssentials.Interface.PokeBattle.Effects;

namespace PokemonUnity.Interface.UnityEngine
{
	/// <summary>
	/// Entity exist for sole purpose of running coroutines,
	/// from a non-monobehavior class.
	/// </summary>
	public class CoroutineHost : global::UnityEngine.MonoBehaviour { }

	/// <summary>
	/// Uses current battle and manipulates the data then return the current battle with updated values.
	/// </summary>
	public abstract class PokeBattle_Move : PokemonUnity.Combat.PokeBattle_Move, IBattleMoveIE, IBattleMove, ICloneable
	{
		new public IBattleIE battle				{ get; set; }
		protected CoroutineHost _host;

		public PokeBattle_Move() : base() { _host = new global::UnityEngine.GameObject("CoroutineHost").AddComponent<CoroutineHost>(); }

		/// <summary>
		/// Remove instantiated game object from memory when done.
		/// </summary>
		~PokeBattle_Move()
		{
			if (_host != null)
			{
				_host.StopAllCoroutines();
				global::UnityEngine.Object.Destroy(_host);
			}
			_host = null;
		}

		//public PokeBattle_Move(Battle battle, Attack.Move move) : base(battle, move) { }

		public IBattleMoveIE initialize(IBattleIE battle, IMove move)
		{
			return (IBattleMoveIE)this.Initialize(battle, move);
		}

		public IBattleMoveIE FromMove(IBattleIE battle, IMove move)
		{
			return (IBattleMoveIE)Move.FromMove(battle, move);
		}

		#region Interface Implementation
		bool IBattleMoveIE.AccuracyCheck(IBattlerIE attacker, IBattlerIE opponent)
		{
			return AccuracyCheck(attacker, opponent);
		}

		void IBattleMoveIE.AdditionalEffect(IBattlerIE attacker, IBattlerIE opponent)
		{
			AdditionalEffect(attacker, opponent);
		}

		void IBattleMoveIE.AddTarget(IList<IBattlerIE> targets, IBattlerIE attacker)
		{
			AddTarget((IList<IBattler>)targets, attacker);
		}

		int IBattleMoveIE.BaseDamage(int basedmg, IBattlerIE attacker, IBattlerIE opponent)
		{
			return BaseDamage(basedmg, attacker, opponent);
		}

		double IBattleMoveIE.BaseDamageMultiplier(double damagemult, IBattlerIE attacker, IBattlerIE opponent)
		{
			return BaseDamageMultiplier(damagemult, attacker, opponent);
		}

		int IBattleMoveIE.CalcDamage(IBattlerIE attacker, IBattlerIE opponent, params byte[] options)
		{
			return CalcDamage(attacker, opponent, options);
		}

		bool IBattleMoveIE.CritialOverride(IBattlerIE attacker, IBattlerIE opponent)
		{
			return CritialOverride(attacker, opponent);
		}

		int IBattleMoveIE.DisplayUseMessage(IBattlerIE attacker)
		{
			return DisplayUseMessage(attacker);
		}

		int IBattleMove.GetEffect(IBattler attacker, IBattler opponent, int hitnum, int[] alltargets, bool showanimation)
		{
			return GetEffect(attacker, opponent, hitnum, alltargets, showanimation);
		}

		public virtual IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum, int[] alltargets, bool showanimation, System.Action<int> result = null)
		{
			int r = -1;
			r = base.GetEffect(attacker, opponent, hitnum, alltargets, showanimation);
			result(r);
			yield break;
		}

		public virtual IEnumerator EffectAfterHit(IBattlerIE attacker, IBattlerIE opponent, IEffectsMove turneffects)
		{
			base.EffectAfterHit(attacker, opponent, turneffects);
			yield break;
		}

		int IBattleMoveIE.EffectFixedDamage(int damage, IBattlerIE attacker, IBattlerIE opponent, int hitnum, int[] alltargets, bool showanimation)
		{
			return EffectFixedDamage(damage, attacker, opponent, hitnum, alltargets, showanimation);
		}

		void IBattleMoveIE.EffectMessages(IBattlerIE attacker, IBattlerIE opponent, bool ignoretype, int[] alltargets)
		{
			EffectMessages(attacker, opponent, ignoretype, alltargets);
		}

		bool IBattleMoveIE.IsCritical(IBattlerIE attacker, IBattlerIE opponent)
		{
			return IsCritical(attacker, opponent);
		}

		int IBattleMoveIE.ModifyBaseAccuracy(int baseaccuracy, IBattlerIE attacker, IBattlerIE opponent)
		{
			return ModifyBaseAccuracy(baseaccuracy, attacker, opponent);
		}

		double IBattleMoveIE.ModifyDamage(double damagemult, IBattlerIE attacker, IBattlerIE opponent)
		{
			return ModifyDamage(damagemult, attacker, opponent);
		}

		Types IBattleMoveIE.ModifyType(Types type, IBattlerIE attacker, IBattlerIE opponent)
		{
			return ModifyType(type, attacker, opponent);
		}

		bool IBattleMoveIE.MoveFailed(IBattlerIE attacker, IBattlerIE opponent)
		{
			return MoveFailed(attacker, opponent);
		}

		int IBattleMoveIE.NumHits(IBattlerIE attacker)
		{
			return NumHits(attacker);
		}

		void IBattleMoveIE.OnDamageLost(int damage, IBattlerIE attacker, IBattlerIE opponent)
		{
			OnDamageLost(damage, attacker, opponent);
		}

		bool IBattleMoveIE.OnStartUse(IBattlerIE attacker)
		{
			return OnStartUse(attacker);
		}

		int IBattleMoveIE.GetPriority(IBattlerIE attacker)
		{
			return GetPriority(attacker);
		}

		int IBattleMoveIE.ReduceHPDamage(int damage, IBattlerIE attacker, IBattlerIE opponent)
		{
			return ReduceHPDamage(damage, attacker, opponent);
		}

		public virtual IEnumerator ShowAnimation(Moves id, IBattlerIE attacker, IBattlerIE opponent, int hitnum, int[] alltargets, bool showanimation)
		{
			base.ShowAnimation(id, attacker, opponent, hitnum, alltargets, showanimation);
			yield break;
		}

		bool IBattleMoveIE.TargetsMultiple(IBattlerIE attacker)
		{
			return TargetsMultiple(attacker);
		}

		bool IBattleMoveIE.TwoTurnAttack(IBattlerIE attacker)
		{
			return TwoTurnAttack(attacker);
		}

		Types IBattleMoveIE.GetType(Types type, IBattlerIE attacker, IBattlerIE opponent)
		{
			return GetType(type, attacker, opponent);
		}

		bool IBattleMoveIE.TypeImmunityByAbility(Types type, IBattlerIE attacker, IBattlerIE opponent)
		{
			return TypeImmunityByAbility(type, attacker, opponent);
		}

		float IBattleMoveIE.TypeModifier(Types type, IBattlerIE attacker, IBattlerIE opponent)
		{
			return TypeModifier(type, attacker, opponent);
		}

		double IBattleMoveIE.TypeModMessages(Types type, IBattlerIE attacker, IBattlerIE opponent)
		{
			return TypeModMessages(type, attacker, opponent);
		}

		bool IBattleMoveIE.ignoresSubstitute(IBattlerIE attacker)
		{
			return ignoresSubstitute(attacker);
		}
		#endregion
	}

	// <summary>
	// During battle, the moves used are modified by these classes before calculations are applied
	// </summary>
#pragma warning disable 0162 //Warning CS0162  Unreachable code detected
	// ToDo: Rename from PokemonEssential's Function to Veekun's Attack.Effects
	// https://essentialsdocs.fandom.com/wiki/Function_codes
	#region Battle Class Functions
	/// <summary>
	/// Superclass that handles moves using a non-existent function code.
	/// Damaging moves just do damage with no additional effect.
	/// Non-damaging moves always fail.
	/// <summary>
	public partial class PokeBattle_UnimplementedMove : PokeBattle_Move
	{
		public PokeBattle_UnimplementedMove() : base() { }
		//public PokeBattle_UnimplementedMove(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (IsDamaging()) {
				int reti = -1; _host.StartCoroutine(base.GetEffect(attacker, opponent, hitnum, alltargets, showanimation, result:value=>reti=value)); result(reti);
				yield break;
			} else {
				_host.StartCoroutine(battle.Display("But it failed!"));
				result(-1);
				yield break;
			}
		}
	}

	/// <summary>
	/// Superclass for a failed move. Always fails.
	/// This class is unused.
	/// <summary>
	public partial class PokeBattle_FailedMove : PokeBattle_Move
	{
		public PokeBattle_FailedMove() : base() { }
		//public PokeBattle_FailedMove(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			_host.StartCoroutine(battle.Display("But it failed!"));
			result(-1);
			yield break;
		}
	}

	/// <summary>
	/// Pseudomove for confusion damage.
	/// <summary>
	public partial class PokeBattle_Confusion : PokeBattle_Move
	{
		public PokeBattle_Confusion() : base() { }
		//public PokeBattle_Confusion(Battle battle, Attack.Move move) : base(battle, move) { Initialize(battle, move); }
		public override IBattleMove Initialize(IBattle battle, IMove move)
		{
			this.battle	= (IBattleIE)battle;
			Power		= 40;
			type		= Types.NONE;
			accuracy	= 100;
			PP			= 0;//null
			//AddlEffect	= 0;
			//target		= 0;
			//priority	= 0;
			//flags		= 0;
			thismove	= move;
			//name		= "";
			MoveId		= Moves.NONE;
			id			= Moves.CONFUSION; //Used for name

			return this;
		}

		//public override bool IsPhysical	{ get { return true; } }
		//public override bool IsSpecial	{ get { return false; } }

		public int CalcDamage(IBattlerIE attacker, IBattlerIE opponent)
		{
			return base.CalcDamage(attacker, opponent, new byte[] {
				Core.NOCRITICAL, Core.SELFCONFUSE, Core.NOTYPE, Core.NOWEIGHTING });
		}

		public void EffectMessages(IBattlerIE attacker, IBattlerIE opponent, bool ignoretype = false)
		{
			base.EffectMessages(attacker, opponent, true);
		}
	}

	/// <summary>
	/// Implements the move Struggle.
	/// For cases where the real move named Struggle is not defined.
	/// <summary>
	public partial class PokeBattle_Struggle : PokeBattle_Move
	{
		public PokeBattle_Struggle() : base() { }
		//public PokeBattle_Struggle(Battle battle, Attack.Move move) : base(battle, move) { Initialize(battle, move); }
		public override IBattleMove Initialize(IBattle battle, IMove move)
		{
			MoveId		= Moves.NONE;    // doesn't work if 0
			this.battle	= (IBattleIE)battle;
			//name		= Game._INTL("Struggle");
			id			= Moves.STRUGGLE; //Used for name
			Power		= 50;
			type		= Types.NONE;
			accuracy	= 0;
			//AddlEffect	= 0;
			//target		= 0;
			//priority	= 0;
			//flags		= 0;
			thismove	= null;   // not associated with a move
			PP			= 0;//null
			TotalPP		= 0;

			if (move.id != Moves.NONE)
			{
				MoveId = move.id;
				//name	= Game._INTL(id.ToString(TextScripts.Name));
			}
			return this;
		}

		//public override bool IsPhysical() { return true; }
		//public override bool IsSpecial() { return false; }

		public override void EffectAfterHit(IBattler attacker, IBattler opponent, IEffectsMove turneffects) { this.EffectAfterHit((IBattlerIE)attacker, (IBattlerIE)opponent, turneffects); }
		public override IEnumerator EffectAfterHit(IBattlerIE attacker, IBattlerIE opponent, IEffectsMove turneffects)
		{
			if (!attacker.isFainted() && turneffects.TotalDamage > 0)
			{
				attacker.ReduceHP((int)Math.Round(attacker.TotalHP / 4.0f));
				_host.StartCoroutine(battle.Display(Game._INTL("{1} is damaged by recoil!", attacker.ToString())));
			}
			yield break;
		}

		public int CalcDamage(IBattler attacker, IBattler opponent)
		{
			return base.CalcDamage(attacker, opponent, Core.IGNOREPKMNTYPES);
		}
	}

	/// <summary>
	/// No additional effect.
	/// <summary>
	public partial class PokeBattle_Move_000 : PokeBattle_Move
	{
		public PokeBattle_Move_000() : base() { }
		//public PokeBattle_Move_000(Battle battle, Attack.Move move) : base(battle, move) { }
	}

	/// <summary>
	/// Does absolutely nothing. (Splash)
	/// <summary>
	public partial class PokeBattle_Move_001 : PokeBattle_Move
	{
		public PokeBattle_Move_001() : base() { }
		//public PokeBattle_Move_001(Battle battle, Attack.Move move) : base(battle, move) { }
		public override bool UnusableInGravity()
		{
			//get
			//{
				return true;
			//}
		}

		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			_host.StartCoroutine(ShowAnimation(this.id, attacker, null, hitnum, alltargets, showanimation));
			_host.StartCoroutine(battle.Display(Game._INTL("But nothing happened!")));
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// Struggle. Overrides the default Struggle effect above.
	/// <summary>
	public partial class PokeBattle_Move_002 : PokeBattle_Struggle
	{
		public PokeBattle_Move_002() : base() { }
		//public PokeBattle_Move_002(Battle battle, Attack.Move move) : base(battle, move) { }
	}

	/// <summary>
	/// Puts the target to sleep.
	/// <summary>
	public partial class PokeBattle_Move_003 : PokeBattle_Move
	{
		public PokeBattle_Move_003() : base() { }
		//public PokeBattle_Move_003(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (IsDamaging()) { int reti = -1; _host.StartCoroutine(base.GetEffect(attacker, opponent, hitnum, alltargets, showanimation, result:value=>reti=value)); result(reti); yield break; }
			if (TypeImmunityByAbility(GetType(this.type, attacker, opponent), attacker, opponent)) { result(-1); yield break; }
			if (opponent is IBattlerClause b && b.CanSleep(attacker, true, this))
			{
				_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));

				if (opponent is IBattlerEffectIE o) _host.StartCoroutine(o.Sleep());
				result(0);
				yield break;
			}
			result(-1);
			yield break;
		}

		public override void AdditionalEffect(IBattler attacker, IBattler opponent)
		{
			if (opponent.damagestate.Substitute) return;
			if (opponent is IBattlerClause b && b.CanSleep(attacker, false, this))
			{
				if (opponent is IBattlerEffectIE o) _host.StartCoroutine(o.Sleep());
			}
		}

		public override void EffectAfterHit(IBattler attacker, IBattler opponent, IEffectsMove turneffects) { this.EffectAfterHit((IBattlerIE)attacker, (IBattlerIE)opponent, turneffects); }
		public override IEnumerator EffectAfterHit(IBattlerIE attacker, IBattlerIE opponent, IEffectsMove turneffects)
		{
			if (id == Moves.RELIC_SONG)
			{
				if (attacker.Species == Pokemons.MELOETTA &&
					!attacker.effects.Transform &&
					!(attacker.hasWorkingAbility(Abilities.SHEER_FORCE) && this.AddlEffect > 0) &&
					!attacker.isFainted())
				{
					attacker.form = (attacker.form + 1) % 2;
					attacker.Update(true);
					if (this.battle.scene is IPokeBattle_Scene s0) s0.ChangePokemon(attacker, attacker.pokemon);
					_host.StartCoroutine(battle.Display(Game._INTL("{1} transformed!", attacker.ToString())));
					GameDebug.Log($"[Form changed] #{attacker.ToString()} changed to form #{Game._INTL((attacker as Pokemon).Form.Pokemon.ToString(TextScripts.Name))}");
				}
			}
			yield break;
		}
	}

	/// <summary>
	/// Makes the target drowsy; it will fall asleep at the end of the next turn. (Yawn)
	/// <summary>
	public partial class PokeBattle_Move_004 : PokeBattle_Move
	{
		public PokeBattle_Move_004() : base() { }
		//public PokeBattle_Move_004(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (opponent is IBattlerClause b && !b.CanSleep(attacker, true, this)) { result(-1); yield break; }
			if (opponent.effects.Yawn > 0)
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));

			opponent.effects.Yawn = 2;
			_host.StartCoroutine(battle.Display(Game._INTL("{1} made {2} drowsy!", attacker.ToString(), opponent.ToString(true))));
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// Poisons the target.
	/// <summary>
	public partial class PokeBattle_Move_005 : PokeBattle_Move
	{
		public PokeBattle_Move_005() : base() { }
		//public PokeBattle_Move_005(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (IsDamaging()) { int reti = -1; _host.StartCoroutine(base.GetEffect(attacker, opponent, hitnum, alltargets, showanimation, result:value=>reti=value)); result(reti); yield break; }
			if (opponent is IBattlerEffectIE b) { bool retb = false; _host.StartCoroutine(b.CanPoison(attacker, true, this, result:value=>retb=value)); if (!retb) { result(-1); yield break; } }
			_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));

			if (opponent is IBattlerEffectIE o) _host.StartCoroutine(o.Poison(attacker));
			result(0);
			yield break;
		}

		public override void AdditionalEffect(IBattler attacker, IBattler opponent)
		{
			if (opponent.damagestate.Substitute) return;
			if (opponent is IBattlerEffect b && b.CanPoison(attacker, false, this))
			{
				b.Poison(attacker);
			}
		}
	}

	/// <summary>
	/// Badly poisons the target. (Poison Fang, Toxic)
	/// (Handled in Pokemon's SuccessCheck): Hits semi-invulnerable targets if user
	/// is Poison-type and move is status move.
	/// <summary>
	public partial class PokeBattle_Move_006 : PokeBattle_Move
	{
		public PokeBattle_Move_006() : base() { }
		//public PokeBattle_Move_006(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (IsDamaging()) { int reti = -1; _host.StartCoroutine(base.GetEffect(attacker, opponent, hitnum, alltargets, showanimation, result:value=>reti=value)); result(reti); yield break; }
			if (opponent is IBattlerEffectIE b) { bool retb = false; _host.StartCoroutine(b.CanPoison(attacker, true, this, result:value=>retb=value)); if (!retb) { result(-1); yield break; } }
			_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));

			if (opponent is IBattlerEffectIE o) _host.StartCoroutine(o.Poison(attacker, null, true));
			result(0);
			yield break;
		}

		public override void AdditionalEffect(IBattler attacker, IBattler opponent)
		{
			if (opponent.damagestate.Substitute) return;
			if (opponent is IBattlerEffect b && b.CanPoison(attacker, false, this))
			{
				b.Poison(attacker, null, true);
			}
		}
	}

	/// <summary>
	/// Paralyzes the target.
	/// Thunder Wave: Doesn't affect target if move's type has no effect on it.
	/// Bolt Strike: Powers up the next Fusion Flare used this round.
	/// <summary>
	public partial class PokeBattle_Move_007 : PokeBattle_Move
	{
		public PokeBattle_Move_007() : base() { }
		//public PokeBattle_Move_007(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (IsDamaging())
			{
				int ret = -1; _host.StartCoroutine(base.GetEffect(attacker, opponent, hitnum, alltargets, showanimation, result:value=>ret=value)); result(ret);
				if (opponent.damagestate.CalcDamage > 0 && id == Moves.BOLT_STRIKE)
				{
					this.battle.field.FusionFlare = true;
				}
				result(ret);
				yield break;
			}
			else
			{
				if (this.id == Moves.THUNDER_WAVE)
				{
					if (TypeModifier(type, attacker, opponent) == 0)
					{
						_host.StartCoroutine(battle.Display(Game._INTL("It doesn't affect {1}...", opponent.ToString(true))));
						result(-1);
						yield break;
					}
				}
				if (TypeImmunityByAbility(GetType(this.type, attacker, opponent), attacker, opponent)) { result(-1); yield break; }
				if (opponent is IBattlerEffectIE b) { bool retb = false; _host.StartCoroutine(b.CanParalyze(attacker, true, this, result:value=>retb=value)); if (!retb) { result(-1); yield break; } }
				_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));

				if (opponent is IBattlerEffectIE o) _host.StartCoroutine(o.Paralyze(attacker));
				result(0);
				yield break;
			}
			//return -1
		}

		public override void AdditionalEffect(IBattler attacker, IBattler opponent)
		{
			if (opponent.damagestate.Substitute) return;
			if (opponent is IBattlerEffect b && b.CanParalyze(attacker, false, this))
			{
				b.Paralyze(attacker);
			}
		}
	}

	/// <summary>
	/// Paralyzes the target. Accuracy perfect in rain, 50% in sunshine. (Thunder)
	/// (Handled in Pokemon's SuccessCheck): Hits some semi-invulnerable targets.
	/// <summary>
	public partial class PokeBattle_Move_008 : PokeBattle_Move
	{
		public PokeBattle_Move_008() : base() { }
		//public PokeBattle_Move_008(Battle battle, Attack.Move move) : base(battle, move) { }
		public override void AdditionalEffect(IBattler attacker, IBattler opponent)
		{
			if (opponent.damagestate.Substitute) return;
			if (opponent is IBattlerEffect b && b.CanParalyze(attacker, false, this))
			{
				b.Paralyze(attacker);
			}
		}

		public int ModifyBaseAccuracy(byte baseaccuracy, IBattler attacker, IBattler opponent)
		{
			switch (this.battle.Weather)
			{
				case Weather.RAINDANCE:
				case Weather.HEAVYRAIN:
					return 0;
				case Weather.SUNNYDAY:
				case Weather.HARSHSUN:
					return 50;
				default:
					return baseaccuracy;
			}
		}
	}

	/// <summary>
	/// Paralyzes the target. May cause the target to flinch. (Thunder Fang)
	/// <summary>
	public partial class PokeBattle_Move_009 : PokeBattle_Move
	{
		public PokeBattle_Move_009() : base() { }
		//public PokeBattle_Move_009(Battle battle, Attack.Move move) : base(battle, move) { }
		public override void AdditionalEffect(IBattler attacker, IBattler opponent)
		{
			if (opponent.damagestate.Substitute) return;
			if (this.battle.Random(10) == 0)
			{
				if (opponent is IBattlerEffect b && b.CanParalyze(attacker, false, this))
				{
					b.Paralyze(attacker);
				}
			}

			if (this.battle.Random(10) == 0)
			{
				if (opponent is IBattlerEffectIE o) o.Flinch(attacker);
			}
		}
	}

	/// <summary>
	/// Burns the target.
	/// Blue Flare: Powers up the next Fusion Bolt used this round.
	/// <summary>
	public partial class PokeBattle_Move_00A : PokeBattle_Move
	{
		public PokeBattle_Move_00A() : base() { }
		//public PokeBattle_Move_00A(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (IsDamaging())
			{
				int ret = -1; _host.StartCoroutine(base.GetEffect(attacker, opponent, hitnum, alltargets, showanimation, result:value=>ret=value)); result(ret);
				if (opponent.damagestate.CalcDamage > 0 && id == Moves.BLUE_FLARE)
				{
					this.battle.field.FusionBolt = true;
				}
				result(ret);
				yield break;
			}
			else
			{
				if (TypeImmunityByAbility(GetType(this.type, attacker, opponent), attacker, opponent)) { result(-1); yield break; }
				if (opponent is IBattlerEffectIE b) { bool retb = false; _host.StartCoroutine(b.CanBurn(attacker, true, this, result:value=>retb=value)); if (!retb) { result(-1); yield break; } }
				_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));

				if (opponent is IBattlerEffectIE o) _host.StartCoroutine(o.Burn(attacker));
				result(0);
				yield break;
			}
			//return -1;
		}

		public override void AdditionalEffect(IBattler attacker, IBattler opponent)
		{
			if (opponent.damagestate.Substitute) return;
			if (opponent is IBattlerEffect b && b.CanBurn(attacker, false, this))
			{
				b.Burn(attacker);
			}
		}
	}

	/// <summary>
	/// Burns the target. May cause the target to flinch. (Fire Fang)
	/// <summary>
	public partial class PokeBattle_Move_00B : PokeBattle_Move
	{
		public PokeBattle_Move_00B() : base() { }
		//public PokeBattle_Move_00B(Battle battle, Attack.Move move) : base(battle, move) { }
		public override void AdditionalEffect(IBattler attacker, IBattler opponent)
		{
			if (opponent.damagestate.Substitute) return;
			if (this.battle.Random(10) == 0)
			{
				if (opponent is IBattlerEffect b && b.CanBurn(attacker, false, this))
				{
					b.Burn(attacker);
				}

			}
			if (this.battle.Random(10) == 0)
			{
				if (opponent is IBattlerEffectIE o) o.Flinch(attacker);
			}
		}
	}

	/// <summary>
	/// Freezes the target.
	/// <summary>
	public partial class PokeBattle_Move_00C : PokeBattle_Move
	{
		public PokeBattle_Move_00C() : base() { }
		//public PokeBattle_Move_00C(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (IsDamaging()) { int reti = -1; _host.StartCoroutine(base.GetEffect(attacker, opponent, hitnum, alltargets, showanimation, result:value=>reti=value)); result(reti); yield break; }
			if (opponent is IBattlerClause b && !b.CanFreeze(attacker, true, this)) { result(-1); yield break; }
			_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));

			if (opponent is IBattlerEffectIE o) _host.StartCoroutine(o.Freeze());
			result(0);
			yield break;
		}

		public override void AdditionalEffect(IBattler attacker, IBattler opponent)
		{
			if (opponent.damagestate.Substitute) return;
			if (opponent is IBattlerClause b && b.CanFreeze(attacker, false, this))
			{
				if (opponent is IBattlerEffectIE o) _host.StartCoroutine(o.Freeze());
			}
		}
	}

	/// <summary>
	/// Freezes the target. Accuracy perfect in hail. (Blizzard)
	/// <summary>
	public partial class PokeBattle_Move_00D : PokeBattle_Move
	{
		public PokeBattle_Move_00D() : base() { }
		//public PokeBattle_Move_00D(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (IsDamaging()) { int reti = -1; _host.StartCoroutine(base.GetEffect(attacker, opponent, hitnum, alltargets, showanimation, result:value=>reti=value)); result(reti); yield break; }
			if (opponent is IBattlerClause b && !b.CanFreeze(attacker, true, this)) { result(-1); yield break; }
			_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));

			if (opponent is IBattlerEffectIE o) _host.StartCoroutine(o.Freeze());
			result(0);
			yield break;
		}

		public override void AdditionalEffect(IBattler attacker, IBattler opponent)
		{
			if (opponent.damagestate.Substitute) return;
			if (opponent is IBattlerClause b && b.CanFreeze(attacker, false, this))
			{
				if (opponent is IBattlerEffectIE o) _host.StartCoroutine(o.Freeze());
			}
		}

		public int ModifyBaseAccuracy(byte baseaccuracy, IBattler attacker, IBattler opponent)
		{
			if (this.battle.Weather == Weather.HAIL)
			{
				return 0;
			}
			return baseaccuracy;
		}
	}

	/// <summary>
	/// Freezes the target. May cause the target to flinch. (Ice Fang)
	/// <summary>
	public partial class PokeBattle_Move_00E : PokeBattle_Move
	{
		public PokeBattle_Move_00E() : base() { }
		//public PokeBattle_Move_00E(Battle battle, Attack.Move move) : base(battle, move) { }
		public override void AdditionalEffect(IBattler attacker, IBattler opponent)
		{
			if (opponent.damagestate.Substitute) return;
			if (this.battle.Random(10) == 0)
			{
				if (opponent is IBattlerClause b && b.CanFreeze(attacker, false, this))
				{
					if (opponent is IBattlerEffectIE o) _host.StartCoroutine(o.Freeze());
				}

			}
			if (this.battle.Random(10) == 0)
			{
				if (opponent is IBattlerEffectIE o) o.Flinch(attacker);
			}
		}
	}

	/// <summary>
	/// Causes the target to flinch.
	/// <summary>
	public partial class PokeBattle_Move_00F : PokeBattle_Move
	{
		public PokeBattle_Move_00F() : base() { }
		//public PokeBattle_Move_00F(Battle battle, Attack.Move move) : base(battle, move) { }
		public override void AdditionalEffect(IBattler attacker, IBattler opponent)
		{
			if (opponent.damagestate.Substitute) return;
			if (opponent is IBattlerEffectIE o) o.Flinch(attacker);
		}
	}

	/// <summary>
	/// Causes the target to flinch. Does double damage and has perfect accuracy if
	/// the target is Minimized.
	/// <summary>
	public partial class PokeBattle_Move_010 : PokeBattle_Move
	{
		public PokeBattle_Move_010() : base() { }
		//public PokeBattle_Move_010(Battle battle, Attack.Move move) : base(battle, move) { }
		public override void AdditionalEffect(IBattler attacker, IBattler opponent)
		{
			if (opponent.damagestate.Substitute) return;
			if (opponent is IBattlerEffectIE o) o.Flinch(attacker);
		}

		public bool tramplesMinimize(byte param = 1)
		{
			if (id == Moves.DRAGON_RUSH && !Core.USENEWBATTLEMECHANICS) return false;
			if (param == 1 && Core.USENEWBATTLEMECHANICS) return true; // Perfect accuracy
			if (param == 2) return true; // Double damage
			return false;
		}
	}

	/// <summary>
	/// Causes the target to flinch. Fails if the user is not asleep. (Snore)
	/// <summary>
	public partial class PokeBattle_Move_011 : PokeBattle_Move
	{
		public PokeBattle_Move_011() : base() { }
		//public PokeBattle_Move_011(Battle battle, Attack.Move move) : base(battle, move) { }
		public override bool CanUseWhileAsleep()
		{
			return true;
		}

		public override bool MoveFailed(IBattler attacker, IBattler opponent)
		{
			return (attacker.Status != Status.SLEEP);
		}

		public override void AdditionalEffect(IBattler attacker, IBattler opponent)
		{
			if (opponent.damagestate.Substitute) return;
			if (opponent is IBattlerEffectIE o) o.Flinch(attacker);
		}
	}

	/// <summary>
	/// Causes the target to flinch. Fails if this isn't the user's first turn. (Fake Out)
	/// <summary>
	public partial class PokeBattle_Move_012 : PokeBattle_Move
	{
		public PokeBattle_Move_012() : base() { }
		//public PokeBattle_Move_012(Battle battle, Attack.Move move) : base(battle, move) { }
		public override bool MoveFailed(IBattler attacker, IBattler opponent)
		{
			return (attacker.turncount > 1);
		}

		public override void AdditionalEffect(IBattler attacker, IBattler opponent)
		{
			if (opponent.damagestate.Substitute) return;
			if (opponent is IBattlerEffectIE o) o.Flinch(attacker);
		}
	}

	/// <summary>
	/// Confuses the target.
	/// <summary>
	public partial class PokeBattle_Move_013 : PokeBattle_Move
	{
		public PokeBattle_Move_013() : base() { }
		//public PokeBattle_Move_013(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (IsDamaging()) { int reti = -1; _host.StartCoroutine(base.GetEffect(attacker, opponent, hitnum, alltargets, showanimation, result:value=>reti=value)); result(reti); yield break; }
			if (opponent is IBattlerEffect b && b.CanConfuse(attacker, true, this))
			{
				_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));

				b.Confuse();
				_host.StartCoroutine(battle.Display(Game._INTL("{1} became confused!", opponent.ToString())));
				result(0);
				yield break;
			}
			result(-1);
			yield break;
		}

		public override void AdditionalEffect(IBattler attacker, IBattler opponent)
		{
			if (opponent.damagestate.Substitute) return;
			if (opponent is IBattlerEffect b && b.CanConfuse(attacker, false, this))
			{
				b.Confuse();
				_host.StartCoroutine(battle.Display(Game._INTL("{1} became confused!", opponent.ToString())));
			}
		}
	}

	/// <summary>
	/// Confuses the target. Chance of causing confusion depends on the cry's volume.
	/// Confusion chance is 0% if user doesn't have a recorded cry. (Chatter)
	/// TODO: Play the actual chatter cry as part of the move animation
	///       this.battle.scene.Chatter(attacker,opponent) // Just plays cry
	/// <summary>
	public partial class PokeBattle_Move_014 : PokeBattle_Move
	{
		public PokeBattle_Move_014() : base() { }
		//public PokeBattle_Move_014(Battle battle, Attack.Move move) : base(battle, move) { }
		private IBattler attacker; //ToDo: use AdditionalEffect(IBattler attacker, IBattler opponent) to assign?
		public override int AddlEffect
		{
			get
			{
				if (Core.USENEWBATTLEMECHANICS) return 100;
				if (attacker.pokemon.IsNotNullOrNone() && attacker.pokemon is IPokemonChatter a && a.chatter != null) {
					return a.chatter.intensity() * 10 / 127;
				}
				return 0;
			}
		}

		public override void AdditionalEffect(IBattler attacker, IBattler opponent)
		{
			if (opponent.damagestate.Substitute) return;
			if (opponent is IBattlerEffect b && b.CanConfuse(attacker, false, this))
			{
				b.Confuse();
				_host.StartCoroutine(battle.Display(Game._INTL("{1} became confused!", opponent.ToString())));
			}
		}
	}

	/// <summary>
	/// Confuses the target. Accuracy perfect in rain, 50% in sunshine. (Hurricane)
	/// (Handled in Pokemon's SuccessCheck): Hits some semi-invulnerable targets.
	/// <summary>
	public partial class PokeBattle_Move_015 : PokeBattle_Move
	{
		public PokeBattle_Move_015() : base() { }
		//public PokeBattle_Move_015(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (IsDamaging()) { int reti = -1; _host.StartCoroutine(base.GetEffect(attacker, opponent, hitnum, alltargets, showanimation, result:value=>reti=value)); result(reti); yield break; }
			if (opponent is IBattlerEffect b && b.CanConfuse(attacker, true, this))
			{
				_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));

				b.Confuse();
				_host.StartCoroutine(battle.Display(Game._INTL("{1} became confused!", opponent.ToString())));
				result(0);
				yield break;
			}
			result(-1);
			yield break;
		}

		public override void AdditionalEffect(IBattler attacker, IBattler opponent)
		{
			if (opponent.damagestate.Substitute) return;
			if (opponent is IBattlerEffect b && b.CanConfuse(attacker, false, this))
			{
				b.Confuse();
				_host.StartCoroutine(battle.Display(Game._INTL("{1} became confused!", opponent.ToString())));
			}
		}

		public int ModifyBaseAccuracy(byte baseaccuracy, IBattler attacker, IBattler opponent)
		{
			switch (this.battle.Weather)
			{
				case Weather.RAINDANCE:
				case Weather.HEAVYRAIN:
					return 0;
				case Weather.SUNNYDAY:
				case Weather.HARSHSUN:
					return 50;
				default:
					return baseaccuracy;
			}
		}
	}

	/// <summary>
	/// Attracts the target. (Attract)
	/// <summary>
	public partial class PokeBattle_Move_016 : PokeBattle_Move
	{
		public PokeBattle_Move_016() : base() { }
		//public PokeBattle_Move_016(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (opponent is IBattlerEffect b && !b.CanAttract(attacker))
			{
				result(-1);
				yield break;
			}
			if (!attacker.hasMoldBreaker())
			{
				if (opponent.hasWorkingAbility(Abilities.AROMA_VEIL))
				{
					_host.StartCoroutine(battle.Display(Game._INTL("But it failed because of {1}'s {2}!",
					   opponent.ToString(), Game._INTL(opponent.Ability.ToString(TextScripts.Name)))));
					result(-1);
					yield break;
				}
				else if (opponent.Partner.hasWorkingAbility(Abilities.AROMA_VEIL))
				{

					_host.StartCoroutine(battle.Display(Game._INTL("But it failed because of {1}'s {2}!",
					   opponent.Partner.ToString(), Game._INTL(opponent.Partner.Ability.ToString(TextScripts.Name)))));
					result(-1);
					yield break;
				}
			}

			_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));

			if (opponent is IBattlerEffectIE o) _host.StartCoroutine(o.Attract(attacker));
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// Burns, freezes or paralyzes the target. (Tri Attack)
	/// <summary>
	public partial class PokeBattle_Move_017 : PokeBattle_Move
	{
		public PokeBattle_Move_017() : base() { }
		//public PokeBattle_Move_017(Battle battle, Attack.Move move) : base(battle, move) { }
		public override void AdditionalEffect(IBattler attacker, IBattler opponent)
		{
			if (opponent.damagestate.Substitute) return;
			//switch (this.battle.Random(3))
			//{
				if (this.battle.Random(3) == 0) //case 0:
					if (opponent is IBattlerEffectIE b0)
					{
						bool ret = false; _host.StartCoroutine(b0.CanBurn(attacker, false, this, result: value => ret = value)); if(ret)
							_host.StartCoroutine(b0.Burn(attacker));
					}
					//break;
				if (this.battle.Random(3) == 1) //case 1:
					if (opponent is IBattlerClause b1 && b1.CanFreeze(attacker, false, this))
					{
						if (b1 is IBattlerEffectIE o) _host.StartCoroutine(o.Freeze());
					}
					//break;
				if (this.battle.Random(3) == 2) //case 2:
					if (opponent is IBattlerEffect b2 && b2.CanParalyze(attacker, false, this))
					{
						b2.Paralyze(attacker);
					}
					//break;
			//}
		}
	}

	/// <summary>
	/// Cures user of burn, poison and paralysis. (Refresh)
	/// <summary>
	public partial class PokeBattle_Move_018 : PokeBattle_Move
	{
		public PokeBattle_Move_018() : base() { }
		//public PokeBattle_Move_018(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (attacker.Status != Status.BURN &&
			   attacker.Status != Status.POISON &&
			   attacker.Status != Status.PARALYSIS)
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			else
			{
				Status t = attacker.Status;
				if (attacker is IBattlerEffectIE a) _host.StartCoroutine(a.CureStatus(false));

				_host.StartCoroutine(ShowAnimation(this.id, attacker, null, hitnum, alltargets, showanimation));
				if (t == Status.BURN)
				{
					_host.StartCoroutine(battle.Display(Game._INTL("{1} healed its burn!", attacker.ToString())));
				}
				else if (t == Status.POISON)
				{
					_host.StartCoroutine(battle.Display(Game._INTL("{1} cured its poisoning!", attacker.ToString())));
				}
				else if (t == Status.PARALYSIS)
				{
					_host.StartCoroutine(battle.Display(Game._INTL("{1} cured its paralysis!", attacker.ToString())));
				}
				result(0);
				yield break;
			}
		}
	}

	/// <summary>
	/// Cures all party Pokémon of permanent status problems. (Aromatherapy, Heal Bell)
	/// <summary>
	public partial class PokeBattle_Move_019 : PokeBattle_Move
	{
		public PokeBattle_Move_019() : base() { }
		//public PokeBattle_Move_019(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{

			_host.StartCoroutine(ShowAnimation(this.id, attacker, null, hitnum, alltargets, showanimation));
			if (id == Moves.AROMATHERAPY)
			{
				_host.StartCoroutine(battle.Display(Game._INTL("A soothing aroma wafted through the area!")));
			}
			else
			{
				_host.StartCoroutine(battle.Display(Game._INTL("A bell chimed!")));
			}
			IList<int> activepkmn = new List<int>();
			foreach (IBattler i in this.battle.battlers)
			{
				if (attacker.IsOpposing(i.Index) || i.isFainted()) continue; //next
				activepkmn.Add(i.pokemonIndex);

				if (Core.USENEWBATTLEMECHANICS && i.Index != attacker.Index &&
				   TypeImmunityByAbility(GetType(this.type, attacker, i), attacker, i)) continue; //next
				switch (i.Status)
				{
					case Status.PARALYSIS:
						_host.StartCoroutine(battle.Display(Game._INTL("{1} was cured of paralysis.", i.ToString())));
						break;
					case Status.SLEEP:
						_host.StartCoroutine(battle.Display(Game._INTL("{1}'s sleep was woken.", i.ToString())));
						break;
					case Status.POISON:
						_host.StartCoroutine(battle.Display(Game._INTL("{1} was cured of its poisoning.", i.ToString())));
						break;
					case Status.BURN:
						_host.StartCoroutine(battle.Display(Game._INTL("{1}'s burn was healed.", i.ToString())));
						break;
					case Status.FROZEN:
						_host.StartCoroutine(battle.Display(Game._INTL("{1} was thawed out.", i.ToString())));
						break;
					default: break;
				}
				if (i is IBattlerEffectIE b) _host.StartCoroutine(b.CureStatus(false));

			}
			IPokemon[] party = this.battle.Party(attacker.Index); // NOTE: Considers both parties in multi battles
			for (int i = 0; i < party.Length; i++)
			{
				if (activepkmn.Contains(i)) continue; //next
				if (party[i].Species == Pokemons.NONE || party[i].isEgg || party[i].HP <= 0) continue; //next
				switch (party[i].Status)
				{
					case Status.PARALYSIS:
						_host.StartCoroutine(battle.Display(Game._INTL("{1} was cured of paralysis.", party[i].ToString())));
						break;
					case Status.SLEEP:
						_host.StartCoroutine(battle.Display(Game._INTL("{1} was woken from its sleep.", party[i].ToString())));
						break;
					case Status.POISON:
						_host.StartCoroutine(battle.Display(Game._INTL("{1} was cured of its poisoning.", party[i].ToString())));
						break;
					case Status.BURN:
						_host.StartCoroutine(battle.Display(Game._INTL("{1}'s burn was healed.", party[i].ToString())));
						break;
					case Status.FROZEN:
						_host.StartCoroutine(battle.Display(Game._INTL("{1} was thawed out.", party[i].ToString())));
						break;
					default:
						break;
				}
				party[i].Status = Status.NONE;
				party[i].StatusCount = 0; //Done automatically
			}
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// Safeguards the user's side from being inflicted with status problems. (Safeguard)
	/// <summary>
	public partial class PokeBattle_Move_01A : PokeBattle_Move
	{
		public PokeBattle_Move_01A() : base() { }
		//public PokeBattle_Move_01A(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (attacker.OwnSide.Safeguard > 0)
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			attacker.OwnSide.Safeguard = 5;

			_host.StartCoroutine(ShowAnimation(this.id, attacker, null, hitnum, alltargets, showanimation));
			if (!this.battle.IsOpposing(attacker.Index))
			{
				_host.StartCoroutine(battle.Display(Game._INTL("Your team became cloaked in a mystical veil!")));
			}
			else
			{
				_host.StartCoroutine(battle.Display(Game._INTL("The opposing team became cloaked in a mystical veil!")));
			}
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// User passes its status problem to the target. (Psycho Shift)
	/// <summary>
	public partial class PokeBattle_Move_01B : PokeBattle_Move
	{
		public PokeBattle_Move_01B() : base() { }
		//public PokeBattle_Move_01B(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (attacker.Status == 0 || (opponent is IBattlerEffect b &&
				(
				  (attacker.Status == Status.PARALYSIS && !b.CanParalyze(attacker, false, this)) ||
				  (attacker.Status == Status.POISON && !b.CanPoison(attacker, false, this)) ||
				  (attacker.Status == Status.BURN && !b.CanBurn(attacker, false, this)) ||
				  (attacker.Status == Status.SLEEP && opponent is IBattlerClause b1 && !b1.CanSleep(attacker, false, this)) ||
				  (attacker.Status == Status.FROZEN && opponent is IBattlerClause b2 && !b2.CanFreeze(attacker, false, this))
				)))
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			IBattlerEffect a = attacker is IBattlerEffect ? attacker as IBattlerEffect : null;
			IBattlerEffect o = opponent is IBattlerEffect ? opponent as IBattlerEffect : null;
			_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));
			switch (attacker.Status)
			{
				case Status.PARALYSIS:
					o?.Paralyze(attacker);

					_host.StartCoroutine(opponent.AbilityCureCheck());
					a?.CureStatus(false);

					_host.StartCoroutine(battle.Display(Game._INTL("{1} was cured of paralysis.", attacker.ToString())));
					break;
				case Status.SLEEP:
					o?.Sleep();
					_host.StartCoroutine(opponent.AbilityCureCheck());
					a?.CureStatus(false);

					_host.StartCoroutine(battle.Display(Game._INTL("{1} woke up.", attacker.ToString())));
					break;
				case Status.POISON:
					o?.Poison(attacker, null, attacker.StatusCount != 0);

					_host.StartCoroutine(opponent.AbilityCureCheck());
					a?.CureStatus(false);

					_host.StartCoroutine(battle.Display(Game._INTL("{1} was cured of its poisoning.", attacker.ToString())));
					break;
				case Status.BURN:
					o?.Burn(attacker);
					_host.StartCoroutine(opponent.AbilityCureCheck());
					a?.CureStatus(false);

					_host.StartCoroutine(battle.Display(Game._INTL("{1}'s burn was healed.", attacker.ToString())));
					break;
				case Status.FROZEN:
					o?.Freeze();
					_host.StartCoroutine(opponent.AbilityCureCheck());
					a?.CureStatus(false);

					_host.StartCoroutine(battle.Display(Game._INTL("{1} was thawed out.", attacker.ToString())));
					break;
			}
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// Increases the user's Attack by 1 stage.
	/// <summary>
	public partial class PokeBattle_Move_01C : PokeBattle_Move
	{
		public PokeBattle_Move_01C() : base() { }
		//public PokeBattle_Move_01C(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (IsDamaging()) { int ret1 = -1; _host.StartCoroutine(base.GetEffect(attacker, opponent, hitnum, alltargets, showanimation, result:value=>ret1=value)); result(ret1); yield break; }
			if (attacker is IBattlerEffectIE b) { bool retb = false; _host.StartCoroutine(b.CanIncreaseStatStage(Stats.ATTACK, attacker, true, this, result:value=>retb=value)); if (!retb) { result(-1); yield break; } }
			_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));

			bool ret = false; //attacker.IncreaseStat(Stats.ATTACK, 1, attacker, false, this);
			if (attacker is IBattlerEffectIE a) _host.StartCoroutine(a.IncreaseStat(Stats.ATTACK, 1, attacker, false, this, result: value => ret = value));
			result(ret ? 0 : -1);
			yield break;
		}

		public override void AdditionalEffect(IBattler attacker, IBattler opponent)
		{
			if (attacker is IBattlerEffect b && b.CanIncreaseStatStage(Stats.ATTACK, attacker, false, this))
			{
				b.IncreaseStat(Stats.ATTACK, 1, attacker, false, this);
			}
		}
	}

	/// <summary>
	/// Increases the user's Defense by 1 stage.
	/// <summary>
	public partial class PokeBattle_Move_01D : PokeBattle_Move
	{
		public PokeBattle_Move_01D() : base() { }
		//public PokeBattle_Move_01D(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (IsDamaging()) { int reti = -1; _host.StartCoroutine(base.GetEffect(attacker, opponent, hitnum, alltargets, showanimation, result:value=>reti=value)); result(reti); yield break; }
			if (attacker is IBattlerEffectIE b) { bool retb = false; _host.StartCoroutine(b.CanIncreaseStatStage(Stats.DEFENSE, attacker, true, this, result:value=>retb=value)); if (!retb) { result(-1); yield break; } }
			_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));

			bool ret = false; //attacker.IncreaseStat(Stats.DEFENSE, 1, attacker, false, this);
			if (attacker is IBattlerEffectIE a) _host.StartCoroutine(a.IncreaseStat(Stats.DEFENSE, 1, attacker, false, this, result: value => ret = value));
			result(ret ? 0 : -1);
			yield break;
		}

		public override void AdditionalEffect(IBattler attacker, IBattler opponent)
		{
			if (attacker is IBattlerEffect b && b.CanIncreaseStatStage(Stats.DEFENSE, attacker, false, this))
			{
				b.IncreaseStat(Stats.DEFENSE, 1, attacker, false, this);
			}
		}
	}

	/// <summary>
	/// Increases the user's Defense by 1 stage. User curls up. (Defense Curl)
	/// <summary>
	public partial class PokeBattle_Move_01E : PokeBattle_Move
	{
		public PokeBattle_Move_01E() : base() { }
		//public PokeBattle_Move_01E(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{

			attacker.effects.DefenseCurl = true;
			if (attacker is IBattlerEffectIE b) { bool retb = false; _host.StartCoroutine(b.CanIncreaseStatStage(Stats.DEFENSE, attacker, true, this, result:value=>retb=value)); if (!retb) { result(-1); yield break; } }
			_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));

			bool ret = false; //attacker.IncreaseStat(Stats.DEFENSE, 1, attacker, false, this);
			if (attacker is IBattlerEffectIE a) _host.StartCoroutine(a.IncreaseStat(Stats.DEFENSE, 1, attacker, false, this, result: value => ret = value));
			result(ret ? 0 : -1);
			yield break;
		}
	}

	/// <summary>
	/// Increases the user's Speed by 1 stage.
	/// <summary>
	public partial class PokeBattle_Move_01F : PokeBattle_Move
	{
		public PokeBattle_Move_01F() : base() { }
		//public PokeBattle_Move_01F(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (IsDamaging()) { int reti = -1; _host.StartCoroutine(base.GetEffect(attacker, opponent, hitnum, alltargets, showanimation, result:value=>reti=value)); result(reti); yield break; }
			if (attacker is IBattlerEffectIE b) { bool retb = false; _host.StartCoroutine(b.CanIncreaseStatStage(Stats.SPEED, attacker, true, this, result:value=>retb=value)); if (!retb) { result(-1); yield break; } }
			_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));

			bool ret = false; //attacker.IncreaseStat(Stats.SPEED, 1, attacker, false, this);
			if (attacker is IBattlerEffectIE a) _host.StartCoroutine(a.IncreaseStat(Stats.SPEED, 1, attacker, false, this, result: value => ret = value));
			result(ret ? 0 : -1);
			yield break;
		}

		public override void AdditionalEffect(IBattler attacker, IBattler opponent)
		{
			if (attacker is IBattlerEffect b && b.CanIncreaseStatStage(Stats.SPEED, attacker, false, this))
			{
				b.IncreaseStat(Stats.SPEED, 1, attacker, false, this);
			}
		}
	}

	/// <summary>
	/// Increases the user's Special Attack by 1 stage.
	/// <summary>
	public partial class PokeBattle_Move_020 : PokeBattle_Move
	{
		public PokeBattle_Move_020() : base() { }
		//public PokeBattle_Move_020(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (IsDamaging()) { int reti = -1; _host.StartCoroutine(base.GetEffect(attacker, opponent, hitnum, alltargets, showanimation, result:value=>reti=value)); result(reti); yield break; }
			if (attacker is IBattlerEffectIE b) { bool retb = false; _host.StartCoroutine(b.CanIncreaseStatStage(Stats.SPATK, attacker, true, this, result:value=>retb=value)); if (!retb) { result(-1); yield break; } }
			_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));

			bool ret = false; //attacker.IncreaseStat(Stats.SPATK, 1, attacker, false, this);
			if (attacker is IBattlerEffectIE a) _host.StartCoroutine(a.IncreaseStat(Stats.SPATK, 1, attacker, false, this, result: value => ret = value));
			result(ret ? 0 : -1);
			yield break;
		}

		public override void AdditionalEffect(IBattler attacker, IBattler opponent)
		{
			if (attacker is IBattlerEffect b && b.CanIncreaseStatStage(Stats.SPATK, attacker, false, this))
			{
				b.IncreaseStat(Stats.SPATK, 1, attacker, false, this);
			}
		}
	}

	/// <summary>
	/// Increases the user's Special Defense by 1 stage.
	/// Charges up user's next attack if it is Electric-type. (Charge)
	/// <summary>
	public partial class PokeBattle_Move_021 : PokeBattle_Move
	{
		public PokeBattle_Move_021() : base() { }
		//public PokeBattle_Move_021(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{

			attacker.effects.Charge = 2;
			_host.StartCoroutine(battle.Display(Game._INTL("{1} began charging power!", attacker.ToString())));
			if (attacker is IBattlerEffect b && b.CanIncreaseStatStage(Stats.SPDEF, attacker, true, this))
			{
				_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));

				b.IncreaseStat(Stats.SPDEF, 1, attacker, false, this);
			}
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// Increases the user's evasion by 1 stage.
	/// <summary>
	public partial class PokeBattle_Move_022 : PokeBattle_Move
	{
		public PokeBattle_Move_022() : base() { }
		//public PokeBattle_Move_022(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (IsDamaging()) { int reti = -1; _host.StartCoroutine(base.GetEffect(attacker, opponent, hitnum, alltargets, showanimation, result:value=>reti=value)); result(reti); yield break; }
			if (attacker is IBattlerEffectIE b) { bool retb = false; _host.StartCoroutine(b.CanIncreaseStatStage(Stats.EVASION, attacker, true, this, result:value=>retb=value)); if (!retb) { result(-1); yield break; } }
			_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));

			bool ret = false; //attacker.IncreaseStat(Stats.EVASION, 1, attacker, false, this);
			if (attacker is IBattlerEffectIE a) _host.StartCoroutine(a.IncreaseStat(Stats.EVASION, 1, attacker, false, this, result: value => ret = value));
			result(ret ? 0 : -1);
			yield break;
		}

		public override void AdditionalEffect(IBattler attacker, IBattler opponent)
		{
			if (attacker is IBattlerEffect b && b.CanIncreaseStatStage(Stats.EVASION, attacker, false, this))
			{
				b.IncreaseStat(Stats.EVASION, 1, attacker, false, this);
			}
		}
	}

	/// <summary>
	/// Increases the user's critical hit rate. (Focus Energy)
	/// <summary>
	public partial class PokeBattle_Move_023 : PokeBattle_Move
	{
		public PokeBattle_Move_023() : base() { }
		//public PokeBattle_Move_023(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (IsDamaging()) { int reti = -1; _host.StartCoroutine(base.GetEffect(attacker, opponent, hitnum, alltargets, showanimation, result:value=>reti=value)); result(reti); yield break; }
			if (attacker.effects.FocusEnergy >= 2)
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));

			attacker.effects.FocusEnergy = 2;
			_host.StartCoroutine(battle.Display(Game._INTL("{1} is getting pumped!", attacker.ToString())));
			result(0);
			yield break;
		}

		public override void AdditionalEffect(IBattler attacker, IBattler opponent)
		{
			if (attacker.effects.FocusEnergy < 2)
			{
				attacker.effects.FocusEnergy = 2;
				_host.StartCoroutine(battle.Display(Game._INTL("{1} is getting pumped!", attacker.ToString())));
			}
		}
	}

	/// <summary>
	/// Increases the user's Attack and Defense by 1 stage each. (Bulk Up)
	/// <summary>
	public partial class PokeBattle_Move_024 : PokeBattle_Move
	{
		public PokeBattle_Move_024() : base() { }
		//public PokeBattle_Move_024(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (attacker is IBattlerEffect b &&
				!b.CanIncreaseStatStage(Stats.ATTACK, attacker, false, this) &&
				!b.CanIncreaseStatStage(Stats.DEFENSE, attacker, false, this))
			{
				_host.StartCoroutine(battle.Display(Game._INTL("{1}'s stats won't go any higher!", attacker.ToString())));
				result(-1);
				yield break;
			}
			_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));

			bool showanim = true;
			if (attacker is IBattlerEffect b0 && b0.CanIncreaseStatStage(Stats.ATTACK, attacker, false, this))
			{
				b0.IncreaseStat(Stats.ATTACK, 1, attacker, false, this, showanim);
				showanim = false;
			}
			if (attacker is IBattlerEffect b1 && b1.CanIncreaseStatStage(Stats.DEFENSE, attacker, false, this))
			{
				b1.IncreaseStat(Stats.DEFENSE, 1, attacker, false, this, showanim);
				showanim = false;
			}
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// Increases the user's Attack, Defense and accuracy by 1 stage each. (Coil)
	/// <summary>
	public partial class PokeBattle_Move_025 : PokeBattle_Move
	{
		public PokeBattle_Move_025() : base() { }
		//public PokeBattle_Move_025(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (attacker is IBattlerEffect b &&
				!b.CanIncreaseStatStage(Stats.ATTACK, attacker, false, this) &&
				!b.CanIncreaseStatStage(Stats.DEFENSE, attacker, false, this) &&
				!b.CanIncreaseStatStage(Stats.ACCURACY, attacker, false, this))
			{
				_host.StartCoroutine(battle.Display(Game._INTL("{1}'s stats won't go any higher!", attacker.ToString())));
				result(-1);
				yield break;
			}
			_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));

			bool showanim = true;
			if (attacker is IBattlerEffect b0 && b0.CanIncreaseStatStage(Stats.ATTACK, attacker, false, this))
			{
				b0.IncreaseStat(Stats.ATTACK, 1, attacker, false, this, showanim);
				showanim = false;
			}
			if (attacker is IBattlerEffect b1 && b1.CanIncreaseStatStage(Stats.DEFENSE, attacker, false, this))
			{
				b1.IncreaseStat(Stats.DEFENSE, 1, attacker, false, this, showanim);
				showanim = false;
			}
			if (attacker is IBattlerEffect b2 && b2.CanIncreaseStatStage(Stats.ACCURACY, attacker, false, this))
			{
				b2.IncreaseStat(Stats.ACCURACY, 1, attacker, false, this, showanim);
				showanim = false;
			}
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// Increases the user's Attack and Speed by 1 stage each. (Dragon Dance)
	/// <summary>
	public partial class PokeBattle_Move_026 : PokeBattle_Move
	{
		public PokeBattle_Move_026() : base() { }
		//public PokeBattle_Move_026(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (attacker is IBattlerEffect b &&
				!b.CanIncreaseStatStage(Stats.ATTACK, attacker, false, this) &&
				!b.CanIncreaseStatStage(Stats.SPEED, attacker, false, this))
			{
				_host.StartCoroutine(battle.Display(Game._INTL("{1}'s stats won't go any higher!", attacker.ToString())));
				result(-1);
				yield break;
			}
			_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));

			bool showanim = true;
			if (attacker is IBattlerEffect b0 && b0.CanIncreaseStatStage(Stats.ATTACK, attacker, false, this))
			{
				b0.IncreaseStat(Stats.ATTACK, 1, attacker, false, this, showanim);
				showanim = false;
			}
			if (attacker is IBattlerEffect b1 && b1.CanIncreaseStatStage(Stats.SPEED, attacker, false, this))
			{
				b1.IncreaseStat(Stats.SPEED, 1, attacker, false, this, showanim);
				showanim = false;
			}
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// Increases the user's Attack and Special Attack by 1 stage each. (Work Up)
	/// <summary>
	public partial class PokeBattle_Move_027 : PokeBattle_Move
	{
		public PokeBattle_Move_027() : base() { }
		//public PokeBattle_Move_027(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (attacker is IBattlerEffect b &&
				!b.CanIncreaseStatStage(Stats.ATTACK, attacker, false, this) &&
				!b.CanIncreaseStatStage(Stats.SPATK, attacker, false, this))
			{
				_host.StartCoroutine(battle.Display(Game._INTL("{1}'s stats won't go any higher!", attacker.ToString())));
				result(-1);
				yield break;
			}
			_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));

			bool showanim = true;
			if (attacker is IBattlerEffect b0 && b0.CanIncreaseStatStage(Stats.ATTACK, attacker, false, this))
			{
				b0.IncreaseStat(Stats.ATTACK, 1, attacker, false, this, showanim);
				showanim = false;
			}
			if (attacker is IBattlerEffect b1 && b1.CanIncreaseStatStage(Stats.SPATK, attacker, false, this))
			{
				b1.IncreaseStat(Stats.SPATK, 1, attacker, false, this, showanim);
				showanim = false;
			}
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// Increases the user's Attack and Sp. Attack by 1 stage each.
	/// In sunny weather, increase is 2 stages each instead. (Growth)
	/// <summary>
	public partial class PokeBattle_Move_028 : PokeBattle_Move
	{
		public PokeBattle_Move_028() : base() { }
		//public PokeBattle_Move_028(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (attacker is IBattlerEffect b &&
				!b.CanIncreaseStatStage(Stats.ATTACK, attacker, false, this) &&
				!b.CanIncreaseStatStage(Stats.SPATK, attacker, false, this))
			{
				_host.StartCoroutine(battle.Display(Game._INTL("{1}'s stats won't go any higher!", attacker.ToString())));
				result(-1);
				yield break;
			}
			_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));

			bool showanim = true;
			byte increment = 1;
			if (this.battle.Weather == Weather.SUNNYDAY ||
			   this.battle.Weather == Weather.HARSHSUN)
			{
				increment = 2;

			}
			if (attacker is IBattlerEffect b0 && b0.CanIncreaseStatStage(Stats.ATTACK, attacker, false, this))
			{
				b0.IncreaseStat(Stats.ATTACK, increment, attacker, false, this, showanim);
				showanim = false;
			}
			if (attacker is IBattlerEffect b1 && b1.CanIncreaseStatStage(Stats.SPATK, attacker, false, this))
			{
				b1.IncreaseStat(Stats.SPATK, increment, attacker, false, this, showanim);
				showanim = false;
			}
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// Increases the user's Attack and accuracy by 1 stage each. (Hone Claws)
	/// <summary>
	public partial class PokeBattle_Move_029 : PokeBattle_Move
	{
		public PokeBattle_Move_029() : base() { }
		//public PokeBattle_Move_029(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (attacker is IBattlerEffect b &&
				!b.CanIncreaseStatStage(Stats.ATTACK, attacker, false, this) &&
				!b.CanIncreaseStatStage(Stats.ACCURACY, attacker, false, this))
			{
				_host.StartCoroutine(battle.Display(Game._INTL("{1}'s stats won't go any higher!", attacker.ToString())));
				result(-1);
				yield break;
			}
			_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));

			bool showanim = true;
			if (attacker is IBattlerEffect b0 && b0.CanIncreaseStatStage(Stats.ATTACK, attacker, false, this))
			{
				b0.IncreaseStat(Stats.ATTACK, 1, attacker, false, this, showanim);
				showanim = false;
			}
			if (attacker is IBattlerEffect b1 && b1.CanIncreaseStatStage(Stats.ACCURACY, attacker, false, this))
			{
				b1.IncreaseStat(Stats.ACCURACY, 1, attacker, false, this, showanim);
				showanim = false;
			}
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// Increases the user's Defense and Special Defense by 1 stage each. (Cosmic Power)
	/// <summary>
	public partial class PokeBattle_Move_02A : PokeBattle_Move
	{
		public PokeBattle_Move_02A() : base() { }
		//public PokeBattle_Move_02A(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (attacker is IBattlerEffect b &&
				!b.CanIncreaseStatStage(Stats.DEFENSE, attacker, false, this) &&
				!b.CanIncreaseStatStage(Stats.SPDEF, attacker, false, this))
			{
				_host.StartCoroutine(battle.Display(Game._INTL("{1}'s stats won't go any higher!", attacker.ToString())));
				result(-1);
				yield break;
			}
			_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));

			bool showanim = true;
			if (attacker is IBattlerEffect b0 && b0.CanIncreaseStatStage(Stats.DEFENSE, attacker, false, this))
			{
				b0.IncreaseStat(Stats.DEFENSE, 1, attacker, false, this, showanim);
				showanim = false;
			}
			if (attacker is IBattlerEffect b1 && b1.CanIncreaseStatStage(Stats.SPDEF, attacker, false, this))
			{
				b1.IncreaseStat(Stats.SPDEF, 1, attacker, false, this, showanim);
				showanim = false;
			}
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// Increases the user's Sp. Attack, Sp. Defense and Speed by 1 stage each. (Quiver Dance)
	/// <summary>
	public partial class PokeBattle_Move_02B : PokeBattle_Move
	{
		public PokeBattle_Move_02B() : base() { }
		//public PokeBattle_Move_02B(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (attacker is IBattlerEffect b &&
				!b.CanIncreaseStatStage(Stats.SPATK, attacker, false, this) &&
				!b.CanIncreaseStatStage(Stats.SPDEF, attacker, false, this) &&
				!b.CanIncreaseStatStage(Stats.SPEED, attacker, false, this))
			{
				_host.StartCoroutine(battle.Display(Game._INTL("{1}'s stats won't go any higher!", attacker.ToString())));
				result(-1);
				yield break;
			}
			_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));

			bool showanim = true;
			if (attacker is IBattlerEffect b0 && b0.CanIncreaseStatStage(Stats.SPATK, attacker, false, this))
			{
				b0.IncreaseStat(Stats.SPATK, 1, attacker, false, this, showanim);
				showanim = false;
			}
			if (attacker is IBattlerEffect b1 && b1.CanIncreaseStatStage(Stats.SPDEF, attacker, false, this))
			{
				b1.IncreaseStat(Stats.SPDEF, 1, attacker, false, this, showanim);
				showanim = false;
			}
			if (attacker is IBattlerEffect b2 && b2.CanIncreaseStatStage(Stats.SPEED, attacker, false, this))
			{
				b2.IncreaseStat(Stats.SPEED, 1, attacker, false, this, showanim);
				showanim = false;
			}
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// Increases the user's Sp. Attack and Sp. Defense by 1 stage each. (Calm Mind)
	/// <summary>
	public partial class PokeBattle_Move_02C : PokeBattle_Move
	{
		public PokeBattle_Move_02C() : base() { }
		//public PokeBattle_Move_02C(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (attacker is IBattlerEffect b &&
				!b.CanIncreaseStatStage(Stats.SPATK, attacker, false, this) &&
				!b.CanIncreaseStatStage(Stats.SPDEF, attacker, false, this))
			{
				_host.StartCoroutine(battle.Display(Game._INTL("{1}'s stats won't go any higher!", attacker.ToString())));
				result(-1);
				yield break;
			}
			_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));

			bool showanim = true;
			if (attacker is IBattlerEffect b0 && b0.CanIncreaseStatStage(Stats.SPATK, attacker, false, this))
			{
				b0.IncreaseStat(Stats.SPATK, 1, attacker, false, this, showanim);
				showanim = false;
			}
			if (attacker is IBattlerEffect b1 && b1.CanIncreaseStatStage(Stats.SPDEF, attacker, false, this))
			{
				b1.IncreaseStat(Stats.SPDEF, 1, attacker, false, this, showanim);
				showanim = false;
			}
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// Increases the user's Attack, Defense, Speed, Special Attack and Special Defense
	/// by 1 stage each. (AncientPower, Ominous Wind, Silver Wind)
	/// <summary>
	public partial class PokeBattle_Move_02D : PokeBattle_Move
	{
		public PokeBattle_Move_02D() : base() { }
		//public PokeBattle_Move_02D(Battle battle, Attack.Move move) : base(battle, move) { }
		public override void AdditionalEffect(IBattler attacker, IBattler opponent)
		{

			bool showanim = true;
			if (attacker is IBattlerEffect b0 && b0.CanIncreaseStatStage(Stats.ATTACK, attacker, false, this))
			{
				b0.IncreaseStat(Stats.ATTACK, 1, attacker, false, this, showanim);
				showanim = false;
			}
			if (attacker is IBattlerEffect b1 && b1.CanIncreaseStatStage(Stats.DEFENSE, attacker, false, this))
			{
				b1.IncreaseStat(Stats.DEFENSE, 1, attacker, false, this, showanim);
				showanim = false;
			}
			if (attacker is IBattlerEffect b2 && b2.CanIncreaseStatStage(Stats.SPATK, attacker, false, this))
			{
				b2.IncreaseStat(Stats.SPATK, 1, attacker, false, this, showanim);
				showanim = false;
			}
			if (attacker is IBattlerEffect b3 && b3.CanIncreaseStatStage(Stats.SPDEF, attacker, false, this))
			{
				b3.IncreaseStat(Stats.SPDEF, 1, attacker, false, this, showanim);
				showanim = false;
			}
			if (attacker is IBattlerEffect b4 && b4.CanIncreaseStatStage(Stats.SPEED, attacker, false, this))
			{
				b4.IncreaseStat(Stats.SPEED, 1, attacker, false, this, showanim);
				showanim = false;
			}
		}
	}

	/// <summary>
	/// Increases the user's Attack by 2 stages.
	/// <summary>
	public partial class PokeBattle_Move_02E : PokeBattle_Move
	{
		public PokeBattle_Move_02E() : base() { }
		//public PokeBattle_Move_02E(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (IsDamaging()) { int reti = -1; _host.StartCoroutine(base.GetEffect(attacker, opponent, hitnum, alltargets, showanimation, result:value=>reti=value)); result(reti); yield break; }
			if (attacker is IBattlerEffectIE b) { bool retb = false; _host.StartCoroutine(b.CanIncreaseStatStage(Stats.ATTACK, attacker, true, this, result:value=>retb=value)); if (!retb) { result(-1); yield break; } }
			_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));

			bool ret = attacker is IBattlerEffect a && a.IncreaseStat(Stats.ATTACK, 2, attacker, false, this);
			result(ret ? 0 : -1);
			yield break;
		}

		public override void AdditionalEffect(IBattler attacker, IBattler opponent)
		{
			if (attacker is IBattlerEffect b && b.CanIncreaseStatStage(Stats.ATTACK, attacker, false, this))
			{
				b.IncreaseStat(Stats.ATTACK, 2, attacker, false, this);
			}
		}
	}

	/// <summary>
	/// Increases the user's Defense by 2 stages.
	/// <summary>
	public partial class PokeBattle_Move_02F : PokeBattle_Move
	{
		public PokeBattle_Move_02F() : base() { }
		//public PokeBattle_Move_02F(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (IsDamaging()) { int reti = -1; _host.StartCoroutine(base.GetEffect(attacker, opponent, hitnum, alltargets, showanimation, result:value=>reti=value)); result(reti); yield break; }
			if (attacker is IBattlerEffectIE b) { bool retb = false; _host.StartCoroutine(b.CanIncreaseStatStage(Stats.DEFENSE, attacker, true, this, result:value=>retb=value)); if (!retb) { result(-1); yield break; } }
			_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));

			bool ret = attacker is IBattlerEffect a && a.IncreaseStat(Stats.DEFENSE, 2, attacker, false, this);
			result(ret ? 0 : -1);
			yield break;
		}

		public override void AdditionalEffect(IBattler attacker, IBattler opponent)
		{
			if (attacker is IBattlerEffect b && b.CanIncreaseStatStage(Stats.DEFENSE, attacker, false, this))
			{
				b.IncreaseStat(Stats.DEFENSE, 2, attacker, false, this);
			}
		}
	}

	/// <summary>
	/// Increases the user's Speed by 2 stages.
	/// <summary>
	public partial class PokeBattle_Move_030 : PokeBattle_Move
	{
		public PokeBattle_Move_030() : base() { }
		//public PokeBattle_Move_030(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (IsDamaging()) { int reti = -1; _host.StartCoroutine(base.GetEffect(attacker, opponent, hitnum, alltargets, showanimation, result:value=>reti=value)); result(reti); yield break; }
			if (attacker is IBattlerEffectIE b) { bool retb = false; _host.StartCoroutine(b.CanIncreaseStatStage(Stats.SPEED, attacker, true, this, result:value=>retb=value)); if (!retb) { result(-1); yield break; } }
			_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));

			bool ret = attacker is IBattlerEffect a && a.IncreaseStat(Stats.SPEED, 2, attacker, false, this);
			result(ret ? 0 : -1);
			yield break;
		}

		public override void AdditionalEffect(IBattler attacker, IBattler opponent)
		{
			if (attacker is IBattlerEffect b && b.CanIncreaseStatStage(Stats.SPEED, attacker, false, this))
			{
				b.IncreaseStat(Stats.SPEED, 2, attacker, false, this);
			}
		}
	}

	/// <summary>
	/// Increases the user's Speed by 2 stages. Lowers user's weight by 100kg. (Autotomize)
	/// <summary>
	public partial class PokeBattle_Move_031 : PokeBattle_Move
	{
		public PokeBattle_Move_031() : base() { }
		//public PokeBattle_Move_031(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (attacker is IBattlerEffectIE b) { bool retb = false; _host.StartCoroutine(b.CanIncreaseStatStage(Stats.SPEED, attacker, true, this, result:value=>retb=value)); if (!retb) { result(-1); yield break; } }
			_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));

			bool ret = attacker is IBattlerEffect a && a.IncreaseStat(Stats.SPEED, 2, attacker, false, this);
			if (ret)
			{
				attacker.effects.WeightChange -= 1000;

				_host.StartCoroutine(battle.Display(Game._INTL("{1} became nimble!", attacker.ToString())));
			}
			result(ret ? 0 : -1);
			yield break;
		}
	}

	/// <summary>
	/// Increases the user's Special Attack by 2 stages.
	/// <summary>
	public partial class PokeBattle_Move_032 : PokeBattle_Move
	{
		public PokeBattle_Move_032() : base() { }
		//public PokeBattle_Move_032(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (IsDamaging()) { int reti = -1; _host.StartCoroutine(base.GetEffect(attacker, opponent, hitnum, alltargets, showanimation, result:value=>reti=value)); result(reti); yield break; }
			if (attacker is IBattlerEffectIE b) { bool retb = false; _host.StartCoroutine(b.CanIncreaseStatStage(Stats.SPATK, attacker, true, this, result:value=>retb=value)); if (!retb) { result(-1); yield break; } }
			_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));

			bool ret = attacker is IBattlerEffect a && a.IncreaseStat(Stats.SPATK, 2, attacker, false, this);
			result(ret ? 0 : -1);
			yield break;
		}

		public override void AdditionalEffect(IBattler attacker, IBattler opponent)
		{
			if (attacker is IBattlerEffect b && b.CanIncreaseStatStage(Stats.SPATK, attacker, false, this))
			{
				b.IncreaseStat(Stats.SPATK, 2, attacker, false, this);
			}
		}
	}

	/// <summary>
	/// Increases the user's Special Defense by 2 stages.
	/// <summary>
	public partial class PokeBattle_Move_033 : PokeBattle_Move
	{
		public PokeBattle_Move_033() : base() { }
		//public PokeBattle_Move_033(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (IsDamaging()) { int reti = -1; _host.StartCoroutine(base.GetEffect(attacker, opponent, hitnum, alltargets, showanimation, result:value=>reti=value)); result(reti); yield break; }
			if (attacker is IBattlerEffectIE b) { bool retb = false; _host.StartCoroutine(b.CanIncreaseStatStage(Stats.SPDEF, attacker, true, this, result:value=>retb=value)); if (!retb) { result(-1); yield break; } }
			_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));

			bool ret = attacker is IBattlerEffect a && a.IncreaseStat(Stats.SPDEF, 2, attacker, false, this);
			result(ret ? 0 : -1);
			yield break;
		}

		public override void AdditionalEffect(IBattler attacker, IBattler opponent)
		{
			if (attacker is IBattlerEffect b && b.CanIncreaseStatStage(Stats.SPDEF, attacker, false, this))
			{
				b.IncreaseStat(Stats.SPDEF, 2, attacker, false, this);
			}
		}
	}

	/// <summary>
	/// Increases the user's evasion by 2 stages. Minimizes the user. (Minimize)
	/// <summary>
	public partial class PokeBattle_Move_034 : PokeBattle_Move
	{
		public PokeBattle_Move_034() : base() { }
		//public PokeBattle_Move_034(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (IsDamaging()) { int reti = -1; _host.StartCoroutine(base.GetEffect(attacker, opponent, hitnum, alltargets, showanimation, result:value=>reti=value)); result(reti); yield break; }
			attacker.effects.Minimize = true;
			if (attacker is IBattlerEffectIE b) { bool retb = false; _host.StartCoroutine(b.CanIncreaseStatStage(Stats.EVASION, attacker, true, this, result:value=>retb=value)); if (!retb) { result(-1); yield break; } }

			_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));

			bool ret = attacker is IBattlerEffect a && a.IncreaseStat(Stats.EVASION, 2, attacker, false, this);
			result(ret ? 0 : -1);
			yield break;
		}

		public override void AdditionalEffect(IBattler attacker, IBattler opponent)
		{

			attacker.effects.Minimize = true;
			if (attacker is IBattlerEffect b && b.CanIncreaseStatStage(Stats.EVASION, attacker, false, this))
			{
				b.IncreaseStat(Stats.EVASION, 2, attacker, false, this);
			}
		}
	}

	/// <summary>
	/// Decreases the user's Defense and Special Defense by 1 stage each. (Shell Smash)
	/// Increases the user's Attack, Speed and Special Attack by 2 stages each.
	/// <summary>
	public partial class PokeBattle_Move_035 : PokeBattle_Move
	{
		public PokeBattle_Move_035() : base() { }
		//public PokeBattle_Move_035(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (attacker is IBattlerEffect b &&
				!b.CanIncreaseStatStage(Stats.ATTACK, attacker, false, this) &&
				!b.CanIncreaseStatStage(Stats.SPATK, attacker, false, this) &&
				!b.CanIncreaseStatStage(Stats.SPEED, attacker, false, this))
			{
				_host.StartCoroutine(battle.Display(Game._INTL("{1}'s stats won't go any higher!", attacker.ToString())));
				result(-1);
				yield break;
			}
			_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));

			bool showanim = true;
			if (attacker is IBattlerEffect b0 && b0.CanReduceStatStage(Stats.DEFENSE, attacker, false, this))
			{
				b0.ReduceStat(Stats.DEFENSE, 1, attacker, false, this, showanim);
				showanim = false;
			}
			if (attacker is IBattlerEffect b1 && b1.CanReduceStatStage(Stats.SPDEF, attacker, false, this))
			{
				b1.ReduceStat(Stats.SPDEF, 1, attacker, false, this, showanim);
				showanim = false;
			}
			showanim = true;
			if (attacker is IBattlerEffect b2 && b2.CanIncreaseStatStage(Stats.ATTACK, attacker, false, this))
			{
				b2.IncreaseStat(Stats.ATTACK, 2, attacker, false, this, showanim);
				showanim = false;
			}
			if (attacker is IBattlerEffect b3 && b3.CanIncreaseStatStage(Stats.SPATK, attacker, false, this))
			{
				b3.IncreaseStat(Stats.SPATK, 2, attacker, false, this, showanim);
				showanim = false;
			}
			if (attacker is IBattlerEffect b4 && b4.CanIncreaseStatStage(Stats.SPEED, attacker, false, this))
			{
				b4.IncreaseStat(Stats.SPEED, 2, attacker, false, this, showanim);
				showanim = false;
			}
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// Increases the user's Speed by 2 stages, and its Attack by 1 stage. (Shift Gear)
	/// <summary>
	public partial class PokeBattle_Move_036 : PokeBattle_Move
	{
		public PokeBattle_Move_036() : base() { }
		//public PokeBattle_Move_036(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (attacker is IBattlerEffect b &&
				!b.CanIncreaseStatStage(Stats.ATTACK, attacker, false, this) &&
				!b.CanIncreaseStatStage(Stats.SPEED, attacker, false, this))
			{
				_host.StartCoroutine(battle.Display(Game._INTL("{1}'s stats won't go any higher!", attacker.ToString())));
				result(-1);
				yield break;
			}
			_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));

			bool showanim = true;
			if (attacker is IBattlerEffect b0 && b0.CanIncreaseStatStage(Stats.SPEED, attacker, false, this))
			{
				b0.IncreaseStat(Stats.SPEED, 2, attacker, false, this, showanim);
				showanim = false;
			}
			if (attacker is IBattlerEffect b1 && b1.CanIncreaseStatStage(Stats.ATTACK, attacker, false, this))
			{
				b1.IncreaseStat(Stats.ATTACK, 1, attacker, false, this, showanim);
				showanim = false;
			}
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// Increases one random stat of the user by 2 stages (except HP). (Acupressure)
	/// <summary>
	public partial class PokeBattle_Move_037 : PokeBattle_Move
	{
		public PokeBattle_Move_037() : base() { }
		//public PokeBattle_Move_037(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (attacker.Index != opponent.Index)
			{
				if ((opponent.effects.Substitute > 0 && !ignoresSubstitute(attacker)) ||
				   opponent.OwnSide.CraftyShield)
				{
					_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
					result(-1);
					yield break;
				}
			}

			List<Stats> array = new List<Stats>();
			foreach (var i in new[] { Stats.ATTACK, Stats.DEFENSE, Stats.SPEED,
				  Stats.SPATK, Stats.SPDEF, Stats.ACCURACY, Stats.EVASION })
			{
				if (opponent is IBattlerEffect b && b.CanIncreaseStatStage(i, attacker, false, this)) array.Add(i);
			}
			if (array.Count == 0)
			{
				_host.StartCoroutine(battle.Display(Game._INTL("{1}'s stats won't go any higher!", opponent.ToString())));
				result(-1);
				yield break;
			}
			Stats stat = array[this.battle.Random(array.Count)];

			_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));

			if (opponent is IBattlerEffectIE o) _host.StartCoroutine(o.IncreaseStat(stat, 2, attacker, false, this)); //int ret =
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// Increases the user's Defense by 3 stages.
	/// <summary>
	public partial class PokeBattle_Move_038 : PokeBattle_Move
	{
		public PokeBattle_Move_038() : base() { }
		//public PokeBattle_Move_038(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (IsDamaging()) { int reti = -1; _host.StartCoroutine(base.GetEffect(attacker, opponent, hitnum, alltargets, showanimation, result:value=>reti=value)); result(reti); yield break; }
			if (attacker is IBattlerEffectIE b) { bool retb = false; _host.StartCoroutine(b.CanIncreaseStatStage(Stats.DEFENSE, attacker, true, this, result:value=>retb=value)); if (!retb) { result(-1); yield break; } }
			_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));

			bool ret = attacker is IBattlerEffect a && a.IncreaseStat(Stats.DEFENSE, 3, attacker, false, this);
			result(ret ? 0 : -1);
			yield break;
		}

		public override void AdditionalEffect(IBattler attacker, IBattler opponent)
		{
			if (attacker is IBattlerEffect b && b.CanIncreaseStatStage(Stats.DEFENSE, attacker, false, this))
			{
				b.IncreaseStat(Stats.DEFENSE, 3, attacker, false, this);
			}
		}
	}

	/// <summary>
	/// Increases the user's Special Attack by 3 stages.
	/// <summary>
	public partial class PokeBattle_Move_039 : PokeBattle_Move
	{
		public PokeBattle_Move_039() : base() { }
		//public PokeBattle_Move_039(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (IsDamaging()) { int reti = -1; _host.StartCoroutine(base.GetEffect(attacker, opponent, hitnum, alltargets, showanimation, result:value=>reti=value)); result(reti); yield break; }
			if (attacker is IBattlerEffectIE b) { bool retb = false; _host.StartCoroutine(b.CanIncreaseStatStage(Stats.SPATK, attacker, true, this, result:value=>retb=value)); if (!retb) { result(-1); yield break; } }
			_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));

			bool ret = attacker is IBattlerEffect a && a.IncreaseStat(Stats.SPATK, 3, attacker, false, this);
			result(ret ? 0 : -1);
			yield break;
		}

		public override void AdditionalEffect(IBattler attacker, IBattler opponent)
		{
			if (attacker is IBattlerEffect b && b.CanIncreaseStatStage(Stats.DEFENSE, attacker, false, this))
			{
				b.IncreaseStat(Stats.SPATK, 3, attacker, false, this);
			}
		}
	}

	/// <summary>
	/// Reduces the user's HP by half of max, and sets its Attack to maximum. (Belly Drum)
	/// <summary>
	public partial class PokeBattle_Move_03A : PokeBattle_Move
	{
		public PokeBattle_Move_03A() : base() { }
		//public PokeBattle_Move_03A(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (attacker.HP <= Math.Floor(attacker.TotalHP / 2f) ||
			   attacker is IBattlerEffect b && !b.CanIncreaseStatStage(Stats.ATTACK, attacker, false, this))
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));

			attacker.ReduceHP((int)Math.Floor(attacker.TotalHP / 2f));
			if (attacker.hasWorkingAbility(Abilities.CONTRARY))
			{
				attacker.stages[(byte)Stats.ATTACK] = -6;
				_host.StartCoroutine(this.battle.CommonAnimation("StatDown", attacker, null));
				_host.StartCoroutine(battle.Display(Game._INTL("{1} cut its own HP and minimized its Attack!", attacker.ToString())));
			}
			else
			{
				attacker.stages[(byte)Stats.ATTACK] = 6;
				_host.StartCoroutine(this.battle.CommonAnimation("StatUp", attacker, null));
				_host.StartCoroutine(battle.Display(Game._INTL("{1} cut its own HP and maximized its Attack!", attacker.ToString())));
			}
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// Decreases the user's Attack and Defense by 1 stage each. (Superpower)
	/// <summary>
	public partial class PokeBattle_Move_03B : PokeBattle_Move
	{
		public PokeBattle_Move_03B() : base() { }
		//public PokeBattle_Move_03B(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{

			int ret = -1; _host.StartCoroutine(base.GetEffect(attacker, opponent, hitnum, alltargets, showanimation, result:value=>ret=value)); result(ret);
			if (opponent.damagestate.CalcDamage > 0)
			{
				bool showanim = true;
				if (attacker is IBattlerEffect b0 && b0.CanReduceStatStage(Stats.ATTACK, attacker, false, this))
				{
					b0.ReduceStat(Stats.ATTACK, 1, attacker, false, this, showanim);
					showanim = false;
				}
				if (attacker is IBattlerEffect b1 && b1.CanReduceStatStage(Stats.DEFENSE, attacker, false, this))
				{
					b1.ReduceStat(Stats.DEFENSE, 1, attacker, false, this, showanim);
					showanim = false;
				}
			}
			result(ret);
			yield break;
		}
	}

	/// <summary>
	/// Decreases the user's Defense and Special Defense by 1 stage each. (Close Combat)
	/// <summary>
	public partial class PokeBattle_Move_03C : PokeBattle_Move
	{
		public PokeBattle_Move_03C() : base() { }
		//public PokeBattle_Move_03C(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{

			int ret = -1; _host.StartCoroutine(base.GetEffect(attacker, opponent, hitnum, alltargets, showanimation, result:value=>ret=value)); result(ret);
			if (opponent.damagestate.CalcDamage > 0)
			{
				bool showanim = true;
				if (attacker is IBattlerEffect b0 && b0.CanReduceStatStage(Stats.DEFENSE, attacker, false, this))
				{
					b0.ReduceStat(Stats.DEFENSE, 1, attacker, false, this, showanim);
					showanim = false;
				}
				if (attacker is IBattlerEffect b1 && b1.CanReduceStatStage(Stats.SPDEF, attacker, false, this))
				{
					b1.ReduceStat(Stats.SPDEF, 1, attacker, false, this, showanim);
					showanim = false;
				}
			}
			result(ret);
			yield break;
		}
	}

	/// <summary>
	/// Decreases the user's Defense, Special Defense and Speed by 1 stage each.
	/// User's ally loses 1/16 of its total HP. (V-create)
	/// <summary>
	public partial class PokeBattle_Move_03D : PokeBattle_Move
	{
		public PokeBattle_Move_03D() : base() { }
		//public PokeBattle_Move_03D(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{

			int ret = -1; _host.StartCoroutine(base.GetEffect(attacker, opponent, hitnum, alltargets, showanimation, result: value => ret = value)); result(ret);
			if (opponent.damagestate.CalcDamage > 0)
			{
				if (attacker.Partner.IsNotNullOrNone() && !attacker.Partner.isFainted())
				{
					attacker.Partner.ReduceHP((int)Math.Floor(attacker.Partner.TotalHP / 16f), true);
				}
				bool showanim = true;
				if (attacker is IBattlerEffect b0 && b0.CanReduceStatStage(Stats.SPEED, attacker, false, this))
				{
					b0.ReduceStat(Stats.SPEED, 1, attacker, false, this, showanim);
					showanim = false;
				}
				if (attacker is IBattlerEffect b1 && b1.CanReduceStatStage(Stats.DEFENSE, attacker, false, this))
				{
					b1.ReduceStat(Stats.DEFENSE, 1, attacker, false, this, showanim);
					showanim = false;
				}
				if (attacker is IBattlerEffect b2 && b2.CanReduceStatStage(Stats.SPDEF, attacker, false, this))
				{
					b2.ReduceStat(Stats.SPDEF, 1, attacker, false, this, showanim);
					showanim = false;
				}
			}
			result(ret);
			yield break;
		}
	}

	/// <summary>
	/// Decreases the user's Speed by 1 stage.
	/// <summary>
	public partial class PokeBattle_Move_03E : PokeBattle_Move
	{
		public PokeBattle_Move_03E() : base() { }
		//public PokeBattle_Move_03E(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{

			int ret = -1; _host.StartCoroutine(base.GetEffect(attacker, opponent, hitnum, alltargets, showanimation, result: value => ret = value)); result(ret);
			if (opponent.damagestate.CalcDamage > 0)
			{
				if (attacker is IBattlerEffect b && b.CanReduceStatStage(Stats.SPEED, attacker, false, this))
				{
					b.ReduceStat(Stats.SPEED, 1, attacker, false, this);
				}
			}
			result(ret);
			yield break;
		}
	}

	/// <summary>
	/// Decreases the user's Special Attack by 2 stages.
	/// <summary>
	public partial class PokeBattle_Move_03F : PokeBattle_Move
	{
		public PokeBattle_Move_03F() : base() { }
		//public PokeBattle_Move_03F(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{

			int ret = -1; _host.StartCoroutine(base.GetEffect(attacker, opponent, hitnum, alltargets, showanimation, result: value => ret = value)); result(ret);
			if (opponent.damagestate.CalcDamage > 0)
			{
				if (attacker is IBattlerEffect b && b.CanReduceStatStage(Stats.SPATK, attacker, false, this))
				{
					b.ReduceStat(Stats.SPATK, 2, attacker, false, this);
				}
			}
			result(ret);
			yield break;
		}
	}

	/// <summary>
	/// Increases the target's Special Attack by 1 stage. Confuses the target. (Flatter)
	/// <summary>
	public partial class PokeBattle_Move_040 : PokeBattle_Move
	{
		public PokeBattle_Move_040() : base() { }
		//public PokeBattle_Move_040(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (opponent.effects.Substitute > 0 && !ignoresSubstitute(attacker))
			{
				_host.StartCoroutine(battle.Display(Game._INTL("{1}'s attack missed!", attacker.ToString())));
				result(-1);
				yield break;
			}
			int ret = -1;

			_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));
			if (opponent is IBattlerEffect b0 && b0.CanIncreaseStatStage(Stats.SPATK, attacker, false, this))
			{
				b0.IncreaseStat(Stats.SPATK, 1, attacker, false, this);
				ret = 0;
			}
			if (opponent is IBattlerEffect b1 && b1.CanConfuse(attacker, true, this))
			{
				b1.Confuse();
				_host.StartCoroutine(battle.Display(Game._INTL("{1} became confused!", opponent.ToString())));
				ret = 0;
			}
			result(ret);
			yield break;
		}
	}

	/// <summary>
	/// Increases the target's Attack by 2 stages. Confuses the target. (Swagger)
	/// <summary>
	public partial class PokeBattle_Move_041 : PokeBattle_Move
	{
		public PokeBattle_Move_041() : base() { }
		//public PokeBattle_Move_041(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (opponent.effects.Substitute > 0 && !ignoresSubstitute(attacker))
			{
				_host.StartCoroutine(battle.Display(Game._INTL("{1}'s attack missed!", attacker.ToString())));
				result(-1);
				yield break;
			}
			int ret = -1;

			_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));
			if (opponent is IBattlerEffect b0 && b0.CanIncreaseStatStage(Stats.ATTACK, attacker, false, this))
			{
				b0.IncreaseStat(Stats.ATTACK, 2, attacker, false, this);
				ret = 0;
			}
			if (opponent is IBattlerEffect b1 && b1.CanConfuse(attacker, true, this))
			{
				b1.Confuse();
				_host.StartCoroutine(battle.Display(Game._INTL("{1} became confused!", opponent.ToString())));
				ret = 0;
			}
			result(ret);
			yield break;
		}
	}

	/// <summary>
	/// Decreases the target's Attack by 1 stage.
	/// <summary>
	public partial class PokeBattle_Move_042 : PokeBattle_Move
	{
		public PokeBattle_Move_042() : base() { }
		//public PokeBattle_Move_042(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (IsDamaging()) { int reti = -1; _host.StartCoroutine(base.GetEffect(attacker, opponent, hitnum, alltargets, showanimation, result:value=>reti=value)); result(reti); yield break; }
			if (opponent is IBattlerEffectIE b) { bool retb = false; _host.StartCoroutine(b.CanReduceStatStage(Stats.ATTACK, attacker, true, this, result:value=>retb=value)); if (!retb) { result(-1); yield break; } }
			_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));

			bool ret = false; //opponent.ReduceStat(Stats.ATTACK, 1, attacker, false, this);
			if (opponent is IBattlerEffectIE o) _host.StartCoroutine(o.ReduceStat(Stats.ATTACK, 1, attacker, false, this, result: value => ret = value));
			result(ret ? 0 : -1);
			yield break;
		}

		public override void AdditionalEffect(IBattler attacker, IBattler opponent)
		{
			if (opponent.damagestate.Substitute) return;
			if (opponent is IBattlerEffect b && b.CanReduceStatStage(Stats.ATTACK, attacker, false, this))
			{
				b.ReduceStat(Stats.ATTACK, 1, attacker, false, this);
			}
		}
	}

	/// <summary>
	/// Decreases the target's Defense by 1 stage.
	/// <summary>
	public partial class PokeBattle_Move_043 : PokeBattle_Move
	{
		public PokeBattle_Move_043() : base() { }
		//public PokeBattle_Move_043(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (IsDamaging()) { int reti = -1; _host.StartCoroutine(base.GetEffect(attacker, opponent, hitnum, alltargets, showanimation, result:value=>reti=value)); result(reti); yield break; }
			if (opponent is IBattlerEffectIE b) { bool retb = false; _host.StartCoroutine(b.CanReduceStatStage(Stats.DEFENSE, attacker, true, this, result:value=>retb=value)); if (!retb) { result(-1); yield break; } }
			_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));

			bool ret = opponent is IBattlerEffect o && o.ReduceStat(Stats.DEFENSE, 1, attacker, false, this);
			result(ret ? 0 : -1);
			yield break;
		}

		public override void AdditionalEffect(IBattler attacker, IBattler opponent)
		{
			if (opponent.damagestate.Substitute) return;
			if (opponent is IBattlerEffect b && b.CanReduceStatStage(Stats.DEFENSE, attacker, false, this))
			{
				b.ReduceStat(Stats.DEFENSE, 1, attacker, false, this);
			}
		}
	}

	/// <summary>
	/// Decreases the target's Speed by 1 stage.
	/// <summary>
	public partial class PokeBattle_Move_044 : PokeBattle_Move
	{
		public PokeBattle_Move_044() : base() { }
		//public PokeBattle_Move_044(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (IsDamaging()) { int reti = -1; _host.StartCoroutine(base.GetEffect(attacker, opponent, hitnum, alltargets, showanimation, result:value=>reti=value)); result(reti); yield break; }
			if (opponent is IBattlerEffectIE b) { bool retb = false; _host.StartCoroutine(b.CanReduceStatStage(Stats.SPEED, attacker, true, this, result:value=>retb=value)); if (!retb) { result(-1); yield break; } }
			_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));

			bool ret = opponent is IBattlerEffect o && o.ReduceStat(Stats.SPEED, 1, attacker, false, this);
			result(ret ? 0 : -1);
			yield break;
		}

		public override void AdditionalEffect(IBattler attacker, IBattler opponent)
		{
			if (opponent.damagestate.Substitute) return;
			if (opponent is IBattlerEffect b && b.CanReduceStatStage(Stats.SPEED, attacker, false, this))
			{
				b.ReduceStat(Stats.SPEED, 1, attacker, false, this);
			}
		}

		public int ModifyDamage(int damagemult, IBattler attacker, IBattler opponent)
		{
			if (id == Moves.BULLDOZE &&
			   this.battle.field.GrassyTerrain > 0)
			{
				return (int)Math.Round(damagemult / 2.0f);
			}
			return damagemult;
		}
	}

	/// <summary>
	/// Decreases the target's Special Attack by 1 stage.
	/// <summary>
	public partial class PokeBattle_Move_045 : PokeBattle_Move
	{
		public PokeBattle_Move_045() : base() { }
		//public PokeBattle_Move_045(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (IsDamaging()) { int reti = -1; _host.StartCoroutine(base.GetEffect(attacker, opponent, hitnum, alltargets, showanimation, result:value=>reti=value)); result(reti); yield break; }
			if (opponent is IBattlerEffectIE b) { bool retb = false; _host.StartCoroutine(b.CanReduceStatStage(Stats.SPATK, attacker, true, this, result:value=>retb=value)); if (!retb) { result(-1); yield break; } }
			_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));

			bool ret = opponent is IBattlerEffect o && o.ReduceStat(Stats.SPATK, 1, attacker, false, this);
			result(ret ? 0 : -1);
			yield break;
		}

		public override void AdditionalEffect(IBattler attacker, IBattler opponent)
		{
			if (opponent.damagestate.Substitute) return;
			if (opponent is IBattlerEffect b && b.CanReduceStatStage(Stats.SPATK, attacker, false, this))
			{
				b.ReduceStat(Stats.SPATK, 1, attacker, false, this);
			}
		}
	}

	/// <summary>
	/// Decreases the target's Special Defense by 1 stage.
	/// <summary>
	public partial class PokeBattle_Move_046 : PokeBattle_Move
	{
		public PokeBattle_Move_046() : base() { }
		//public PokeBattle_Move_046(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (IsDamaging()) { int reti = -1; _host.StartCoroutine(base.GetEffect(attacker, opponent, hitnum, alltargets, showanimation, result:value=>reti=value)); result(reti); yield break; }
			if (opponent is IBattlerEffectIE b) { bool retb = false; _host.StartCoroutine(b.CanReduceStatStage(Stats.SPDEF, attacker, true, this, result:value=>retb=value)); if (!retb) { result(-1); yield break; } }
			_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));

			bool ret = opponent is IBattlerEffect o && o.ReduceStat(Stats.SPDEF, 1, attacker, false, this);
			result(ret ? 0 : -1);
			yield break;
		}

		public override void AdditionalEffect(IBattler attacker, IBattler opponent)
		{
			if (opponent.damagestate.Substitute) return;
			if (opponent is IBattlerEffect b && b.CanReduceStatStage(Stats.SPDEF, attacker, false, this))
			{
				b.ReduceStat(Stats.SPDEF, 1, attacker, false, this);
			}
		}
	}

	/// <summary>
	/// Decreases the target's accuracy by 1 stage.
	/// <summary>
	public partial class PokeBattle_Move_047 : PokeBattle_Move
	{
		public PokeBattle_Move_047() : base() { }
		//public PokeBattle_Move_047(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (IsDamaging()) { int reti = -1; _host.StartCoroutine(base.GetEffect(attacker, opponent, hitnum, alltargets, showanimation, result:value=>reti=value)); result(reti); yield break; }
			if (opponent is IBattlerEffectIE b) { bool retb = false; _host.StartCoroutine(b.CanReduceStatStage(Stats.ACCURACY, attacker, true, this, result:value=>retb=value)); if (!retb) { result(-1); yield break; } }
			_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));

			bool ret = opponent is IBattlerEffect o && o.ReduceStat(Stats.ACCURACY, 1, attacker, false, this);
			result(ret ? 0 : -1);
			yield break;
		}

		public override void AdditionalEffect(IBattler attacker, IBattler opponent)
		{
			if (opponent.damagestate.Substitute) return;
			if (opponent is IBattlerEffect b && b.CanReduceStatStage(Stats.ACCURACY, attacker, false, this))
			{
				b.ReduceStat(Stats.ACCURACY, 1, attacker, false, this);
			}
		}
	}

	/// <summary>
	/// Decreases the target's evasion by 1 stage OR 2 stages. (Sweet Scent)
	/// <summary>
	public partial class PokeBattle_Move_048 : PokeBattle_Move
	{
		public PokeBattle_Move_048() : base() { }
		//public PokeBattle_Move_048(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (IsDamaging()) { int reti = -1; _host.StartCoroutine(base.GetEffect(attacker, opponent, hitnum, alltargets, showanimation, result:value=>reti=value)); result(reti); yield break; }
			if (opponent is IBattlerEffectIE b) { bool retb = false; _host.StartCoroutine(b.CanReduceStatStage(Stats.EVASION, attacker, true, this, result:value=>retb=value)); if (!retb) { result(-1); yield break; } }
			_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));

			byte increment = (Core.USENEWBATTLEMECHANICS) ? (byte)2 : (byte)1;
			bool ret = opponent is IBattlerEffect o && o.ReduceStat(Stats.EVASION, increment, attacker, false, this);
			result(ret ? 0 : -1);
			yield break;
		}

		public override void AdditionalEffect(IBattler attacker, IBattler opponent)
		{
			if (opponent.damagestate.Substitute) return;
			if (opponent is IBattlerEffect b && b.CanReduceStatStage(Stats.EVASION, attacker, false, this))
			{
				byte increment = (Core.USENEWBATTLEMECHANICS) ? (byte)2 : (byte)1;
				b.ReduceStat(Stats.EVASION, increment, attacker, false, this);
			}
		}
	}

	/// <summary>
	/// Decreases the target's evasion by 1 stage. Ends all barriers and entry
	/// hazards for the target's side OR on both sides. (Defog)
	/// <summary>
	public partial class PokeBattle_Move_049 : PokeBattle_Move
	{
		public PokeBattle_Move_049() : base() { }
		//public PokeBattle_Move_049(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (IsDamaging()) { int reti = -1; _host.StartCoroutine(base.GetEffect(attacker, opponent, hitnum, alltargets, showanimation, result:value=>reti=value)); result(reti); yield break; }
			_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));

			if (opponent is IBattlerEffectIE o) _host.StartCoroutine(o.ReduceStat(Stats.EVASION, 1, attacker, false, this));
			opponent.OwnSide.Reflect = 0;
			opponent.OwnSide.LightScreen = 0;
			opponent.OwnSide.Mist = 0;
			opponent.OwnSide.Safeguard = 0;
			opponent.OwnSide.Spikes = 0;
			opponent.OwnSide.StealthRock = false;
			opponent.OwnSide.StickyWeb = false;
			opponent.OwnSide.ToxicSpikes = 0;
			if (Core.USENEWBATTLEMECHANICS)
			{
				opponent.OpposingSide.Reflect = 0;
				opponent.OpposingSide.LightScreen = 0;
				opponent.OpposingSide.Mist = 0;
				opponent.OpposingSide.Safeguard = 0;
				opponent.OpposingSide.Spikes = 0;
				opponent.OpposingSide.StealthRock = false;
				opponent.OpposingSide.StickyWeb = false;
				opponent.OpposingSide.ToxicSpikes = 0;
			}
			result(0);
			yield break;
		}

		public override void AdditionalEffect(IBattler attacker, IBattler opponent)
		{
			if (!opponent.damagestate.Substitute)
				if (opponent is IBattlerEffect b && b.CanReduceStatStage(Stats.EVASION, attacker, false, this))
					b.ReduceStat(Stats.EVASION, 1, attacker, false, this);

			opponent.OwnSide.Reflect = 0;
			opponent.OwnSide.LightScreen = 0;
			opponent.OwnSide.Mist = 0;
			opponent.OwnSide.Safeguard = 0;
			opponent.OwnSide.Spikes = 0;
			opponent.OwnSide.StealthRock = false;
			opponent.OwnSide.StickyWeb = false;
			opponent.OwnSide.ToxicSpikes = 0;
			if (Core.USENEWBATTLEMECHANICS)
			{
				opponent.OpposingSide.Reflect = 0;
				opponent.OpposingSide.LightScreen = 0;
				opponent.OpposingSide.Mist = 0;
				opponent.OpposingSide.Safeguard = 0;
				opponent.OpposingSide.Spikes = 0;
				opponent.OpposingSide.StealthRock = false;
				opponent.OpposingSide.StickyWeb = false;
				opponent.OpposingSide.ToxicSpikes = 0;
			}
		}
	}

	/// <summary>
	/// Decreases the target's Attack and Defense by 1 stage each. (Tickle)
	/// <summary>
	public partial class PokeBattle_Move_04A : PokeBattle_Move
	{
		public PokeBattle_Move_04A() : base() { }
		//public PokeBattle_Move_04A(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			// Replicates CanReduceStatStage? so that certain messages aren't shown
			// multiple times
			if (opponent.effects.Substitute > 0 && !ignoresSubstitute(attacker))
			{
				_host.StartCoroutine(battle.Display(Game._INTL("{1}'s attack missed!", attacker.ToString())));
				result(-1);
				yield break;
			}
			if (opponent is IBattlerEffect b &&
				b.TooLow(Stats.ATTACK) &&
				b.TooLow(Stats.DEFENSE))
			{
				_host.StartCoroutine(battle.Display(Game._INTL("{1}'s stats won't go any lower!", opponent.ToString())));
				result(-1);
				yield break;
			}
			if (opponent.OwnSide.Mist > 0)
			{
				_host.StartCoroutine(battle.Display(Game._INTL("{1} is protected by Mist!", opponent.ToString())));
				result(-1);
				yield break;
			}
			if (!attacker.hasMoldBreaker())
			{
				if (opponent.hasWorkingAbility(Abilities.CLEAR_BODY) ||
				   opponent.hasWorkingAbility(Abilities.WHITE_SMOKE))
				{
					_host.StartCoroutine(battle.Display(Game._INTL("{1}'s {2} prevents stat loss!", opponent.ToString(),
					   Game._INTL(opponent.Ability.ToString(TextScripts.Name)))));
					result(-1);
					yield break;
				}
			}

			_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));

			int ret = -1; bool showanim = true;
			if (!attacker.hasMoldBreaker() && opponent.hasWorkingAbility(Abilities.HYPER_CUTTER) &&
				opponent is IBattlerEffect b0 && !b0.TooLow(Stats.ATTACK))
			{
				string abilityname = Game._INTL(opponent.Ability.ToString(TextScripts.Name));

				_host.StartCoroutine(battle.Display(Game._INTL("{1}'s {2} prevents Attack loss!", opponent.ToString(), abilityname)));
			}
			else if (opponent is IBattlerEffect b1 && b1.ReduceStat(Stats.ATTACK, 1, attacker, false, this, showanim))
			{
				ret = 0; showanim = false;
			}
			if (!attacker.hasMoldBreaker() && opponent.hasWorkingAbility(Abilities.BIG_PECKS) &&
				opponent is IBattlerEffect b2 && !b2.TooLow(Stats.DEFENSE))
			{
				string abilityname = Game._INTL(opponent.Ability.ToString(TextScripts.Name));

				_host.StartCoroutine(battle.Display(Game._INTL("{1}'s {2} prevents Defense loss!", opponent.ToString(), abilityname)));
			}
			else if (opponent is IBattlerEffect b3 && b3.ReduceStat(Stats.DEFENSE, 1, attacker, false, this, showanim))
			{
				ret = 0; showanim = false;
			}
			result(ret);
			yield break;
		}
	}

	/// <summary>
	/// Decreases the target's Attack by 2 stages.
	/// <summary>
	public partial class PokeBattle_Move_04B : PokeBattle_Move
	{
		public PokeBattle_Move_04B() : base() { }
		//public PokeBattle_Move_04B(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (IsDamaging()) { int reti = -1; _host.StartCoroutine(base.GetEffect(attacker, opponent, hitnum, alltargets, showanimation, result:value=>reti=value)); result(reti); yield break; }
			if (opponent is IBattlerEffectIE b) { bool retb = false; _host.StartCoroutine(b.CanReduceStatStage(Stats.ATTACK, attacker, true, this, result:value=>retb=value)); if (!retb) { result(-1); yield break; } }
			_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));

			bool ret = opponent is IBattlerEffect o && o.ReduceStat(Stats.ATTACK, 2, attacker, false, this);
			result(ret ? 0 : -1);
			yield break;
		}

		public override void AdditionalEffect(IBattler attacker, IBattler opponent)
		{
			if (opponent.damagestate.Substitute) return;
			if (opponent is IBattlerEffect b && b.CanReduceStatStage(Stats.ATTACK, attacker, false, this))
			{
				b.ReduceStat(Stats.ATTACK, 2, attacker, false, this);
			}
		}
	}

	/// <summary>
	/// Decreases the target's Defense by 2 stages. (Screech)
	/// <summary>
	public partial class PokeBattle_Move_04C : PokeBattle_Move
	{
		public PokeBattle_Move_04C() : base() { }
		//public PokeBattle_Move_04C(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (IsDamaging()) { int reti = -1; _host.StartCoroutine(base.GetEffect(attacker, opponent, hitnum, alltargets, showanimation, result:value=>reti=value)); result(reti); yield break; }
			if (opponent is IBattlerEffectIE b) { bool retb = false; _host.StartCoroutine(b.CanReduceStatStage(Stats.DEFENSE, attacker, true, this, result:value=>retb=value)); if (!retb) { result(-1); yield break; } }
			_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));

			bool ret = opponent is IBattlerEffect o && o.ReduceStat(Stats.DEFENSE, 2, attacker, false, this);
			result(ret ? 0 : -1);
			yield break;
		}

		public override void AdditionalEffect(IBattler attacker, IBattler opponent)
		{
			if (opponent.damagestate.Substitute) return;
			if (opponent is IBattlerEffect b && b.CanReduceStatStage(Stats.DEFENSE, attacker, false, this))
			{
				b.ReduceStat(Stats.DEFENSE, 2, attacker, false, this);
			}
		}
	}

	/// <summary>
	/// Decreases the target's Speed by 2 stages. (Cotton Spore, Scary Face, String Shot)
	/// <summary>
	public partial class PokeBattle_Move_04D : PokeBattle_Move
	{
		public PokeBattle_Move_04D() : base() { }
		//public PokeBattle_Move_04D(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (IsDamaging()) { int reti = -1; _host.StartCoroutine(base.GetEffect(attacker, opponent, hitnum, alltargets, showanimation, result:value=>reti=value)); result(reti); yield break; }
			if (TypeImmunityByAbility(GetType(this.type, attacker, opponent), attacker, opponent)) { result(-1); yield break; }
			if (opponent is IBattlerEffectIE b) { bool retb = false; _host.StartCoroutine(b.CanReduceStatStage(Stats.SPEED, attacker, true, this, result:value=>retb=value)); if (!retb) { result(-1); yield break; } }
			_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));

			byte increment = (id == Moves.STRING_SHOT && !Core.USENEWBATTLEMECHANICS) ? (byte)1 : (byte)2;
			bool ret = opponent is IBattlerEffect o && o.ReduceStat(Stats.SPEED, increment, attacker, false, this);
			result(ret ? 0 : -1);
			yield break;
		}

		public override void AdditionalEffect(IBattler attacker, IBattler opponent)
		{
			if (opponent.damagestate.Substitute) return;
			if (opponent is IBattlerEffect b && b.CanReduceStatStage(Stats.SPEED, attacker, false, this))
			{
				byte increment = (id == Moves.STRING_SHOT && !Core.USENEWBATTLEMECHANICS) ? (byte)1 : (byte)2;
				b.ReduceStat(Stats.SPEED, increment, attacker, false, this);
			}
		}
	}

	/// <summary>
	/// Decreases the target's Special Attack by 2 stages. Only works on the opposite
	/// gender. (Captivate)
	/// <summary>
	public partial class PokeBattle_Move_04E : PokeBattle_Move
	{
		public PokeBattle_Move_04E() : base() { }
		//public PokeBattle_Move_04E(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (IsDamaging()) { int reti = -1; _host.StartCoroutine(base.GetEffect(attacker, opponent, hitnum, alltargets, showanimation, result:value=>reti=value)); result(reti); yield break; }
			if (opponent is IBattlerEffectIE b) { bool retb = false; _host.StartCoroutine(b.CanReduceStatStage(Stats.SPATK, attacker, true, this, result:value=>retb=value)); if (!retb) { result(-1); yield break; } }
			if (!attacker.Gender.HasValue || !opponent.Gender.HasValue || attacker.Gender.Value == opponent.Gender.Value)
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			if (!attacker.hasMoldBreaker() && opponent.hasWorkingAbility(Abilities.OBLIVIOUS))
			{
				_host.StartCoroutine(battle.Display(Game._INTL("{1}'s {2} prevents romance!", opponent.ToString(),
				 Game._INTL(opponent.Ability.ToString(TextScripts.Name)))));
				result(-1);
				yield break;
			}
			_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));

			bool ret = opponent is IBattlerEffect o && o.ReduceStat(Stats.SPATK, 2, attacker, false, this);
			result(ret ? 0 : -1);
			yield break;
		}

		public override void AdditionalEffect(IBattler attacker, IBattler opponent)
		{
			if (opponent.damagestate.Substitute) return;
			if (attacker.Gender.HasValue && opponent.Gender.HasValue && attacker.Gender.Value != opponent.Gender.Value)
			{
				if (attacker.hasMoldBreaker() || !opponent.hasWorkingAbility(Abilities.OBLIVIOUS))
				{
					if (opponent is IBattlerEffect b && b.CanReduceStatStage(Stats.SPATK, attacker, false, this))
					{
						b.ReduceStat(Stats.SPATK, 2, attacker, false, this);
					}
				}
			}
		}
	}

	/// <summary>
	/// Decreases the target's Special Defense by 2 stages.
	/// <summary>
	public partial class PokeBattle_Move_04F : PokeBattle_Move
	{
		public PokeBattle_Move_04F() : base() { }
		//public PokeBattle_Move_04F(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (IsDamaging()) { int reti = -1; _host.StartCoroutine(base.GetEffect(attacker, opponent, hitnum, alltargets, showanimation, result:value=>reti=value)); result(reti); yield break; }
			if (opponent is IBattlerEffectIE b) { bool retb = false; _host.StartCoroutine(b.CanReduceStatStage(Stats.SPDEF, attacker, true, this, result:value=>retb=value)); if (!retb) { result(-1); yield break; } }
			_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));

			bool ret = opponent is IBattlerEffect o && o.ReduceStat(Stats.SPDEF, 2, attacker, false, this);
			result(ret ? 0 : -1);
			yield break;
		}

		public override void AdditionalEffect(IBattler attacker, IBattler opponent)
		{
			if (opponent.damagestate.Substitute) return;
			if (opponent is IBattlerEffect b && b.CanReduceStatStage(Stats.SPDEF, attacker, false, this))
			{
				b.ReduceStat(Stats.SPDEF, 2, attacker, false, this);
			}
		}
	}

	/// <summary>
	/// Resets all target's stat stages to 0. (Clear Smog)
	/// <summary>
	public partial class PokeBattle_Move_050 : PokeBattle_Move
	{
		public PokeBattle_Move_050() : base() { }
		//public PokeBattle_Move_050(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{

			int ret = -1; _host.StartCoroutine(base.GetEffect(attacker, opponent, hitnum, alltargets, showanimation, result: value => ret = value)); result(ret);
			if (opponent.damagestate.CalcDamage > 0 && !opponent.damagestate.Substitute)
			{
				opponent.stages[(byte)Stats.ATTACK] = 0;
				opponent.stages[(byte)Stats.DEFENSE] = 0;
				opponent.stages[(byte)Stats.SPEED] = 0;
				opponent.stages[(byte)Stats.SPATK] = 0;
				opponent.stages[(byte)Stats.SPDEF] = 0;
				opponent.stages[(byte)Stats.ACCURACY] = 0;
				opponent.stages[(byte)Stats.EVASION] = 0;

				_host.StartCoroutine(battle.Display(Game._INTL("{1}'s stat changes were removed!", opponent.ToString())));
			}
			result(ret);
			yield break;
		}
	}

	/// <summary>
	/// Resets all stat stages for all battlers to 0. (Haze)
	/// <summary>
	public partial class PokeBattle_Move_051 : PokeBattle_Move
	{
		public PokeBattle_Move_051() : base() { }
		//public PokeBattle_Move_051(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			for (int i = 0; i < 4; i++)
			{
				this.battle.battlers[i].stages[(byte)Stats.ATTACK] = 0;
				this.battle.battlers[i].stages[(byte)Stats.DEFENSE] = 0;
				this.battle.battlers[i].stages[(byte)Stats.SPEED] = 0;
				this.battle.battlers[i].stages[(byte)Stats.SPATK] = 0;
				this.battle.battlers[i].stages[(byte)Stats.SPDEF] = 0;
				this.battle.battlers[i].stages[(byte)Stats.ACCURACY] = 0;
				this.battle.battlers[i].stages[(byte)Stats.EVASION] = 0;
			}
			_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));

			_host.StartCoroutine(battle.Display(Game._INTL("All stat changes were eliminated!")));
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// User and target swap their Attack and Special Attack stat stages. (Power Swap)
	/// <summary>
	public partial class PokeBattle_Move_052 : PokeBattle_Move
	{
		public PokeBattle_Move_052() : base() { }
		//public PokeBattle_Move_052(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));

			astage = attacker.stages;
			ostage = opponent.stages;
			//astage[(byte)Stats.ATTACK],ostage[(byte)Stats.ATTACK]=ostage[(byte)Stats.ATTACK],astage[(byte)Stats.ATTACK]
			//astage[(byte)Stats.SPATK], ostage[(byte)Stats.SPATK] = ostage[(byte)Stats.SPATK], astage[(byte)Stats.SPATK]
			int a = astage[(byte)Stats.ATTACK];
			int o = ostage[(byte)Stats.ATTACK];
			astage[(byte)Stats.ATTACK] = o; //ostage[(byte)Stats.ATTACK];
			ostage[(byte)Stats.ATTACK] = a; //astage[(byte)Stats.ATTACK];
			a = astage[(byte)Stats.SPATK];
			o = ostage[(byte)Stats.SPATK];
			astage[(byte)Stats.SPATK] = o; //ostage[(byte)Stats.SPATK];
			ostage[(byte)Stats.SPATK] = a; //astage[(byte)Stats.SPATK];

			_host.StartCoroutine(battle.Display(Game._INTL("{1} switched all changes to its Attack and Sp. Atk with the target!", attacker.ToString())));
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// User and target swap their Defense and Special Defense stat stages. (Guard Swap)
	/// <summary>
	public partial class PokeBattle_Move_053 : PokeBattle_Move
	{
		public PokeBattle_Move_053() : base() { }
		//public PokeBattle_Move_053(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));

			astage = attacker.stages;
			ostage = opponent.stages;
			//astage[(byte)Stats.DEFENSE],ostage[(byte)Stats.DEFENSE]=ostage[(byte)Stats.DEFENSE],astage[(byte)Stats.DEFENSE]
			//astage[(byte)Stats.SPDEF], ostage[(byte)Stats.SPDEF] = ostage[(byte)Stats.SPDEF], astage[(byte)Stats.SPDEF]
			int a = astage[(byte)Stats.DEFENSE];
			int o = ostage[(byte)Stats.DEFENSE];
			astage[(byte)Stats.DEFENSE] = o; //ostage[(byte)Stats.DEFENSE];
			ostage[(byte)Stats.DEFENSE] = a; //astage[(byte)Stats.DEFENSE];
			a = astage[(byte)Stats.SPDEF];
			o = ostage[(byte)Stats.SPDEF];
			astage[(byte)Stats.SPDEF] = o; //ostage[(byte)Stats.SPDEF];
			ostage[(byte)Stats.SPDEF] = a; //astage[(byte)Stats.SPDEF];

			_host.StartCoroutine(battle.Display(Game._INTL("{1} switched all changes to its Defense and Sp. Def with the target!", attacker.ToString())));
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// User and target swap all their stat stages. (Heart Swap)
	/// <summary>
	public partial class PokeBattle_Move_054 : PokeBattle_Move
	{
		public PokeBattle_Move_054() : base() { }
		//public PokeBattle_Move_054(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{

			_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));
			foreach (var i in new[] { Stats.ATTACK, Stats.DEFENSE, Stats.SPEED,
				  Stats.SPATK, Stats.SPDEF, Stats.ACCURACY, Stats.EVASION })
			{
				//attacker.stages[(byte)i],opponent.stages[(byte)i] = opponent.stages[(byte)i],attacker.stages[(byte)i];
				int a = attacker.stages[(byte)i];
				int o = opponent.stages[(byte)i];
				attacker.stages[(byte)i] = o; //opponent.stages[(byte)i];
				opponent.stages[(byte)i] = a; //attacker.stages[(byte)i];
			}

			_host.StartCoroutine(battle.Display(Game._INTL("{1} switched stat changes with the target!", attacker.ToString())));
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// User copies the target's stat stages. (Psych Up)
	/// <summary>
	public partial class PokeBattle_Move_055 : PokeBattle_Move
	{
		public PokeBattle_Move_055() : base() { }
		//public PokeBattle_Move_055(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (opponent.OwnSide.CraftyShield)
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));
			foreach (var i in new[] { Stats.ATTACK, Stats.DEFENSE, Stats.SPEED,
				  Stats.SPATK, Stats.SPDEF, Stats.ACCURACY, Stats.EVASION })
			{
				attacker.stages[(byte)i] = opponent.stages[(byte)i];
			}

			_host.StartCoroutine(battle.Display(Game._INTL("{1} copied {2}'s stat changes!", attacker.ToString(), opponent.ToString(true))));
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// For 5 rounds, user's and ally's stat stages cannot be lowered by foes. (Mist)
	/// <summary>
	public partial class PokeBattle_Move_056 : PokeBattle_Move
	{
		public PokeBattle_Move_056() : base() { }
		//public PokeBattle_Move_056(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (attacker.OwnSide.Mist > 0)
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));

			attacker.OwnSide.Mist = 5;
			if (!this.battle.IsOpposing(attacker.Index))
			{
				_host.StartCoroutine(battle.Display(Game._INTL("Your team became shrouded in mist!")));
			}
			else
			{
				_host.StartCoroutine(battle.Display(Game._INTL("The opposing team became shrouded in mist!")));
			}
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// Swaps the user's Attack and Defense stats. (Power Trick)
	/// <summary>
	public partial class PokeBattle_Move_057 : PokeBattle_Move
	{
		public PokeBattle_Move_057() : base() { }
		//public PokeBattle_Move_057(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			_host.StartCoroutine(ShowAnimation(this.id, attacker, null, hitnum, alltargets, showanimation));

			//attacker.attack,attacker.defense = attacker.defense,attacker.attack;
			int a = attacker.ATK;
			int d = attacker.DEF;
			attacker.ATK = d; //attacker.DEF;
			attacker.DEF = a; //attacker.ATK;
			attacker.effects.PowerTrick = !attacker.effects.PowerTrick;

			_host.StartCoroutine(battle.Display(Game._INTL("{1} switched its Attack and Defense!", attacker.ToString())));
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// Averages the user's and target's Attack.
	/// Averages the user's and target's Special Attack. (Power Split)
	/// <summary>
	public partial class PokeBattle_Move_058 : PokeBattle_Move
	{
		public PokeBattle_Move_058() : base() { }
		//public PokeBattle_Move_058(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (opponent.effects.Substitute > 0 && !ignoresSubstitute(attacker))
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));

			int avatk = (int)Math.Floor((attacker.ATK + opponent.ATK) / 2f);
			int avspatk = (int)Math.Floor((attacker.SPA + opponent.SPA) / 2f);

			attacker.ATK = opponent.ATK = avatk;
			attacker.SPA = opponent.SPA = avspatk;

			_host.StartCoroutine(battle.Display(Game._INTL("{1} shared its power with the target!", attacker.ToString())));
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// Averages the user's and target's Defense.
	/// Averages the user's and target's Special Defense. (Guard Split)
	/// <summary>
	public partial class PokeBattle_Move_059 : PokeBattle_Move
	{
		public PokeBattle_Move_059() : base() { }
		//public PokeBattle_Move_059(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (opponent.effects.Substitute > 0 && !ignoresSubstitute(attacker))
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));

			int avdef = (int)Math.Floor((attacker.DEF + opponent.DEF) / 2f);
			int avspdef = (int)Math.Floor((attacker.SPD + opponent.SPD) / 2f);

			attacker.DEF = opponent.DEF = avdef;
			attacker.SPD = opponent.SPD = avspdef;

			_host.StartCoroutine(battle.Display(Game._INTL("{1} shared its guard with the target!", attacker.ToString())));
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// Averages the user's and target's current HP. (Pain Split)
	/// <summary>
	public partial class PokeBattle_Move_05A : PokeBattle_Move
	{
		public PokeBattle_Move_05A() : base() { }
		//public PokeBattle_Move_05A(Battle battle, Attack.Move move) : base(battle, move) { }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result = null)
		{
			if (opponent.effects.Substitute > 0 && !ignoresSubstitute(attacker))
			{
				yield return battle.Display(Game._INTL("But it failed!"));
				result?.Invoke(-1); yield break;
			}
			yield return ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation);

			int olda = attacker.HP;
			int oldo = opponent.HP;

			int avhp = (int)Math.Floor((attacker.HP + opponent.HP) / 2f);
			attacker.HP = Math.Min(avhp, attacker.TotalHP);
			opponent.HP = Math.Min(avhp, opponent.TotalHP);

			if (this.battle.scene is IPokeBattle_SceneIE s0) yield return s0.HPChanged(attacker, olda);
			if (this.battle.scene is IPokeBattle_SceneIE s1) yield return s1.HPChanged(opponent, oldo);
			yield return battle.Display(Game._INTL("The battlers shared their pain!"));
			result?.Invoke(0);
		}
	}

	/// <summary>
	/// For 4 rounds, doubles the Speed of all battlers on the user's side. (Tailwind)
	/// <summary>
	public partial class PokeBattle_Move_05B : PokeBattle_Move
	{
		public PokeBattle_Move_05B() : base() { }
		//public PokeBattle_Move_05B(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (attacker.OwnSide.Tailwind > 0)
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			_host.StartCoroutine(ShowAnimation(this.id, attacker, null, hitnum, alltargets, showanimation));

			attacker.OwnSide.Tailwind = 4;
			if (!this.battle.IsOpposing(attacker.Index))
			{
				_host.StartCoroutine(battle.Display(Game._INTL("The tailwind blew from behind your team!")));
			}
			else
			{
				_host.StartCoroutine(battle.Display(Game._INTL("The tailwind blew from behind the opposing team!")));
			}
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// This move turns into the last move used by the target, until user switches
	/// out. (Mimic)
	/// <summary>
	public partial class PokeBattle_Move_05C : PokeBattle_Move
	{
		public PokeBattle_Move_05C() : base() { }
		//public PokeBattle_Move_05C(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{

			List<Attack.Effects> blacklist = new List<Attack.Effects> {
				Attack.Effects.x0FF,   // Struggle
				Attack.Effects.x10C,   // Chatter
				Attack.Effects.x053,   // Mimic
				Attack.Effects.x060,   // Sketch
				Attack.Effects.x054    // Metronome
			};
			if (attacker.effects.Transform ||
			   opponent.lastMoveUsed <= 0 ||
			   Kernal.MoveData[(Moves)opponent.lastMoveUsed].Type == Types.SHADOW ||
			   blacklist.Contains(Kernal.MoveData[(Moves)opponent.lastMoveUsed].Effect))
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			foreach (var i in attacker.moves)
			{
				if (i.id == opponent.lastMoveUsed)
				{
					_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
					result(-1);
					yield break;
				}
			}

			_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));
			for (int i = 0; i < attacker.moves.Length; i++)
			{
				if (attacker.moves[i].id == this.id)
				{
					Attack.Move newmove = new Attack.Move(opponent.lastMoveUsed);
					attacker.moves[i] = Combat.Move.FromMove(this.battle, newmove);

					string movename = Game._INTL(opponent.lastMoveUsed.ToString(TextScripts.Name));

					_host.StartCoroutine(battle.Display(Game._INTL("{1} learned {2}!", attacker.ToString(), movename)));
					result(0);
					yield break;
				}
			}

			_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
			result(-1);
			yield break;
		}
	}

	/// <summary>
	/// This move permanently turns into the last move used by the target. (Sketch)
	/// <summary>
	public partial class PokeBattle_Move_05D : PokeBattle_Move
	{
		public PokeBattle_Move_05D() : base() { }
		//public PokeBattle_Move_05D(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{

			List<Attack.Effects> blacklist = new List<Attack.Effects> {
				Attack.Effects.x0FF,   // Struggle
				Attack.Effects.x10C,   // Chatter
				Attack.Effects.x060    // Sketch
			};
			if (attacker.effects.Transform ||
			   opponent.lastMoveUsedSketch <= 0 ||
			   Kernal.MoveData[(Moves)opponent.lastMoveUsedSketch].Type == Types.SHADOW ||
			   blacklist.Contains(Kernal.MoveData[(Moves)opponent.lastMoveUsedSketch].Effect))
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			foreach (var i in attacker.moves)
			{
				if (i.id == opponent.lastMoveUsedSketch)
				{
					_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
					result(-1);
					yield break;
				}
			}
			if (opponent.OwnSide.CraftyShield)
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));
			for (int i = 0; i < attacker.moves.Length; i++)
			{
				if (attacker.moves[i].id == this.id)
				{
					Attack.Move newmove = new Attack.Move(opponent.lastMoveUsedSketch);
					attacker.moves[i] = Combat.Move.FromMove(this.battle, newmove);

					IPokemon[] party = this.battle.Party(attacker.Index);


					party[attacker.pokemonIndex].moves[i] = newmove;


					string movename = Game._INTL(opponent.lastMoveUsedSketch.ToString(TextScripts.Name));

					_host.StartCoroutine(battle.Display(Game._INTL("{1} learned {2}!", attacker.ToString(), movename)));
					result(0);
					yield break;
				}
			}

			_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
			result(-1);
			yield break;
		}
	}

	/// <summary>
	/// Changes user's type to that of a random user's move, except this one, OR the
	/// user's first move's type. (Conversion)
	/// <summary>
	public partial class PokeBattle_Move_05E : PokeBattle_Move
	{
		public PokeBattle_Move_05E() : base() { }
		//public PokeBattle_Move_05E(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (attacker.Ability == Abilities.MULTITYPE)
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			List<Types> types = new List<Types>(); //[]
			foreach (var i in attacker.moves)
			{
				if (i.id == this.id) continue; //next
				//if (Types.isPseudoType(i.Type)) continue;
				if (attacker.HasType(i.Type)) continue; //next
				if (!types.Contains(i.Type))
				{
					types.Add(i.Type);
					if (Core.USENEWBATTLEMECHANICS) break;
				}

			}
			if (types.Count == 0)
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			_host.StartCoroutine(ShowAnimation(this.id, attacker, null, hitnum, alltargets, showanimation));

			Types newtype = types[this.battle.Random(types.Count)];
			attacker.Type1 = newtype;
			attacker.Type2 = newtype;

			attacker.effects.Type3 = Types.NONE; //-1;

			string typename = Game._INTL(newtype.ToString(TextScripts.Name));

			_host.StartCoroutine(battle.Display(Game._INTL("{1} transformed into the {2} type!", attacker.ToString(), typename)));
			result(0);
			yield break; //ToDo: Wasnt sure what to return, so put null/0
		}
	}

	/// <summary>
	/// Changes user's type to a random one that resists/is immune to the last move
	/// used by the target. (Conversion 2)
	/// <summary>
	public partial class PokeBattle_Move_05F : PokeBattle_Move
	{
		public PokeBattle_Move_05F() : base() { }
		//public PokeBattle_Move_05F(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (attacker.Ability == Abilities.MULTITYPE)
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			if (opponent.lastMoveUsed <= 0
				//|| Types.isPseudoType(Kernal.MoveData[(Moves)opponent.lastMoveUsed].Type)
			   )
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			if (opponent.OwnSide.CraftyShield)
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			List<Types> types = new List<Types>();//[]

			Types atype = opponent.lastMoveUsedType;
			if (atype < 0)
			{

				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			for (int i = 0; i < Kernal.TypeData.Count; i++)
			{
				//if (Types.isPseudoType((Types)i)) continue;
				if (attacker.HasType((Types)i)) continue; //next
				if (atype.GetEffectiveness((Types)i) < 2) types.Add((Types)i);
			}
			if (types.Count == 0)
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));

			Types newtype = types[this.battle.Random(types.Count)];
			attacker.Type1 = newtype;
			attacker.Type2 = newtype;

			attacker.effects.Type3 = Types.NONE; //-1;

			string typename = Game._INTL(newtype.ToString(TextScripts.Name));

			_host.StartCoroutine(battle.Display(Game._INTL("{1} transformed into the {2} type!", attacker.ToString(), typename)));
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// Changes user's type depending on the environment. (Camouflage)
	/// <summary>
	public partial class PokeBattle_Move_060 : PokeBattle_Move
	{
		public PokeBattle_Move_060() : base() { }
		//public PokeBattle_Move_060(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (attacker.Ability == Abilities.MULTITYPE)
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			Types type = Types.NORMAL;
			switch (this.battle.environment)
			{
				case Environments.None: type = Types.NORMAL; break;
				case Environments.Grass: type = Types.GRASS; break;
				case Environments.TallGrass: type = Types.GRASS; break;
				case Environments.MovingWater: type = Types.WATER; break;
				case Environments.StillWater: type = Types.WATER; break;
				case Environments.Underwater: type = Types.WATER; break;
				case Environments.Cave: type = Types.ROCK; break;
				case Environments.Rock: type = Types.GROUND; break;
				case Environments.Sand: type = Types.GROUND; break;
				case Environments.Forest: type = Types.BUG; break;
				case Environments.Snow: type = Types.ICE; break;
				case Environments.Volcano: type = Types.FIRE; break;
				case Environments.Graveyard: type = Types.GHOST; break;
				case Environments.Sky: type = Types.FLYING; break;
				case Environments.Space: type = Types.DRAGON; break;
				default: break;
			}
			if (this.battle.field.ElectricTerrain > 0)
			{
				type = Types.ELECTRIC;
			}
			else if (this.battle.field.GrassyTerrain > 0)
			{
				type = Types.GRASS;
			}
			else if (this.battle.field.MistyTerrain > 0)
			{
				type = Types.FAIRY;
			}
			if (attacker.HasType(type))
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			_host.StartCoroutine(ShowAnimation(this.id, attacker, null, hitnum, alltargets, showanimation));

			attacker.Type1 = type;
			attacker.Type2 = type;
			attacker.effects.Type3 = Types.NONE; //-1;

			string typename = Game._INTL(type.ToString(TextScripts.Name));

			_host.StartCoroutine(battle.Display(Game._INTL("{1} transformed into the {2} type!", attacker.ToString(), typename)));
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// Target becomes Water type. (Soak)
	/// <summary>
	public partial class PokeBattle_Move_061 : PokeBattle_Move
	{
		public PokeBattle_Move_061() : base() { }
		//public PokeBattle_Move_061(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (opponent.effects.Substitute > 0 && !ignoresSubstitute(attacker))
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			if (TypeImmunityByAbility(GetType(this.type, attacker, opponent), attacker, opponent)) { result(-1); yield break; }
			if (opponent.Ability == Abilities.MULTITYPE)
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));
			if (opponent.Type1 == Types.WATER &&
			   opponent.Type2 == Types.WATER &&
			   (opponent.effects.Type3 < 0 ||
			   opponent.effects.Type3 == Types.WATER))
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			opponent.Type1 = Types.WATER;

			opponent.Type2 = Types.WATER;

			opponent.effects.Type3 = Types.NONE; //-1;
			string typename = Game._INTL(Types.WATER.ToString(TextScripts.Name));
			_host.StartCoroutine(battle.Display(Game._INTL("{1} transformed into the {2} type!", opponent.ToString(), typename)));
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// User copes target's types. (Reflect Type)
	/// <summary>
	public partial class PokeBattle_Move_062 : PokeBattle_Move
	{
		public PokeBattle_Move_062() : base() { }
		//public PokeBattle_Move_062(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (attacker.Ability == Abilities.MULTITYPE)
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			if (attacker.HasType(opponent.Type1) &&
			   attacker.HasType(opponent.Type2) &&
			   attacker.HasType(opponent.effects.Type3) &&
			   opponent.HasType(attacker.Type1) &&
			   opponent.HasType(attacker.Type2) &&
			   opponent.HasType(attacker.effects.Type3))
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));

			attacker.Type1 = opponent.Type1;
			attacker.Type2 = opponent.Type2;
			attacker.effects.Type3 = Types.NONE; //-1;

			_host.StartCoroutine(battle.Display(Game._INTL("{1}'s type changed to match {2}'s!", attacker.ToString(), opponent.ToString(true))));
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// Target's ability becomes Simple. (Simple Beam)
	/// <summary>
	public partial class PokeBattle_Move_063 : PokeBattle_Move
	{
		public PokeBattle_Move_063() : base() { }
		//public PokeBattle_Move_063(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (opponent.effects.Substitute > 0 && !ignoresSubstitute(attacker))
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			if (opponent.Ability == Abilities.MULTITYPE ||
			   opponent.Ability == Abilities.SIMPLE ||
			   opponent.Ability == Abilities.STANCE_CHANGE ||
			   opponent.Ability == Abilities.TRUANT)
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));

			Abilities oldabil = opponent.Ability;
			opponent.Ability = Abilities.SIMPLE;
			string abilityname = Game._INTL(Abilities.SIMPLE.ToString(TextScripts.Name));
			_host.StartCoroutine(battle.Display(Game._INTL("{1} acquired {2}!", opponent.ToString(), abilityname)));
			if (opponent.effects.Illusion.Species != Pokemons.NONE && oldabil == Abilities.ILLUSION)
			{
				GameDebug.Log($"[Ability triggered] #{opponent.ToString()}'s Illusion ended");
				opponent.effects.Illusion = null;
				if (this.battle.scene is IPokeBattle_Scene s0) s0.ChangePokemon(opponent, opponent.pokemon);

				_host.StartCoroutine(battle.Display(Game._INTL("{1}'s {2} wore off!", opponent.ToString(), Game._INTL(oldabil.ToString(TextScripts.Name)))));
			}
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// Target's ability becomes Insomnia. (Worry Seed)
	/// <summary>
	public partial class PokeBattle_Move_064 : PokeBattle_Move
	{
		public PokeBattle_Move_064() : base() { }
		//public PokeBattle_Move_064(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (opponent.effects.Substitute > 0 && !ignoresSubstitute(attacker))
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			if (TypeImmunityByAbility(GetType(this.type, attacker, opponent), attacker, opponent)) { result(-1); yield break; }
			if (opponent.Ability == Abilities.MULTITYPE ||
			   opponent.Ability == Abilities.INSOMNIA ||
			   opponent.Ability == Abilities.STANCE_CHANGE ||
			   opponent.Ability == Abilities.TRUANT)
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));

			Abilities oldabil = opponent.Ability;
			opponent.Ability = Abilities.INSOMNIA;
			string abilityname = Game._INTL(Abilities.INSOMNIA.ToString(TextScripts.Name));
			_host.StartCoroutine(battle.Display(Game._INTL("{1} acquired {2}!", opponent.ToString(), abilityname)));
			if (opponent.effects.Illusion.Species != Pokemons.NONE && oldabil == Abilities.ILLUSION)
			{
				GameDebug.Log($"[Ability triggered] #{opponent.ToString()}'s Illusion ended");
				opponent.effects.Illusion = null;
				if (this.battle.scene is IPokeBattle_Scene s0) s0.ChangePokemon(opponent, opponent.pokemon);

				_host.StartCoroutine(battle.Display(Game._INTL("{1}'s {2} wore off!", opponent.ToString(), Game._INTL(oldabil.ToString(TextScripts.Name)))));
			}
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// User copies target's ability. (Role Play)
	/// <summary>
	public partial class PokeBattle_Move_065 : PokeBattle_Move
	{
		public PokeBattle_Move_065() : base() { }
		//public PokeBattle_Move_065(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (opponent.OwnSide.CraftyShield)
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			if (opponent.Ability == 0 ||
			   attacker.Ability == opponent.Ability ||
			   attacker.Ability == Abilities.MULTITYPE ||
			   attacker.Ability == Abilities.STANCE_CHANGE ||
			   opponent.Ability == Abilities.FLOWER_GIFT ||
			   opponent.Ability == Abilities.FORECAST ||
			   opponent.Ability == Abilities.ILLUSION ||
			   opponent.Ability == Abilities.IMPOSTER ||
			   opponent.Ability == Abilities.MULTITYPE ||
			   opponent.Ability == Abilities.STANCE_CHANGE ||
			   opponent.Ability == Abilities.TRACE ||
			   opponent.Ability == Abilities.WONDER_GUARD ||
			   opponent.Ability == Abilities.ZEN_MODE)
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));

			Abilities oldabil = attacker.Ability;
			attacker.Ability = opponent.Ability;
			string abilityname = Game._INTL(opponent.Ability.ToString(TextScripts.Name));

			_host.StartCoroutine(battle.Display(Game._INTL("{1} copied {2}'s {3}!", attacker.ToString(), opponent.ToString(true), abilityname)));
			if (attacker.effects.Illusion.Species != Pokemons.NONE && oldabil == Abilities.ILLUSION)
			{
				GameDebug.Log($"[Ability triggered] #{attacker.ToString()}'s Illusion ended");
				attacker.effects.Illusion = null;
				if (this.battle.scene is IPokeBattle_Scene s0) s0.ChangePokemon(attacker, attacker.pokemon);

				_host.StartCoroutine(battle.Display(Game._INTL("{1}'s {2} wore off!", attacker.ToString(), Game._INTL(oldabil.ToString(TextScripts.Name)))));
			}
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// Target copies user's ability. (Entrainment)
	/// <summary>
	public partial class PokeBattle_Move_066 : PokeBattle_Move
	{
		public PokeBattle_Move_066() : base() { }
		//public PokeBattle_Move_066(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (opponent.effects.Substitute > 0 && !ignoresSubstitute(attacker))
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			if (opponent.OwnSide.CraftyShield)
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			if (attacker.Ability == 0 ||
			   attacker.Ability == opponent.Ability ||
			   opponent.Ability == Abilities.FLOWER_GIFT ||
			   opponent.Ability == Abilities.IMPOSTER ||
			   opponent.Ability == Abilities.MULTITYPE ||
			   opponent.Ability == Abilities.STANCE_CHANGE ||
			   opponent.Ability == Abilities.TRACE ||
			   opponent.Ability == Abilities.TRUANT ||
			   opponent.Ability == Abilities.ZEN_MODE ||
			   attacker.Ability == Abilities.FLOWER_GIFT ||
			   attacker.Ability == Abilities.FORECAST ||
			   attacker.Ability == Abilities.ILLUSION ||
			   attacker.Ability == Abilities.IMPOSTER ||
			   attacker.Ability == Abilities.MULTITYPE ||
			   attacker.Ability == Abilities.STANCE_CHANGE ||
			   attacker.Ability == Abilities.TRACE ||
			   attacker.Ability == Abilities.ZEN_MODE)
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));

			Abilities oldabil = opponent.Ability;
			opponent.Ability = attacker.Ability;
			string abilityname = Game._INTL(attacker.Ability.ToString(TextScripts.Name));

			_host.StartCoroutine(battle.Display(Game._INTL("{1} acquired {2}!", opponent.ToString(), abilityname)));
			if (opponent.effects.Illusion.Species != Pokemons.NONE && oldabil == Abilities.ILLUSION)
			{
				GameDebug.Log($"[Ability triggered] #{opponent.ToString()}'s Illusion ended");
				opponent.effects.Illusion = null;
				if (this.battle.scene is IPokeBattle_Scene s0) s0.ChangePokemon(opponent, opponent.pokemon);

				_host.StartCoroutine(battle.Display(Game._INTL("{1}'s {2} wore off!", opponent.ToString(), Game._INTL(oldabil.ToString(TextScripts.Name)))));
			}
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// User and target swap abilities. (Skill Swap)
	/// <summary>
	public partial class PokeBattle_Move_067 : PokeBattle_Move
	{
		public PokeBattle_Move_067() : base() { }
		//public PokeBattle_Move_067(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if ((attacker.Ability == 0 && opponent.Ability == 0) ||
			   (attacker.Ability == opponent.Ability && !Core.USENEWBATTLEMECHANICS) ||
			   attacker.Ability == Abilities.ILLUSION ||
			   opponent.Ability == Abilities.ILLUSION ||
			   attacker.Ability == Abilities.MULTITYPE ||
			   opponent.Ability == Abilities.MULTITYPE ||
			   attacker.Ability == Abilities.STANCE_CHANGE ||
			   opponent.Ability == Abilities.STANCE_CHANGE ||
			   attacker.Ability == Abilities.WONDER_GUARD ||
			   opponent.Ability == Abilities.WONDER_GUARD)
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));

			Abilities tmp = attacker.Ability;
			attacker.Ability = opponent.Ability;
			opponent.Ability = tmp;

			_host.StartCoroutine(battle.Display(Game._INTL("{1} swapped its {2} Ability with its target's {3} Ability!",
			   attacker.ToString(), Game._INTL(opponent.Ability.ToString(TextScripts.Name)),
			   Game._INTL(attacker.Ability.ToString(TextScripts.Name)))));
			attacker.AbilitiesOnSwitchIn(true);
			opponent.AbilitiesOnSwitchIn(true);
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// Target's ability is negated. (Gastro Acid)
	/// <summary>
	public partial class PokeBattle_Move_068 : PokeBattle_Move
	{
		public PokeBattle_Move_068() : base() { }
		//public PokeBattle_Move_068(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (opponent.effects.Substitute > 0 && !ignoresSubstitute(attacker))
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			if (opponent.Ability == Abilities.MULTITYPE ||
			   opponent.Ability == Abilities.STANCE_CHANGE)
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));

			Abilities oldabil = opponent.Ability;
			opponent.effects.GastroAcid = true;
			opponent.effects.Truant = false;

			_host.StartCoroutine(battle.Display(Game._INTL("{1}'s Ability was suppressed!", opponent.ToString())));
			if (opponent.effects.Illusion.Species != Pokemons.NONE && oldabil == Abilities.ILLUSION)
			{
				GameDebug.Log($"[Ability triggered] #{opponent.ToString()}'s Illusion ended");
				opponent.effects.Illusion = null;
				if (this.battle.scene is IPokeBattle_Scene s0) s0.ChangePokemon(opponent, opponent.pokemon);

				_host.StartCoroutine(battle.Display(Game._INTL("{1}'s {2} wore off!", opponent.ToString(), Game._INTL(oldabil.ToString(TextScripts.Name)))));
			}
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// User transforms into the target. (Transform)
	/// <summary>
	public partial class PokeBattle_Move_069 : PokeBattle_Move
	{
		public PokeBattle_Move_069() : base() { }
		//public PokeBattle_Move_069(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{

			List<Attack.Effects> blacklist = new List<Attack.Effects>{
			   Attack.Effects.x09C,   // Fly
			   Attack.Effects.x101,   // Dig
			   Attack.Effects.x100,   // Dive
			   Attack.Effects.x108,   // Bounce
			   //Attack.Effects.x111, // Shadow Force
			   Attack.Effects.x138,   // Sky Drop
			   Attack.Effects.x111    // Phantom Force
			};
			if (attacker.effects.Transform ||
			   opponent.effects.Transform ||
			   opponent.effects.Illusion.Species != Pokemons.NONE ||
			   (opponent.effects.Substitute > 0 && !ignoresSubstitute(attacker)) ||
			   opponent.effects.SkyDrop ||
			   blacklist.Contains(Kernal.MoveData[(Moves)opponent.effects.TwoTurnAttack].Effect))
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			if (opponent.OwnSide.CraftyShield)
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));

			attacker.effects.Transform = true;
			attacker.Type1 = opponent.Type1;
			attacker.Type2 = opponent.Type2;
			attacker.effects.Type3 = Types.NONE; //-1;

			attacker.Ability = opponent.Ability;

			attacker.ATK = opponent.ATK;

			attacker.DEF = opponent.DEF;

			attacker.SPE = opponent.SPE;

			attacker.SPA = opponent.SPA;

			attacker.SPD = opponent.SPD;
			foreach (var i in new[] { Stats.ATTACK, Stats.DEFENSE, Stats.SPEED,
				  Stats.SPATK, Stats.SPDEF, Stats.ACCURACY, Stats.EVASION })
			{
				attacker.stages[(byte)i] = opponent.stages[(byte)i];
			}

			for (int i = 0; i < 4; i++)
			{
				attacker.moves[i] = Combat.Move.FromMove(
					@battle, new Attack.Move(opponent.moves[i].id));
				attacker.moves[i].PP = 5;
				attacker.moves[i].TotalPP = 5;
			}
			attacker.effects.Disable = 0;

			attacker.effects.DisableMove = 0;

			_host.StartCoroutine(battle.Display(Game._INTL("{1} transformed into {2}!", attacker.ToString(), opponent.ToString(true))));
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// Inflicts a fixed 20HP damage. (SonicBoom)
	/// <summary>
	public partial class PokeBattle_Move_06A : PokeBattle_Move
	{
		public PokeBattle_Move_06A() : base() { }
		//public PokeBattle_Move_06A(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			result(EffectFixedDamage(20, attacker, opponent, hitnum, alltargets, showanimation));
			yield break;
		}
	}

	/// <summary>
	/// Inflicts a fixed 40HP damage. (Dragon Rage)
	/// <summary>
	public partial class PokeBattle_Move_06B : PokeBattle_Move
	{
		public PokeBattle_Move_06B() : base() { }
		//public PokeBattle_Move_06B(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			result(EffectFixedDamage(40, attacker, opponent, hitnum, alltargets, showanimation));
			yield break;
		}
	}

	/// <summary>
	/// Halves the target's current HP. (Super Fang)
	/// <summary>
	public partial class PokeBattle_Move_06C : PokeBattle_Move
	{
		public PokeBattle_Move_06C() : base() { }
		//public PokeBattle_Move_06C(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			result(EffectFixedDamage((int)Math.Max(Math.Floor(opponent.HP / 2f), 1), attacker, opponent, hitnum, alltargets, showanimation));
			yield break;
		}
	}

	/// <summary>
	/// Inflicts damage equal to the user's level. (Night Shade, Seismic Toss)
	/// <summary>
	public partial class PokeBattle_Move_06D : PokeBattle_Move
	{
		public PokeBattle_Move_06D() : base() { }
		//public PokeBattle_Move_06D(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			result(EffectFixedDamage(attacker.Level, attacker, opponent, hitnum, alltargets, showanimation));
			yield break;
		}
	}

	/// <summary>
	/// Inflicts damage to bring the target's HP down to equal the user's HP. (Endeavor)
	/// <summary>
	public partial class PokeBattle_Move_06E : PokeBattle_Move
	{
		public PokeBattle_Move_06E() : base() { }
		//public PokeBattle_Move_06E(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (attacker.HP >= opponent.HP)
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			result(EffectFixedDamage(opponent.HP - attacker.HP, attacker, opponent, hitnum, alltargets, showanimation));
			yield break;
		}
	}

	/// <summary>
	/// Inflicts damage between 0.5 and 1.5 times the user's level. (Psywave)
	/// <summary>
	public partial class PokeBattle_Move_06F : PokeBattle_Move
	{
		public PokeBattle_Move_06F() : base() { }
		//public PokeBattle_Move_06F(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{

			int dmg = (int)Math.Max((attacker.Level * (int)Math.Floor(this.battle.Random(101) + 50f) / 100f), 1);
			result(EffectFixedDamage(dmg, attacker, opponent, hitnum, alltargets, showanimation));
			yield break;
		}
	}

	/// <summary>
	/// OHKO. Accuracy increases by difference between levels of user and target.
	/// <summary>
	public partial class PokeBattle_Move_070 : PokeBattle_Move
	{
		public PokeBattle_Move_070() : base() { }
		//public PokeBattle_Move_070(Battle battle, Attack.Move move) : base(battle, move) { }
		public override bool AccuracyCheck(IBattler attacker, IBattler opponent) { return this.AccuracyCheck((IBattlerIE)attacker, (IBattlerIE)opponent); }
		public bool AccuracyCheck(IBattlerIE attacker, IBattlerIE opponent)
		{
			if (!attacker.hasMoldBreaker() && opponent.hasWorkingAbility(Abilities.STURDY))
			{
				_host.StartCoroutine(battle.Display(Game._INTL("{1} was protected by {2}!", opponent.ToString(), Game._INTL(opponent.Ability.ToString(TextScripts.Name)))));
				return false;
			}
			if (opponent.Level > attacker.Level)
			{
				_host.StartCoroutine(battle.Display(Game._INTL("{1} is unaffected!", opponent.ToString())));
				return false;
			}
			int acc = this.accuracy + attacker.Level - opponent.Level;
			return this.battle.Random(100) < acc;
		}

		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{

			int damage = EffectFixedDamage(opponent.TotalHP, attacker, opponent, hitnum, alltargets, showanimation);
			if (opponent.isFainted())
			{
				_host.StartCoroutine(battle.Display(Game._INTL("It's a one-hit KO!")));
			}
			result(damage);
			yield break;
		}
	}

	/// <summary>
	/// Counters a physical move used against the user this round, with 2x the power. (Counter)
	/// <summary>
	public partial class PokeBattle_Move_071 : PokeBattle_Move
	{
		public PokeBattle_Move_071() : base() { }
		//public PokeBattle_Move_071(Battle battle, Attack.Move move) : base(battle, move) { }
		public override void AddTarget(IList<IBattler> targets, IBattler attacker)
		{
			if (attacker.effects.CounterTarget >= 0 &&
			   attacker.IsOpposing(attacker.effects.CounterTarget))
			{
				if (!attacker.AddTarget(targets, this.battle.battlers[attacker.effects.CounterTarget]))
				{
					attacker.RandomTarget(targets);
				}
			}
		}

		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (attacker.effects.Counter < 0 || opponent.Species == Pokemons.NONE)
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			int ret = EffectFixedDamage(Math.Max(attacker.effects.Counter * 2, 1), attacker, opponent, hitnum, alltargets, showanimation);
			result(ret);
			yield break;
		}
	}

	/// <summary>
	/// Counters a specical move used against the user this round, with 2x the power. (Mirror Coat)
	/// <summary>
	public partial class PokeBattle_Move_072 : PokeBattle_Move
	{
		public PokeBattle_Move_072() : base() { }
		//public PokeBattle_Move_072(Battle battle, Attack.Move move) : base(battle, move) { }
		public override void AddTarget(IList<IBattler> targets, IBattler attacker)
		{
			if (attacker.effects.MirrorCoatTarget >= 0 &&
			   attacker.IsOpposing(attacker.effects.MirrorCoatTarget))
			{
				if (!attacker.AddTarget(targets, this.battle.battlers[attacker.effects.MirrorCoatTarget]))
				{
					attacker.RandomTarget(targets);
				}
			}
		}

		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (attacker.effects.MirrorCoat < 0 || opponent.Species == Pokemons.NONE)
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			int ret = EffectFixedDamage(Math.Max(attacker.effects.MirrorCoat * 2, 1), attacker, opponent, hitnum, alltargets, showanimation);
			result(ret);
			yield break;
		}
	}

	/// <summary>
	/// Counters the last damaging move used against the user this round, with 1.5x
	/// the power. (Metal Burst)
	/// <summary>
	public partial class PokeBattle_Move_073 : PokeBattle_Move
	{
		public PokeBattle_Move_073() : base() { }
		//public PokeBattle_Move_073(Battle battle, Attack.Move move) : base(battle, move) { }
		public override void AddTarget(IList<IBattler> targets, IBattler attacker)
		{
			if (attacker.lastAttacker.Count > 0)
			{
				int lastattacker = attacker.lastAttacker[attacker.lastAttacker.Count - 1];
				if (lastattacker >= 0 && attacker.IsOpposing(lastattacker))
				{
					if (!attacker.AddTarget(targets, this.battle.battlers[lastattacker]))
					{
						attacker.RandomTarget(targets);
					}
				}
			}
		}

		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (attacker.lastHPLost == 0 || opponent.Species == Pokemons.NONE)
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			int ret = EffectFixedDamage((int)Math.Max(Math.Floor(attacker.lastHPLost * 1.5f), 1), attacker, opponent, hitnum, alltargets, showanimation);
			result(ret);
			yield break;
		}
	}

	/// <summary>
	/// The target's ally loses 1/16 of its max HP. (Flame Burst)
	/// <summary>
	public partial class PokeBattle_Move_074 : PokeBattle_Move
	{
		public PokeBattle_Move_074() : base() { }
		//public PokeBattle_Move_074(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			int ret = -1; _host.StartCoroutine(base.GetEffect(attacker, opponent, hitnum, alltargets, showanimation, result:value=>ret=value)); result(ret);
			if (opponent.damagestate.CalcDamage > 0)
			{
				if (opponent.Partner.IsNotNullOrNone() && !opponent.Partner.isFainted() &&
				   !opponent.Partner.hasWorkingAbility(Abilities.MAGIC_GUARD))
				{
					opponent.Partner.ReduceHP((int)Math.Floor(opponent.Partner.TotalHP / 16f));
					_host.StartCoroutine(battle.Display(Game._INTL("The bursting flame hit {1}!", opponent.Partner.ToString(true))));
				}
			}
			result(ret);
			yield break;
		}
	}

	/// <summary>
	/// Power is doubled if the target is using Dive. (Surf)
	/// (Handled in Pokemon's SuccessCheck): Hits some semi-invulnerable targets.
	/// <summary>
	public partial class PokeBattle_Move_075 : PokeBattle_Move
	{
		public PokeBattle_Move_075() : base() { }
		//public PokeBattle_Move_075(Battle battle, Attack.Move move) : base(battle, move) { }
		public int ModifyDamage(int damagemult, IBattler attacker, IBattler opponent)
		{
			if (Kernal.MoveData[(Moves)opponent.effects.TwoTurnAttack].Effect == Attack.Effects.x100)	// Dive
			{
				return (int)Math.Round(damagemult * 2.0f);
			}
			return damagemult;
		}
	}

	/// <summary>
	/// Power is doubled if the target is using Dig. Power is halved if Grassy Terrain
	/// is in effect. (Earthquake)
	/// (Handled in Pokemon's SuccessCheck): Hits some semi-invulnerable targets.
	/// <summary>
	public partial class PokeBattle_Move_076 : PokeBattle_Move
	{
		public PokeBattle_Move_076() : base() { }
		//public PokeBattle_Move_076(Battle battle, Attack.Move move) : base(battle, move) { }
		public int ModifyDamage(int damagemult, IBattler attacker, IBattler opponent)
		{
			int ret = damagemult;
			if (Kernal.MoveData[(Moves)opponent.effects.TwoTurnAttack].Effect == Attack.Effects.x101)   // Dig
			{
				ret = (int)Math.Round(damagemult * 2.0f);
			}
			if (this.battle.field.GrassyTerrain > 0)
			{
				ret = (int)Math.Round(damagemult / 2.0f);
			}
			return ret;
		}
	}

	/// <summary>
	/// Power is doubled if the target is using Bounce, Fly or Sky Drop. (Gust)
	/// (Handled in Pokemon's SuccessCheck): Hits some semi-invulnerable targets.
	/// <summary>
	public partial class PokeBattle_Move_077 : PokeBattle_Move
	{
		public PokeBattle_Move_077() : base() { }
		//public PokeBattle_Move_077(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int BaseDamage(int basedmg, IBattler attacker, IBattler opponent)
		{
			if (Kernal.MoveData[(Moves)opponent.effects.TwoTurnAttack].Effect == Attack.Effects.x09C || // Fly
				Kernal.MoveData[(Moves)opponent.effects.TwoTurnAttack].Effect == Attack.Effects.x108 || // Bounce
				Kernal.MoveData[(Moves)opponent.effects.TwoTurnAttack].Effect == Attack.Effects.x138 || // Sky Drop
			   opponent.effects.SkyDrop)
			{
				return basedmg * 2;
			}
			return basedmg;
		}
	}

	/// <summary>
	/// Power is doubled if the target is using Bounce, Fly or Sky Drop. (Twister)
	/// May make the target flinch.
	/// (Handled in Pokemon's SuccessCheck): Hits some semi-invulnerable targets.
	/// <summary>
	public partial class PokeBattle_Move_078 : PokeBattle_Move
	{
		public PokeBattle_Move_078() : base() { }
		//public PokeBattle_Move_078(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int BaseDamage(int basedmg, IBattler attacker, IBattler opponent)
		{
			if (Kernal.MoveData[(Moves)opponent.effects.TwoTurnAttack].Effect == Attack.Effects.x09C || // Fly
				Kernal.MoveData[(Moves)opponent.effects.TwoTurnAttack].Effect == Attack.Effects.x108 || // Bounce
				Kernal.MoveData[(Moves)opponent.effects.TwoTurnAttack].Effect == Attack.Effects.x138 || // Sky Drop
			   opponent.effects.SkyDrop)
			{
				return basedmg * 2;
			}
			return basedmg;
		}

		public override void AdditionalEffect(IBattler attacker, IBattler opponent)
		{
			if (opponent.damagestate.Substitute) return;
			if (opponent is IBattlerEffectIE o) o.Flinch(attacker);
		}
	}

	/// <summary>
	/// Power is doubled if Fusion Flare has already been used this round. (Fusion Bolt)
	/// <summary>
	public partial class PokeBattle_Move_079 : PokeBattle_Move
	{
		public PokeBattle_Move_079() : base() { }
		//public PokeBattle_Move_079(Battle battle, Attack.Move move) : base(battle, move) { }
		public int BaseDamageMultiplier(int damagemult, IBattler attacker, IBattler opponent)
		{
			if (this.battle.field.FusionBolt)
			{
				this.battle.field.FusionBolt = false;
				this.doubled = true;
				return (int)Math.Round(damagemult * 2.0f);
			}
			return damagemult;
		}

		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			this.doubled = false;
			int ret = -1; _host.StartCoroutine(base.GetEffect(attacker, opponent, hitnum, alltargets, showanimation, result:value=>ret=value)); result(ret);
			if (opponent.damagestate.CalcDamage > 0)
			{
				this.battle.field.FusionFlare = true;
			}
			result(ret);
			yield break;
		}

		public override void ShowAnimation(Moves id, IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true)
		{
			if (opponent.damagestate.Critical || this.doubled)
			{
				base.ShowAnimation(id, attacker, opponent, 1, alltargets, showanimation); // Charged anim;
			}
			base.ShowAnimation(id, attacker, opponent, hitnum, alltargets, showanimation);
		}
	}

	/// <summary>
	/// Power is doubled if Fusion Bolt has already been used this round. (Fusion Flare)
	/// <summary>
	public partial class PokeBattle_Move_07A : PokeBattle_Move
	{
		public PokeBattle_Move_07A() : base() { }
		//public PokeBattle_Move_07A(Battle battle, Attack.Move move) : base(battle, move) { }
		public int BaseDamageMultiplier(int damagemult, IBattler attacker, IBattler opponent)
		{
			if (battle.field.FusionFlare)
			{
				this.battle.field.FusionFlare = false;
				return (int)Math.Round(damagemult * 2.0f);
			}
			return damagemult;
		}

		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{

			int ret = -1; _host.StartCoroutine(base.GetEffect(attacker, opponent, hitnum, alltargets, showanimation, result:value=>ret=value)); result(ret);
			if (opponent.damagestate.CalcDamage > 0)
			{
				this.battle.field.FusionBolt = true;
			}
			result(ret);
			yield break;
		}

		public override void ShowAnimation(Moves id, IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true)
		{
			if (opponent.damagestate.Critical || this.doubled)
			{
				base.ShowAnimation(id, attacker, opponent, 1, alltargets, showanimation); // Charged anim;
			}
			base.ShowAnimation(id, attacker, opponent, hitnum, alltargets, showanimation);
		}
	}

	/// <summary>
	/// Power is doubled if the target is poisoned. (Venoshock)
	/// <summary>
	public partial class PokeBattle_Move_07B : PokeBattle_Move
	{
		public PokeBattle_Move_07B() : base() { }
		//public PokeBattle_Move_07B(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int BaseDamage(int basedmg, IBattler attacker, IBattler opponent)
		{
			if (opponent.Status == Status.POISON &&
			   (opponent.effects.Substitute == 0 || ignoresSubstitute(attacker)))
			{
				return basedmg * 2;
			}
			return basedmg;
		}
	}

	/// <summary>
	/// Power is doubled if the target is paralyzed. Cures the target of paralysis.
	/// (SmellingSalt)
	/// <summary>
	public partial class PokeBattle_Move_07C : PokeBattle_Move
	{
		public PokeBattle_Move_07C() : base() { }
		//public PokeBattle_Move_07C(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int BaseDamage(int basedmg, IBattler attacker, IBattler opponent)
		{
			if (opponent.Status == Status.PARALYSIS &&
			   (opponent.effects.Substitute == 0 || ignoresSubstitute(attacker)))
			{
				return basedmg * 2;
			}
			return basedmg;
		}

		public override void EffectAfterHit(IBattler attacker, IBattler opponent, IEffectsMove turneffects) { this.EffectAfterHit((IBattlerIE)attacker, (IBattlerIE)opponent, turneffects); }
		public override IEnumerator EffectAfterHit(IBattlerIE attacker, IBattlerIE opponent, IEffectsMove turneffects)
		{
			if (!opponent.isFainted() && opponent.damagestate.CalcDamage > 0 &&
			   !opponent.damagestate.Substitute && opponent.Status == Status.PARALYSIS && opponent is IBattlerEffectIE b)
			{
				b.CureStatus();
			}
			yield break;
		}
	}

	/// <summary>
	/// Power is doubled if the target is asleep. Wakes the target up. (Wake-Up Slap)
	/// <summary>
	public partial class PokeBattle_Move_07D : PokeBattle_Move
	{
		public PokeBattle_Move_07D() : base() { }
		//public PokeBattle_Move_07D(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int BaseDamage(int basedmg, IBattler attacker, IBattler opponent)
		{
			if (opponent.Status == Status.SLEEP &&
			   (opponent.effects.Substitute == 0 || ignoresSubstitute(attacker)))
			{
				return basedmg * 2;
			}
			return basedmg;
		}

		public override void EffectAfterHit(IBattler attacker, IBattler opponent, IEffectsMove turneffects) { this.EffectAfterHit((IBattlerIE)attacker, (IBattlerIE)opponent, turneffects); }
		public override IEnumerator EffectAfterHit(IBattlerIE attacker, IBattlerIE opponent, IEffectsMove turneffects)
		{
			if (!opponent.isFainted() && opponent.damagestate.CalcDamage > 0 &&
			   !opponent.damagestate.Substitute && opponent.Status == Status.SLEEP && opponent is IBattlerEffectIE b)
			{
				b.CureStatus();
			}
			yield break;
		}
	}

	/// <summary>
	/// Power is doubled if the user is burned, poisoned or paralyzed. (Facade)
	/// <summary>
	public partial class PokeBattle_Move_07E : PokeBattle_Move
	{
		public PokeBattle_Move_07E() : base() { }
		//public PokeBattle_Move_07E(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int BaseDamage(int basedmg, IBattler attacker, IBattler opponent)
		{
			if (attacker.Status == Status.POISON ||
			   attacker.Status == Status.BURN ||
			   attacker.Status == Status.PARALYSIS)
			{
				return basedmg * 2;
			}
			return basedmg;
		}
	}

	/// <summary>
	/// Power is doubled if the target has a status problem. (Hex)
	/// <summary>
	public partial class PokeBattle_Move_07F : PokeBattle_Move
	{
		public PokeBattle_Move_07F() : base() { }
		//public PokeBattle_Move_07F(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int BaseDamage(int basedmg, IBattler attacker, IBattler opponent)
		{
			if (opponent.Status > 0 &&
			   (opponent.effects.Substitute == 0 || ignoresSubstitute(attacker)))
			{
				return basedmg * 2;
			}
			return basedmg;
		}
	}

	/// <summary>
	/// Power is doubled if the target's HP is down to 1/2 or less. (Brine)
	/// <summary>
	public partial class PokeBattle_Move_080 : PokeBattle_Move
	{
		public PokeBattle_Move_080() : base() { }
		//public PokeBattle_Move_080(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int BaseDamage(int basedmg, IBattler attacker, IBattler opponent)
		{
			if (opponent.HP <= opponent.TotalHP / 2)
			{
				return basedmg * 2;
			}
			return basedmg;
		}
	}

	/// <summary>
	/// Power is doubled if the user has lost HP due to the target's move this round.
	/// (Revenge, Avalanche)
	/// <summary>
	public partial class PokeBattle_Move_081 : PokeBattle_Move
	{
		public PokeBattle_Move_081() : base() { }
		//public PokeBattle_Move_081(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int BaseDamage(int basedmg, IBattler attacker, IBattler opponent)
		{
			if (attacker.lastHPLost > 0 && attacker.lastAttacker.Contains((int)opponent.Index))
			{
				return basedmg * 2;
			}
			return basedmg;
		}
	}

	/// <summary>
	/// Power is doubled if the target has already lost HP this round. (Assurance)
	/// <summary>
	public partial class PokeBattle_Move_082 : PokeBattle_Move
	{
		public PokeBattle_Move_082() : base() { }
		//public PokeBattle_Move_082(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int BaseDamage(int basedmg, IBattler attacker, IBattler opponent)
		{
			if (opponent.tookDamage)
			{
				return basedmg * 2;
			}
			return basedmg;
		}
	}

	/// <summary>
	/// Power is doubled if a user's ally has already used this move this round. (Round)
	/// If an ally is about to use the same move, make it go next, ignoring priority.
	/// <summary>
	public partial class PokeBattle_Move_083 : PokeBattle_Move
	{
		public PokeBattle_Move_083() : base() { }
		//public PokeBattle_Move_083(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int BaseDamage(int basedmg, IBattler attacker, IBattler opponent)
		{

			int ret = basedmg;
			for (int i = 0; i <= attacker.OwnSide.Round; i++)
			{

				ret *= 2;

			}
			return ret;
		}

		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			int ret = -1; _host.StartCoroutine(base.GetEffect(attacker, opponent, hitnum, alltargets, showanimation, result:value=>ret=value)); result(ret);
			if (opponent.damagestate.CalcDamage > 0)
			{
				attacker.OwnSide.Round += 1;
				if (attacker.Partner.IsNotNullOrNone() && !attacker.Partner.hasMovedThisRound())
				{
					if ((int)this.battle.choices[attacker.Partner.Index].Action == 1)	// Will use a move
					{
						IBattleMove partnermove = this.battle.choices[attacker.Partner.Index].Move;
						if (partnermove.Effect == this.Effect)
						{
							attacker.Partner.effects.MoveNext = true;
							attacker.Partner.effects.Quash = false;
						}
					}
				}
			}
			result(ret);
			yield break;
		}
	}

	/// <summary>
	/// Power is doubled if the target has already moved this round. (Payback)
	/// <summary>
	public partial class PokeBattle_Move_084 : PokeBattle_Move
	{
		public PokeBattle_Move_084() : base() { }
		//public PokeBattle_Move_084(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int BaseDamage(int basedmg, IBattler attacker, IBattler opponent)
		{
			if ((int)this.battle.choices[opponent.Index].Action != 1 || // Didn't choose a move
			   opponent.hasMovedThisRound())	// Used a move already
			{
				return basedmg * 2;
			}
			return basedmg;
		}
	}

	/// <summary>
	/// Power is doubled if a user's teammate fainted last round. (Retaliate)
	/// <summary>
	public partial class PokeBattle_Move_085 : PokeBattle_Move
	{
		public PokeBattle_Move_085() : base() { }
		//public PokeBattle_Move_085(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int BaseDamage(int basedmg, IBattler attacker, IBattler opponent)
		{
			if (attacker.OwnSide.LastRoundFainted >= 0 &&
			   attacker.OwnSide.LastRoundFainted == this.battle.turncount - 1)
			{
				return basedmg * 2;
			}
			return basedmg;
		}
	}

	/// <summary>
	/// Power is doubled if the user has no held item. (Acrobatics)
	/// <summary>
	public partial class PokeBattle_Move_086 : PokeBattle_Move
	{
		public PokeBattle_Move_086() : base() { }
		//public PokeBattle_Move_086(Battle battle, Attack.Move move) : base(battle, move) { }
		public int BaseDamageMultiplier(int damagemult, IBattler attacker, IBattler opponent)
		{
			if (attacker.Item == 0)
			{
				return (int)Math.Round(damagemult * 2.0f);
			}
			return damagemult;
		}
	}

	/// <summary>
	/// Power is doubled in weather. Type changes depending on the weather. (Weather Ball)
	/// <summary>
	public partial class PokeBattle_Move_087 : PokeBattle_Move
	{
		public PokeBattle_Move_087() : base() { }
		//public PokeBattle_Move_087(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int BaseDamage(int basedmg, IBattler attacker, IBattler opponent)
		{
			if (this.battle.Weather != 0)
			{
				return basedmg * 2;
			}
			return basedmg;
		}

		public override Types ModifyType(Types type, IBattler attacker, IBattler opponent)
		{

			type = Types.NORMAL;
			switch (this.battle.Weather)
			{
				case Weather.SUNNYDAY:
				case Weather.HARSHSUN:
					type = (Types.FIRE); break;

				case Weather.RAINDANCE:
				case Weather.HEAVYRAIN:
					type = (Types.WATER); break;

				case Weather.SANDSTORM:
					type = (Types.ROCK); break;

				case Weather.HAIL:
					type = (Types.ICE); break;
				default: break;
			}
			return type;
		}
	}

	/// <summary>
	/// Power is doubled if a foe tries to switch out or use U-turn/Volt Switch/
	/// Parting Shot. (Pursuit)
	/// (Handled in Battle's AttackPhase): Makes this attack happen before switching.
	/// <summary>
	public partial class PokeBattle_Move_088 : PokeBattle_Move
	{
		public PokeBattle_Move_088() : base() { }
		//public PokeBattle_Move_088(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int BaseDamage(int basedmg, IBattler attacker, IBattler opponent)
		{
			if (this.battle.switching)
			{
				return basedmg * 2;
			}
			return basedmg;
		}

		public override bool AccuracyCheck(IBattler attacker, IBattler opponent) { return this.AccuracyCheck((IBattlerIE)attacker, (IBattlerIE)opponent); }
		public bool AccuracyCheck(IBattlerIE attacker, IBattlerIE opponent)
		{
			if (this.battle.switching) return true;
			return base.AccuracyCheck(attacker, opponent);
		}
	}

	/// <summary>
	/// Power increases with the user's happiness. (Return)
	/// <summary>
	public partial class PokeBattle_Move_089 : PokeBattle_Move
	{
		public PokeBattle_Move_089() : base() { }
		//public PokeBattle_Move_089(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int BaseDamage(int basedmg, IBattler attacker, IBattler opponent)
		{
			return (int)Math.Max(Math.Floor(attacker.Happiness * 2 / 5f), 1);
		}
	}

	/// <summary>
	/// Power decreases with the user's happiness. (Frustration)
	/// <summary>
	public partial class PokeBattle_Move_08A : PokeBattle_Move
	{
		public PokeBattle_Move_08A() : base() { }
		//public PokeBattle_Move_08A(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int BaseDamage(int basedmg, IBattler attacker, IBattler opponent)
		{
			return (int)Math.Max(Math.Floor((255 - attacker.Happiness) * 2f / 5f), 1);
		}
	}

	/// <summary>
	/// Power increases with the user's HP. (Eruption, Water Spout)
	/// <summary>
	public partial class PokeBattle_Move_08B : PokeBattle_Move
	{
		public PokeBattle_Move_08B() : base() { }
		//public PokeBattle_Move_08B(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int BaseDamage(int basedmg, IBattler attacker, IBattler opponent)
		{
			return (int)Math.Max(Math.Floor(150f * attacker.HP / attacker.TotalHP), 1);
		}
	}

	/// <summary>
	/// Power increases with the target's HP. (Crush Grip, Wring Out)
	/// <summary>
	public partial class PokeBattle_Move_08C : PokeBattle_Move
	{
		public PokeBattle_Move_08C() : base() { }
		//public PokeBattle_Move_08C(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int BaseDamage(int basedmg, IBattler attacker, IBattler opponent)
		{
			return (int)Math.Max(Math.Floor(120f * opponent.HP / opponent.TotalHP), 1);
		}
	}

	/// <summary>
	/// Power increases the quicker the target is than the user. (Gyro Ball)
	/// <summary>
	public partial class PokeBattle_Move_08D : PokeBattle_Move
	{
		public PokeBattle_Move_08D() : base() { }
		//public PokeBattle_Move_08D(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int BaseDamage(int basedmg, IBattler attacker, IBattler opponent)
		{
			return (int)Math.Max(Math.Min(Math.Floor(25f * opponent.SPE / attacker.SPE), 150), 1);
		}
	}

	/// <summary>
	/// Power increases with the user's positive stat changes (ignores negative ones).
	/// (Stored Power)
	/// <summary>
	public partial class PokeBattle_Move_08E : PokeBattle_Move
	{
		public PokeBattle_Move_08E() : base() { }
		//public PokeBattle_Move_08E(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int BaseDamage(int basedmg, IBattler attacker, IBattler opponent)
		{

			int mult = 1;
			foreach (Stats i in new[] { Stats.ATTACK, Stats.DEFENSE, Stats.SPEED,
				  Stats.SPATK, Stats.SPDEF, Stats.ACCURACY, Stats.EVASION })
			{
				if (attacker.stages[(byte)i] > 0) mult += attacker.stages[(byte)i];
			}
			return 20 * mult;
		}
	}

	/// <summary>
	/// Power increases with the target's positive stat changes (ignores negative ones).
	/// (Punishment)
	/// <summary>
	public partial class PokeBattle_Move_08F : PokeBattle_Move
	{
		public PokeBattle_Move_08F() : base() { }
		//public PokeBattle_Move_08F(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int BaseDamage(int basedmg, IBattler attacker, IBattler opponent)
		{
			int mult = 3;
			foreach (var i in new[] { Stats.ATTACK, Stats.DEFENSE, Stats.SPEED,
					  Stats.SPATK, Stats.SPDEF, Stats.ACCURACY, Stats.EVASION })
			{
				if (opponent.stages[(byte)i] > 0) mult += opponent.stages[(byte)i];
			}
			return Math.Min(20 * mult, 200);
		}
	}

	/// <summary>
	/// Power and type depends on the user's IVs. (Hidden Power)
	/// <summary>
	public partial class PokeBattle_Move_090 : PokeBattle_Move
	{
		public PokeBattle_Move_090() : base() { }
		//public PokeBattle_Move_090(Battle battle, Attack.Move move) : base(battle, move) { }
		public override Types ModifyType(Types type, IBattler attacker, IBattler opponent)
		{
			KeyValuePair<Types,int> hp = HiddenPower(attacker.IV);

			type = (Types)hp.Key;
			return type;
		}

		public override int BaseDamage(int basedmg, IBattler attacker, IBattler opponent)
		{
			if (Core.USENEWBATTLEMECHANICS) return 60;
			KeyValuePair<Types,int> hp = HiddenPower(attacker.IV);
			return hp.Value;
		}

		public static KeyValuePair<Types,int> HiddenPower(int[] iv) //ToDo: Move to another class?
		{
			byte powermin = 30;
			byte powermax = 70;
			int type = 0; int baseY = 0;
			List<Types> types = new List<Types>();
			for (int i = 0; i < Kernal.TypeData.Count; i++)
			{
				if (//!Types.isPseudoType((Types)i) &&
					(Types)i != Types.NORMAL && (Types)i != Types.SHADOW) types.Add((Types)i);
			}
			//Types[] types = Kernal.TypeData.Keys.ToArray();
			type |= (iv[(int)Stats.HP] & 1);
			type |= (iv[(int)Stats.ATTACK] & 1) << 1;
			type |= (iv[(int)Stats.DEFENSE] & 1) << 2;
			type |= (iv[(int)Stats.SPEED] & 1) << 3;
			type |= (iv[(int)Stats.SPATK] & 1) << 4;
			type |= (iv[(int)Stats.SPDEF] & 1) << 5;
			type = (int)Math.Floor(type * (types.Count - 1f) / 63f);
			Types hptype = types[type];
			baseY |= (iv[(int)Stats.HP] & 2) >> 1;
			baseY |= (iv[(int)Stats.ATTACK] & 2);
			baseY |= (iv[(int)Stats.DEFENSE] & 2) << 1;
			baseY |= (iv[(int)Stats.SPEED] & 2) << 2;
			baseY |= (iv[(int)Stats.SPATK] & 2) << 3;
			baseY |= (iv[(int)Stats.SPDEF] & 2) << 4;
			baseY = (int)Math.Floor(baseY * (powermax - powermin) / 63f) + powermin;
			return new KeyValuePair<Types,int>(hptype, baseY); //return type, and power
		}
	}

	/// <summary>
	/// Power doubles for each consecutive use. (Fury Cutter)
	/// <summary>
	public partial class PokeBattle_Move_091 : PokeBattle_Move
	{
		public PokeBattle_Move_091() : base() { }
		//public PokeBattle_Move_091(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int BaseDamage(int basedmg, IBattler attacker, IBattler opponent)
		{

			basedmg = basedmg << (attacker.effects.FuryCutter - 1); // can be 1 to 4
			return basedmg;
		}
	}

	/// <summary>
	/// Power is multiplied by the number of consecutive rounds in which this move was
	/// used by any Pokémon on the user's side. (Echoed Voice)
	/// <summary>
	public partial class PokeBattle_Move_092 : PokeBattle_Move
	{
		public PokeBattle_Move_092() : base() { }
		//public PokeBattle_Move_092(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int BaseDamage(int basedmg, IBattler attacker, IBattler opponent)
		{

			basedmg *= attacker.OwnSide.EchoedVoiceCounter; // can be 1 to 5
			return basedmg;
		}
	}

	/// <summary>
	/// User rages until the start of a round in which they don't use this move. (Rage)
	/// (Handled in Pokemon's ProcessMoveAgainstTarget): Ups rager's Attack by 1
	/// stage each time it loses HP due to a move.
	/// <summary>
	public partial class PokeBattle_Move_093 : PokeBattle_Move
	{
		public PokeBattle_Move_093() : base() { }
		//public PokeBattle_Move_093(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{

			int ret = -1; base.GetEffect(attacker, opponent, hitnum, alltargets, showanimation, result:value=>ret=value); result(ret);

			if (ret > 0) attacker.effects.Rage = true;
			result(ret);
			yield break;
		}
	}

	/// <summary>
	/// Randomly damages or heals the target. (Present)
	/// <summary>
	public partial class PokeBattle_Move_094 : PokeBattle_Move
	{
		public bool forcedamage { get; set; }
		public PokeBattle_Move_094() : base() { }
		//public PokeBattle_Move_094(Battle battle, Attack.Move move) : base(battle, move) { }
		public override bool OnStartUse(IBattler attacker)
		{
			// Just to ensure that Parental Bond's second hit damages if the first hit does
			this.forcedamage = false;
			return true;
		}

		public override int BaseDamage(int basedmg, IBattler attacker, IBattler opponent)
		{
			this.forcedamage = true;
			return this.calcbasedmg;
		}

		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			this.calcbasedmg = 1;
			byte r = (byte)this.battle.Random((this.forcedamage) ? 8 : 10);
			if (r < 4)
				this.calcbasedmg = 40;
			else if (r < 7)
				this.calcbasedmg = 80;
			else if (r < 8)
				this.calcbasedmg = 120;
			else
			{
				if (TypeModifier(GetType(this.type, attacker, opponent), attacker, opponent) == 0)
				{
					_host.StartCoroutine(battle.Display(Game._INTL("It doesn't affect {1}...", opponent.ToString(true))));
					result(-1);
					yield break;
				}
				if (opponent.HP == opponent.TotalHP)
				{
					_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
					result(-1);
					yield break;
				}
				int damage = CalcDamage(attacker, opponent); // Consumes Gems even if it will heal
				_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, 1, alltargets, showanimation)); // Healing animation
				opponent.RecoverHP((int)Math.Floor(opponent.TotalHP / 4f), true);
				_host.StartCoroutine(battle.Display(Game._INTL("{1} had its HP restored.", opponent.ToString())));
				result(0);
				yield break;
			}
			int ret = -1; _host.StartCoroutine(base.GetEffect(attacker, opponent, hitnum, alltargets, showanimation, result:value=>ret=value)); result(ret);
			yield break;
		}
	}

	/// <summary>
	/// Power is chosen at random. Power is doubled if the target is using Dig. (Magnitude)
	/// (Handled in Pokemon's SuccessCheck): Hits some semi-invulnerable targets.
	/// <summary>
	public partial class PokeBattle_Move_095 : PokeBattle_Move
	{
		public PokeBattle_Move_095() : base() { }
		//public PokeBattle_Move_095(Battle battle, Attack.Move move) : base(battle, move) { }
		public override bool OnStartUse(IBattler attacker)
		{

			byte[] basedmg = new byte[] { 10, 30, 50, 70, 90, 110, 150 };
			byte[] magnitudes = new byte[] {
			   4,
			   5,5,
			   6,6,6,6,
			   7,7,7,7,7,7,
			   8,8,8,8,
			   9,9,
			   10
			};
			byte magni = magnitudes[this.battle.Random(magnitudes.Length)];
			this.calcbasedmg = basedmg[magni - 4];

			_host.StartCoroutine(battle.Display(Game._INTL("Magnitude {1}!", ((int)magni).ToString())));
			return true;
		}

		public override int BaseDamage(int basedmg, IBattler attacker, IBattler opponent)
		{

			int ret = this.calcbasedmg;
			if (Kernal.MoveData[(Moves)opponent.effects.TwoTurnAttack].Effect == Attack.Effects.x101)	// Dig
			{
				ret *= 2;
			}
			if (this.battle.field.GrassyTerrain > 0)
			{
				ret = (int)Math.Round(ret / 2.0f);
			}
			return ret;
		}
	}

	/// <summary>
	/// Power and type depend on the user's held berry. Destroys the berry. (Natural Gift)
	/// <summary>
	public partial class PokeBattle_Move_096 : PokeBattle_Move
	{
		public Items berry { get; set; }
		public PokeBattle_Move_096() : base() { }
		//public PokeBattle_Move_096(Battle battle, Attack.Move move) : base(battle, move) { }
		public override bool OnStartUse(IBattler attacker)
		{
			if (Game.GameData is IItemCheck i && !i.IsBerry(attacker.Item) ||
			   attacker.effects.Embargo > 0 ||
			   this.battle.field.MagicRoom > 0 ||
			   attacker.hasWorkingAbility(Abilities.KLUTZ) ||
			   attacker.Opposing1.hasWorkingAbility(Abilities.UNNERVE) ||
			   attacker.Opposing2.hasWorkingAbility(Abilities.UNNERVE))
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				return false;
			}
			this.berry = attacker.Item;
			return true;
		}

		public override int BaseDamage(int basedmg, IBattler attacker, IBattler opponent)
		{

			Dictionary<Items, byte> damagearray = new Dictionary<Items, byte>{
			//60 => [
					{ Items.CHERI_BERRY, 60 },  { Items.CHESTO_BERRY, 60 }, { Items.PECHA_BERRY, 60 },  { Items.RAWST_BERRY, 60 },  { Items.ASPEAR_BERRY, 60 },
					{ Items.LEPPA_BERRY, 60 },  { Items.ORAN_BERRY, 60 },   { Items.PERSIM_BERRY, 60 }, { Items.LUM_BERRY, 60 },    { Items.SITRUS_BERRY, 60 },
					{ Items.FIGY_BERRY, 60 },   { Items.WIKI_BERRY, 60 },   { Items.MAGO_BERRY, 60 },   { Items.AGUAV_BERRY, 60 },  { Items.IAPAPA_BERRY, 60 },
					{ Items.RAZZ_BERRY, 60 },   { Items.OCCA_BERRY, 60 },   { Items.PASSHO_BERRY, 60 }, { Items.WACAN_BERRY, 60 },  { Items.RINDO_BERRY, 60 },
					{ Items.YACHE_BERRY, 60 },  { Items.CHOPLE_BERRY, 60 }, { Items.KEBIA_BERRY, 60 },  { Items.SHUCA_BERRY, 60 },  { Items.COBA_BERRY, 60 },
					{ Items.PAYAPA_BERRY, 60 }, { Items.TANGA_BERRY, 60 },  { Items.CHARTI_BERRY, 60 }, { Items.KASIB_BERRY, 60 },  { Items.HABAN_BERRY, 60 },
					{ Items.COLBUR_BERRY, 60 }, { Items.BABIRI_BERRY, 60 }, { Items.CHILAN_BERRY, 60 }, { Items.ROSELI_BERRY, 60 },
			//70 => [
					{ Items.BLUK_BERRY, 70 },   { Items.NANAB_BERRY, 70 },  { Items.WEPEAR_BERRY, 70 }, { Items.PINAP_BERRY, 70 },  { Items.POMEG_BERRY, 70 },
					{ Items.KELPSY_BERRY, 70 }, { Items.QUALOT_BERRY, 70 }, { Items.HONDEW_BERRY, 70 }, { Items.GREPA_BERRY, 70 },  { Items.TAMATO_BERRY, 70 },
					{ Items.CORNN_BERRY, 70 },  { Items.MAGOST_BERRY, 70 }, { Items.RABUTA_BERRY, 70 }, { Items.NOMEL_BERRY, 70 },  { Items.SPELON_BERRY, 70 },
					{ Items.PAMTRE_BERRY, 70 },
			//80 => [
					{ Items.WATMEL_BERRY, 80 }, { Items.DURIN_BERRY, 80 },  { Items.BELUE_BERRY, 80 },  { Items.LIECHI_BERRY, 80 }, { Items.GANLON_BERRY, 80 },
					{ Items.SALAC_BERRY, 80 },  { Items.PETAYA_BERRY, 80 }, { Items.APICOT_BERRY, 80 }, { Items.LANSAT_BERRY, 80 }, { Items.STARF_BERRY, 80 },
					{ Items.ENIGMA_BERRY, 80 }, { Items.MICLE_BERRY, 80 },  { Items.CUSTAP_BERRY, 80 }, { Items.JABOCA_BERRY, 80 }, { Items.ROWAP_BERRY, 80 },
					{ Items.KEE_BERRY, 80 },    { Items.MARANGA_BERRY, 80 }
			};
			foreach (Items i in damagearray.Keys)
			{
				//byte data = damagearray[i];
				//if (data != null){
				//	foreach (var j in data){
						if (this.berry == i)
						{
							int ret = damagearray[i];

							if (Core.USENEWBATTLEMECHANICS) ret += 20;
							return ret;
						}
				//	}
				//}
			}
			return 1;
		}

		public override Types ModifyType(Types type, IBattler attacker, IBattler opponent)
		{

			type = Types.NORMAL;
			Dictionary<Items, Types> typearray = new Dictionary<Items, Types> {
			   //:NORMAL =>
							{ Items.CHILAN_BERRY, Types.NORMAL },
			   //:FIRE	 =>
							{ Items.CHERI_BERRY, Types.FIRE },		{ Items.BLUK_BERRY, Types.FIRE },		{ Items.WATMEL_BERRY, Types.FIRE },		{ Items.OCCA_BERRY, Types.FIRE },
			   //:WATER	 =>
							{ Items.CHESTO_BERRY, Types.WATER },	{ Items.NANAB_BERRY, Types.WATER },		{ Items.DURIN_BERRY, Types.WATER },		{ Items.PASSHO_BERRY, Types.WATER },
			   //:ELECTRIC =>
							{ Items.PECHA_BERRY, Types.ELECTRIC },	{ Items.WEPEAR_BERRY, Types.ELECTRIC },	{ Items.BELUE_BERRY, Types.ELECTRIC },	{ Items.WACAN_BERRY, Types.ELECTRIC },
			   //:GRASS	 =>
							{ Items.RAWST_BERRY, Types.GRASS },		{ Items.PINAP_BERRY, Types.GRASS },		{ Items.RINDO_BERRY, Types.GRASS },		{ Items.LIECHI_BERRY, Types.GRASS },
			   //:ICE	 =>
							{ Items.ASPEAR_BERRY, Types.ICE },		{ Items.POMEG_BERRY, Types.ICE },		{ Items.YACHE_BERRY, Types.ICE },		{ Items.GANLON_BERRY, Types.ICE },
			   //:FIGHTING =>
							{ Items.LEPPA_BERRY, Types.FIGHTING },	{ Items.KELPSY_BERRY, Types.FIGHTING },	{ Items.CHOPLE_BERRY, Types.FIGHTING },	{ Items.SALAC_BERRY, Types.FIGHTING },
			   //:POISON =>
							{ Items.ORAN_BERRY, Types.POISON },		{ Items.QUALOT_BERRY, Types.POISON },	{ Items.KEBIA_BERRY, Types.POISON },	{ Items.PETAYA_BERRY, Types.POISON },
			   //:GROUND =>
							{ Items.PERSIM_BERRY, Types.GROUND },	{ Items.HONDEW_BERRY, Types.GROUND },	{ Items.SHUCA_BERRY, Types.GROUND },	{ Items.APICOT_BERRY, Types.GROUND },
			   //:FLYING =>
							{ Items.LUM_BERRY, Types.FLYING },		{ Items.GREPA_BERRY, Types.FLYING },	{ Items.COBA_BERRY, Types.FLYING },		{ Items.LANSAT_BERRY, Types.FLYING },
			   //:PSYCHIC=>
							{ Items.SITRUS_BERRY, Types.PSYCHIC },	{ Items.TAMATO_BERRY, Types.PSYCHIC },	{ Items.PAYAPA_BERRY, Types.PSYCHIC },	{ Items.STARF_BERRY, Types.PSYCHIC },
			   //:BUG	 =>
							{ Items.FIGY_BERRY, Types.BUG },		{ Items.CORNN_BERRY, Types.BUG },		{ Items.TANGA_BERRY, Types.BUG },		{ Items.ENIGMA_BERRY, Types.BUG },
			   //:ROCK	 =>
							{ Items.WIKI_BERRY, Types.ROCK },		{ Items.MAGOST_BERRY, Types.ROCK },		{ Items.CHARTI_BERRY, Types.ROCK },		{ Items.MICLE_BERRY, Types.ROCK },
			   //:GHOST	 =>
							{ Items.MAGO_BERRY, Types.GHOST },		{ Items.RABUTA_BERRY, Types.GHOST },	{ Items.KASIB_BERRY, Types.GHOST },		{ Items.CUSTAP_BERRY, Types.GHOST },
			   //:DRAGON =>
							{ Items.AGUAV_BERRY, Types.DRAGON },	{ Items.NOMEL_BERRY, Types.DRAGON },	{ Items.HABAN_BERRY, Types.DRAGON },	{ Items.JABOCA_BERRY, Types.DRAGON },
			   //:DARK	 =>
							{ Items.IAPAPA_BERRY, Types.DARK },		{ Items.SPELON_BERRY, Types.DARK },		{ Items.COLBUR_BERRY, Types.DARK },		{ Items.ROWAP_BERRY, Types.DARK },		{ Items.MARANGA_BERRY, Types.DARK },
			   //:STEEL	 =>
							{ Items.RAZZ_BERRY, Types.STEEL },		{ Items.PAMTRE_BERRY, Types.STEEL },	{ Items.BABIRI_BERRY, Types.STEEL },
			   //:FAIRY	 =>
							{ Items.ROSELI_BERRY, Types.FAIRY },	{ Items.KEE_BERRY, Types.FAIRY }
			};
			foreach (Items i in typearray.Keys)
			{
				//data = typearray[i];;
				//if (data != null){
				//	foreach (var j in data){
						if (this.berry == i)
						{
							type = typearray[i];//i;
						}
				//	}
				//}
			}
			return type;
		}

		public override void EffectAfterHit(IBattler attacker, IBattler opponent, IEffectsMove turneffects) { this.EffectAfterHit((IBattlerIE)attacker, (IBattlerIE)opponent, turneffects); }
		public override IEnumerator EffectAfterHit(IBattlerIE attacker, IBattlerIE opponent, IEffectsMove turneffects)
		{
			if (turneffects.TotalDamage > 0)
			{
				_host.StartCoroutine(attacker.ConsumeItem());
			}
			yield break;
		}
	}

	/// <summary>
	/// Power increases the less PP this move has. (Trump Card)
	/// <summary>
	public partial class PokeBattle_Move_097 : PokeBattle_Move
	{
		public PokeBattle_Move_097() : base() { }
		//public PokeBattle_Move_097(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int BaseDamage(int basedmg, IBattler attacker, IBattler opponent)
		{
			int[] dmgs = new int[] { 200, 80, 60, 50, 40 };

			int ppleft = Math.Min(this.PP, 4);  // PP is reduced before the move is used
			basedmg = dmgs[ppleft];
			return basedmg;
		}
	}

	/// <summary>
	/// Power increases the less HP the user has. (Flail, Reversal)
	/// <summary>
	public partial class PokeBattle_Move_098 : PokeBattle_Move
	{
		public PokeBattle_Move_098() : base() { }
		//public PokeBattle_Move_098(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int BaseDamage(int basedmg, IBattler attacker, IBattler opponent)
		{
			byte n = (byte)Math.Floor(48f * attacker.HP / attacker.TotalHP);

			int ret = 20;
			if (n < 33) ret = 40;
			if (n < 17) ret = 80;
			if (n < 10) ret = 100;
			if (n < 5) ret = 150;
			if (n < 2) ret = 200;
			return ret;
		}
	}

	/// <summary>
	/// Power increases the quicker the user is than the target. (Electro Ball)
	/// <summary>
	public partial class PokeBattle_Move_099 : PokeBattle_Move
	{
		public PokeBattle_Move_099() : base() { }
		//public PokeBattle_Move_099(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int BaseDamage(int basedmg, IBattler attacker, IBattler opponent)
		{
			int n = (int)Math.Floor(Math.Max(attacker.SPE, 1f) / Math.Max(opponent.SPE, 1f));

			int ret = 60;
			if (n >= 2) ret = 80;
			if (n >= 3) ret = 120;
			if (n >= 4) ret = 150;
			return ret;
		}
	}

	/// <summary>
	/// Power increases the heavier the target is. (Grass Knot, Low Kick)
	/// <summary>
	public partial class PokeBattle_Move_09A : PokeBattle_Move
	{
		public PokeBattle_Move_09A() : base() { }
		//public PokeBattle_Move_09A(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int BaseDamage(int basedmg, IBattler attacker, IBattler opponent)
		{
			float weight = opponent.Weight(attacker);

			int ret = 20;
			if (weight >= 100) ret = 40;
			if (weight >= 250) ret = 60;
			if (weight >= 500) ret = 80;
			if (weight >= 1000) ret = 100;
			if (weight >= 2000) ret = 120;
			return ret;
		}
	}

	/// <summary>
	/// Power increases the heavier the user is than the target. (Heat Crash, Heavy Slam)
	/// <summary>
	public partial class PokeBattle_Move_09B : PokeBattle_Move
	{
		public PokeBattle_Move_09B() : base() { }
		//public PokeBattle_Move_09B(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int BaseDamage(int basedmg, IBattler attacker, IBattler opponent)
		{
			int n = (int)Math.Floor((float)attacker.Weight(attacker) / (float)opponent.Weight(attacker));

			int ret = 40;
			if (n >= 2) ret = 60;
			if (n >= 3) ret = 80;
			if (n >= 4) ret = 100;
			if (n >= 5) ret = 120;
			return ret;
		}
	}

	/// <summary>
	/// Powers up the ally's attack this round by 1.5. (Helping Hand)
	/// <summary>
	public partial class PokeBattle_Move_09C : PokeBattle_Move
	{
		public PokeBattle_Move_09C() : base() { }
		//public PokeBattle_Move_09C(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (!this.battle.doublebattle || opponent.isFainted() ||
			   (int)this.battle.choices[opponent.Index].Action != 1 || // Didn't choose a move;
			   opponent.hasMovedThisRound() ||
			   opponent.effects.HelpingHand)
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));

			opponent.effects.HelpingHand = true;
			_host.StartCoroutine(battle.Display(Game._INTL("{1} is ready to help {2}!", attacker.ToString(), opponent.ToString(true))));
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// Weakens Electric attacks. (Mud Sport)
	/// <summary>
	public partial class PokeBattle_Move_09D : PokeBattle_Move
	{
		public PokeBattle_Move_09D() : base() { }
		//public PokeBattle_Move_09D(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (Core.USENEWBATTLEMECHANICS)
			{
				if (this.battle.field.MudSportField > 0)
				{
					_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
					result(-1);
					yield break;
				}
				_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));

				this.battle.field.MudSportField = 5;
				_host.StartCoroutine(battle.Display(Game._INTL("Electricity's power was weakened!")));
				result(0);
				yield break;
			}
			else
			{
				for (int i = 0; i < 4; i++)
				{
					if (attacker.battle.battlers[i].effects.MudSport)
					{
						_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
						result(-1);
						yield break;
					}
				}

				_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));

				attacker.effects.MudSport = true;
				_host.StartCoroutine(battle.Display(Game._INTL("Electricity's power was weakened!")));
				result(0);
				yield break;
			}
			result(-1);
			yield break;
		}
	}

	/// <summary>
	/// Weakens Fire attacks. (Water Sport)
	/// <summary>
	public partial class PokeBattle_Move_09E : PokeBattle_Move
	{
		public PokeBattle_Move_09E() : base() { }
		//public PokeBattle_Move_09E(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (Core.USENEWBATTLEMECHANICS)
			{
				if (this.battle.field.WaterSportField > 0)
				{
					_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
					result(-1);
					yield break;
				}
				_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));

				this.battle.field.WaterSportField = 5;
				_host.StartCoroutine(battle.Display(Game._INTL("Fire's power was weakened!")));
				result(0);
				yield break;
			}
			else
			{
				for (int i = 0; i < 4; i++)
				{
					if (attacker.battle.battlers[i].effects.WaterSport)
					{
						_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
						result(-1);
						yield break;
					}
				}

				_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));

				attacker.effects.WaterSport = true;
				_host.StartCoroutine(battle.Display(Game._INTL("Fire's power was weakened!")));
				result(0);
				yield break;
			}
		}
	}

	/// <summary>
	/// Type depends on the user's held item. (Judgment, Techno Blast)
	/// <summary>
	public partial class PokeBattle_Move_09F : PokeBattle_Move
	{
		public PokeBattle_Move_09F() : base() { }
		//public PokeBattle_Move_09F(Battle battle, Attack.Move move) : base(battle, move) { }
		public override Types ModifyType(Types type, IBattler attacker, IBattler opponent)
		{
			if (this.id == Moves.JUDGMENT)
			{
				if (attacker.Item == Items.FIST_PLATE) return (Types.FIGHTING);
				if (attacker.Item == Items.SKY_PLATE) return (Types.FLYING);
				if (attacker.Item == Items.TOXIC_PLATE) return (Types.POISON);
				if (attacker.Item == Items.EARTH_PLATE) return (Types.GROUND);
				if (attacker.Item == Items.STONE_PLATE) return (Types.ROCK);
				if (attacker.Item == Items.INSECT_PLATE) return (Types.BUG);
				if (attacker.Item == Items.SPOOKY_PLATE) return (Types.GHOST);
				if (attacker.Item == Items.IRON_PLATE) return (Types.STEEL);
				if (attacker.Item == Items.FLAME_PLATE) return (Types.FIRE);
				if (attacker.Item == Items.SPLASH_PLATE) return (Types.WATER);
				if (attacker.Item == Items.MEADOW_PLATE) return (Types.GRASS);
				if (attacker.Item == Items.ZAP_PLATE) return (Types.ELECTRIC);
				if (attacker.Item == Items.MIND_PLATE) return (Types.PSYCHIC);
				if (attacker.Item == Items.ICICLE_PLATE) return (Types.ICE);
				if (attacker.Item == Items.DRACO_PLATE) return (Types.DRAGON);
				if (attacker.Item == Items.DREAD_PLATE) return (Types.DARK);
				if (attacker.Item == Items.PIXIE_PLATE) return (Types.FAIRY);
			}
			else if (this.id == Moves.TECHNO_BLAST)
			{
				if (attacker.Item == Items.SHOCK_DRIVE) return Types.ELECTRIC;
				if (attacker.Item == Items.BURN_DRIVE) return Types.FIRE;
				if (attacker.Item == Items.CHILL_DRIVE) return Types.ICE;
				if (attacker.Item == Items.DOUSE_DRIVE) return Types.WATER;
			}
			return (Types.NORMAL);
		}

		public override void ShowAnimation(Moves id, IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true)
		{
			if (id == Moves.TECHNO_BLAST)
			{
				byte anim = 0;
				if (GetType(this.type, attacker, opponent) == Types.ELECTRIC) anim = 1;
				if (GetType(this.type, attacker, opponent) == Types.FIRE) anim = 2;
				if (GetType(this.type, attacker, opponent) == Types.ICE) anim = 3;
				if (GetType(this.type, attacker, opponent) == Types.WATER) anim = 4;
				base.ShowAnimation(id, attacker, opponent, anim, alltargets, showanimation); // Type-specific anim
			}
			base.ShowAnimation(id, attacker, opponent, hitnum, alltargets, showanimation);
		}
	}

	/// <summary>
	/// This attack is always a critical hit. (Frost Breath, Storm Throw)
	/// <summary>
	public partial class PokeBattle_Move_0A0 : PokeBattle_Move
	{
		public PokeBattle_Move_0A0() : base() { }
		//public PokeBattle_Move_0A0(Battle battle, Attack.Move move) : base(battle, move) { }
		public override bool CritialOverride(IBattler attacker, IBattler opponent)
		{
			return true;
		}
	}

	/// <summary>
	/// For 5 rounds, foes' attacks cannot become critical hits. (Lucky Chant)
	/// <summary>
	public partial class PokeBattle_Move_0A1 : PokeBattle_Move
	{
		public PokeBattle_Move_0A1() : base() { }
		//public PokeBattle_Move_0A1(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (attacker.OwnSide.LuckyChant > 0)
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));

			attacker.OwnSide.LuckyChant = 5;
			if (!this.battle.IsOpposing(attacker.Index))
			{
				_host.StartCoroutine(battle.Display(Game._INTL("The Lucky Chant shielded your team from critical hits!")));
			}
			else
			{
				_host.StartCoroutine(battle.Display(Game._INTL("The Lucky Chant shielded the opposing team from critical hits!")));
			}
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// For 5 rounds, lowers power of physical attacks against the user's side. (Reflect)
	/// <summary>
	public partial class PokeBattle_Move_0A2 : PokeBattle_Move
	{
		public PokeBattle_Move_0A2() : base() { }
		//public PokeBattle_Move_0A2(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (attacker.OwnSide.Reflect > 0)
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));

			attacker.OwnSide.Reflect = 5;
			if (attacker.hasWorkingItem(Items.LIGHT_CLAY)) attacker.OwnSide.Reflect = 8;
			if (!this.battle.IsOpposing(attacker.Index))
			{
				_host.StartCoroutine(battle.Display(Game._INTL("Reflect raised your team's Defense!")));
			}
			else
			{
				_host.StartCoroutine(battle.Display(Game._INTL("Reflect raised the opposing team's Defense!")));
			}
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// For 5 rounds, lowers power of special attacks against the user's side. (Light Screen)
	/// <summary>
	public partial class PokeBattle_Move_0A3 : PokeBattle_Move
	{
		public PokeBattle_Move_0A3() : base() { }
		//public PokeBattle_Move_0A3(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (attacker.OwnSide.LightScreen > 0)
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));

			attacker.OwnSide.LightScreen = 5;
			if (attacker.hasWorkingItem(Items.LIGHT_CLAY)) attacker.OwnSide.Reflect = 8;
			if (!this.battle.IsOpposing(attacker.Index))
			{
				_host.StartCoroutine(battle.Display(Game._INTL("Light Screen raised your team's Special Defense!")));
			}
			else
			{
				_host.StartCoroutine(battle.Display(Game._INTL("Light Screen raised the opposing team's Special Defense!")));
			}
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// Effect depends on the environment. (Secret Power)
	/// <summary>
	public partial class PokeBattle_Move_0A4 : PokeBattle_Move
	{
		public PokeBattle_Move_0A4() : base() { }
		//public PokeBattle_Move_0A4(Battle battle, Attack.Move move) : base(battle, move) { }
		public override void AdditionalEffect(IBattler attacker, IBattler opponent)
		{
			if (opponent.damagestate.Substitute) return;
			if (this.battle.field.ElectricTerrain > 0)
			{
				if (opponent is IBattlerEffect b && b.CanParalyze(attacker, false, this))
				{
					b.Paralyze(attacker);
				}
				return;
			}
			else if (this.battle.field.GrassyTerrain > 0)
			{
				if (opponent is IBattlerClause b && b.CanSleep(attacker, false, this))
				{
					if (opponent is IBattlerEffectIE o) _host.StartCoroutine(o.Sleep());
				}
				return;
			}
			else if (this.battle.field.MistyTerrain > 0)
			{
				if (opponent is IBattlerEffect b && b.CanReduceStatStage(Stats.SPATK, attacker, false, this))
				{
					b.ReduceStat(Stats.SPATK, 1, attacker, false, this);
				}
				return;
			}
			IBattlerEffect obe = opponent is IBattlerEffect ? opponent as IBattlerEffect : null;
			switch (this.battle.environment)
			{
				case Environments.Grass:
				case Environments.TallGrass:
				case Environments.Forest:
					if (obe is IBattlerClause b && (b?.CanSleep(attacker, false, this)??false))
					{
						obe.Sleep();
					}
					break;
				case Environments.MovingWater:
				case Environments.Underwater:
					if (obe?.CanReduceStatStage(Stats.ATTACK, attacker, false, this)??false)
					{
						obe.ReduceStat(Stats.ATTACK, 1, attacker, false, this);
					}
					break;
				case Environments.StillWater:
				case Environments.Sky:
					if (obe?.CanReduceStatStage(Stats.SPEED, attacker, false, this)??false)
					{
						obe.ReduceStat(Stats.SPEED, 1, attacker, false, this);
					}
					break;
				case Environments.Sand:
					if (obe?.CanReduceStatStage(Stats.ACCURACY, attacker, false, this)??false)
					{
						obe.ReduceStat(Stats.ACCURACY, 1, attacker, false, this);
					}
					break;
				case Environments.Rock:
					if (Core.USENEWBATTLEMECHANICS)
					{
						if (obe?.CanReduceStatStage(Stats.ACCURACY, attacker, false, this)??false)
						{
							obe.ReduceStat(Stats.ACCURACY, 1, attacker, false, this);
						}
					}
					else
					if (opponent.effects.Substitute == 0 || ignoresSubstitute(attacker))
					{
						obe.Flinch(attacker);
					}
					break;
				case Environments.Cave:
				case Environments.Graveyard:
				case Environments.Space:
					if (opponent.effects.Substitute == 0 || ignoresSubstitute(attacker))
					{
						obe.Flinch(attacker);
					}
					break;
				case Environments.Snow:
					if (obe is IBattlerClause obc && (obc?.CanFreeze(attacker, false, this)??false))
					{
						obe.Freeze();
					}
					break;
				case Environments.Volcano:
					if (obe?.CanBurn(attacker, false, this)??false)
					{
						obe.Burn(attacker);
					}
					else
					if (obe?.CanParalyze(attacker, false, this)??false)
					{
						obe.Paralyze(attacker);
					}
					break;
				default:
					break;
			}
		}

		public override void ShowAnimation(Moves id, IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true)
		{
			id = Moves.BODY_SLAM;
			if (this.battle.field.ElectricTerrain > 0)
				id = Moves.THUNDER_SHOCK;
			else if (this.battle.field.GrassyTerrain > 0)
				id = Moves.VINE_WHIP;
			else if (this.battle.field.MistyTerrain > 0)
				id = Moves.FAIRY_WIND;
			else
				switch (this.battle.environment)
				{
					case Environments.Grass:
					case Environments.TallGrass:
						id = (Core.USENEWBATTLEMECHANICS) ? Moves.VINE_WHIP : Moves.NEEDLE_ARM; break;
					case Environments.MovingWater: id = Moves.WATER_PULSE; break;
					case Environments.StillWater: id = Moves.MUD_SHOT; break;
					case Environments.Underwater: id = Moves.WATER_PULSE; break;
					case Environments.Cave: id = Moves.ROCK_THROW; break;
					case Environments.Rock: id = Moves.MUD_SLAP; break;
					case Environments.Sand: id = Moves.MUD_SLAP; break;
					case Environments.Forest: id = Moves.RAZOR_LEAF; break;
					// Ice tiles in Gen 6 should be Ice Shard
					case Environments.Snow: id = Moves.AVALANCHE; break;
					case Environments.Volcano: id = Moves.INCINERATE; break;
					case Environments.Graveyard: id = Moves.SHADOW_SNEAK; break;
					case Environments.Sky: id = Moves.GUST; break;
					case Environments.Space: id = Moves.SWIFT; break;
					default: break;
				}

			base.ShowAnimation(id, attacker, opponent, hitnum, alltargets, showanimation); // Environment-specific anim;
		}
	}

	/// <summary>
	/// Always hits.
	/// <summary>
	public partial class PokeBattle_Move_0A5 : PokeBattle_Move
	{
		public PokeBattle_Move_0A5() : base() { }
		//public PokeBattle_Move_0A5(Battle battle, Attack.Move move) : base(battle, move) { }
		public override bool AccuracyCheck(IBattler attacker, IBattler opponent) { return this.AccuracyCheck((IBattlerIE)attacker, (IBattlerIE)opponent); }
		public bool AccuracyCheck(IBattlerIE attacker, IBattlerIE opponent)
		{
			return true;
		}
	}

	/// <summary>
	/// User's attack next round against the target will definitely hit. (Lock-On, Mind Reader)
	/// <summary>
	public partial class PokeBattle_Move_0A6 : PokeBattle_Move
	{
		public PokeBattle_Move_0A6() : base() { }
		//public PokeBattle_Move_0A6(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (opponent.effects.Substitute > 0 && !ignoresSubstitute(attacker))
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));

			opponent.effects.LockOn = 2;
			opponent.effects.LockOnPos = attacker.Index;
			_host.StartCoroutine(battle.Display(Game._INTL("{1} took aim at {2}!", attacker.ToString(), opponent.ToString(true))));
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// Target's evasion stat changes are ignored from now on. (Foresight, Odor Sleuth)
	/// Normal and Fighting moves have normal effectiveness against the Ghost-type target.
	/// <summary>
	public partial class PokeBattle_Move_0A7 : PokeBattle_Move
	{
		public PokeBattle_Move_0A7() : base() { }
		//public PokeBattle_Move_0A7(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (opponent.OwnSide.CraftyShield)
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));

			opponent.effects.Foresight = true;
			_host.StartCoroutine(battle.Display(Game._INTL("{1} was identified!", opponent.ToString())));
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// Target's evasion stat changes are ignored from now on. (Miracle Eye)
	/// Psychic moves have normal effectiveness against the Dark-type target.
	/// <summary>
	public partial class PokeBattle_Move_0A8 : PokeBattle_Move
	{
		public PokeBattle_Move_0A8() : base() { }
		//public PokeBattle_Move_0A8(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (opponent.OwnSide.CraftyShield)
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));

			opponent.effects.MiracleEye = true;
			_host.StartCoroutine(battle.Display(Game._INTL("{1} was identified!", opponent.ToString())));
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// This move ignores target's Defense, Special Defense and evasion stat changes.
	/// (Chip Away, Sacred Sword)
	/// <summary>
	public partial class PokeBattle_Move_0A9 : PokeBattle_Move
	{
		public PokeBattle_Move_0A9() : base() { }
		//public PokeBattle_Move_0A9(Battle battle, Attack.Move move) : base(battle, move) { }
		// Handled in superclass public bool AccuracyCheck and public object CalcDamage, do not edit!
	}

	/// <summary>
	/// User is protected against moves with the "B" flag this round. (Detect, Protect)
	/// <summary>
	public partial class PokeBattle_Move_0AA : PokeBattle_Move
	{
		public PokeBattle_Move_0AA() : base() { }
		//public PokeBattle_Move_0AA(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			List<Attack.Effects> ratesharers = new List<Attack.Effects> {
				Attack.Effects.x070,   // Detect, Protect
				Attack.Effects.x133,   // Quick Guard
				Attack.Effects.x117,   // Wide Guard
				Attack.Effects.x075,   // Endure
				Attack.Effects.x164,   // King's Shield
				Attack.Effects.x16A    // Spiky Shield
			};
			if (!ratesharers.Contains(Kernal.MoveData[(Moves)attacker.lastMoveUsed].Effect))
			{
				attacker.effects.ProtectRate = 1;
			}
			bool unmoved = false;
			foreach (IBattler poke in this.battle.battlers)
			{
				if (poke.Index == attacker.Index) continue; //next
				if ((int)this.battle.choices[poke.Index].Action == 1 && // Chose a move
				   !poke.hasMovedThisRound())
				{
					unmoved = true; break;
				}
			}
			if (!unmoved ||
			   this.battle.Random(65536) >= Math.Floor(65536f / attacker.effects.ProtectRate))
			{
				attacker.effects.ProtectRate = 1;

				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			_host.StartCoroutine(ShowAnimation(this.id, attacker, null, hitnum, alltargets, showanimation));

			attacker.effects.Protect = true;
			attacker.effects.ProtectRate *= 2;
			_host.StartCoroutine(battle.Display(Game._INTL("{1} protected itself!", attacker.ToString())));
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// User's side is protected against moves with priority greater than 0 this round.
	/// (Quick Guard)
	/// <summary>
	public partial class PokeBattle_Move_0AB : PokeBattle_Move
	{
		public PokeBattle_Move_0AB() : base() { }
		//public PokeBattle_Move_0AB(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (attacker.OwnSide.QuickGuard)
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			List<Attack.Effects> ratesharers = new List<Attack.Effects> {
				Attack.Effects.x070,   // Detect, Protect
				Attack.Effects.x133,   // Quick Guard
				Attack.Effects.x117,   // Wide Guard
				Attack.Effects.x075,   // Endure
				Attack.Effects.x164,   // King's Shield
				Attack.Effects.x16A    // Spiky Shield
			};
			if (!ratesharers.Contains(Kernal.MoveData[(Moves)attacker.lastMoveUsed].Effect))
			{
				attacker.effects.ProtectRate = 1;
			}
			bool unmoved = false;
			foreach (IBattler poke in this.battle.battlers)
			{
				if (poke.Index == attacker.Index) continue; //next
				if ((int)this.battle.choices[poke.Index].Action == 1 && // Chose a move
				   !poke.hasMovedThisRound())
				{
					unmoved = true; break;
				}
			}
			if (!unmoved ||
			   (!Core.USENEWBATTLEMECHANICS &&
			   this.battle.Random(65536) >= Math.Floor(65536f / attacker.effects.ProtectRate)))
			{
				attacker.effects.ProtectRate = 1;
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			_host.StartCoroutine(ShowAnimation(this.id, attacker, null, hitnum, alltargets, showanimation));

			attacker.OwnSide.QuickGuard = true;
			attacker.effects.ProtectRate *= 2;
			if (!this.battle.IsOpposing(attacker.Index))
			{
				_host.StartCoroutine(battle.Display(Game._INTL("Quick Guard protected your team!")));
			}
			else
			{
				_host.StartCoroutine(battle.Display(Game._INTL("Quick Guard protected the opposing team!")));
			}
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// User's side is protected against moves that target multiple battlers this round.
	/// (Wide Guard)
	/// <summary>
	public partial class PokeBattle_Move_0AC : PokeBattle_Move
	{
		public PokeBattle_Move_0AC() : base() { }
		//public PokeBattle_Move_0AC(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (attacker.OwnSide.WideGuard)
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			List<Attack.Effects> ratesharers = new List<Attack.Effects> {
				Attack.Effects.x070,   // Detect, Protect
				Attack.Effects.x133,   // Quick Guard
				Attack.Effects.x117,   // Wide Guard
				Attack.Effects.x075,   // Endure
				Attack.Effects.x164,   // King's Shield
				Attack.Effects.x16A    // Spiky Shield
			};
			if (!ratesharers.Contains(Kernal.MoveData[(Moves)attacker.lastMoveUsed].Effect))
			{
				attacker.effects.ProtectRate = 1;
			}
			bool unmoved = false;
			foreach (IBattler poke in this.battle.battlers)
			{
				if (poke.Index == attacker.Index) continue; //next
				if ((int)this.battle.choices[poke.Index].Action == 1 && // Chose a move
				   !poke.hasMovedThisRound())
				{
					unmoved = true; break;
				}
			}
			if (!unmoved ||
			   (!Core.USENEWBATTLEMECHANICS &&
			   this.battle.Random(65536) >= (int)Math.Floor(65536f / attacker.effects.ProtectRate)))
			{
				attacker.effects.ProtectRate = 1;
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			_host.StartCoroutine(ShowAnimation(this.id, attacker, null, hitnum, alltargets, showanimation));

			attacker.OwnSide.WideGuard = true;
			attacker.effects.ProtectRate *= 2;
			if (!this.battle.IsOpposing(attacker.Index))
			{
				_host.StartCoroutine(battle.Display(Game._INTL("Wide Guard protected your team!")));
			}
			else
			{
				_host.StartCoroutine(battle.Display(Game._INTL("Wide Guard protected the opposing team!")));
			}
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// Ignores target's protections. If successful, all other moves this round
	/// ignore them too. (Feint)
	/// <summary>
	public partial class PokeBattle_Move_0AD : PokeBattle_Move
	{
		public PokeBattle_Move_0AD() : base() { }
		//public PokeBattle_Move_0AD(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			int ret = -1; base.GetEffect(attacker, opponent, hitnum, alltargets, showanimation, result:value=>ret=value); result(ret);
			if (ret > 0)
			{
				opponent.effects.ProtectNegation = true;
				opponent.OwnSide.CraftyShield = false;
			}
			result(ret);
			yield break;
		}
	}

	/// <summary>
	/// Uses the last move that the target used. (Mirror Move)
	/// <summary>
	public partial class PokeBattle_Move_0AE : PokeBattle_Move
	{
		public PokeBattle_Move_0AE() : base() { }
		//public PokeBattle_Move_0AE(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (opponent.lastMoveUsed <= 0 || //(
			   !Kernal.MoveData[(Moves)attacker.lastMoveUsed].Flags.Mirror //& 0x10)==0
			   ) // flag e: Copyable by Mirror Move
			{
				_host.StartCoroutine(battle.Display(Game._INTL("The mirror move failed!")));
				result(-1);
				yield break;
			}
			attacker.UseMoveSimple(opponent.lastMoveUsed, -1, opponent.Index);
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// Uses the last move that was used. (Copycat)
	/// <summary>
	public partial class PokeBattle_Move_0AF : PokeBattle_Move
	{
		public PokeBattle_Move_0AF() : base() { }
		//public PokeBattle_Move_0AF(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			List<Attack.Effects> blacklist = new List<Attack.Effects> {
				Attack.Effects.x0FF,    // Struggle
				Attack.Effects.x03A,    // Transform
				Attack.Effects.x05A,    // Counter
				Attack.Effects.x091,    // Mirror Coat
				Attack.Effects.x0E4,    // Metal Burst
				Attack.Effects.x0B1,    // Helping Hand
				Attack.Effects.x070,    // Detect, Protect
				Attack.Effects.x0E0,    // Feint
				Attack.Effects.x00A,    // Mirror Move
				Attack.Effects.x0F3,    // Copycat
				Attack.Effects.x0C4,    // Snatch
				Attack.Effects.x063,    // Destiny Bond
				Attack.Effects.x075,    // Endure
				Attack.Effects.x13A,    // Circle Throw, Dragon Tail
				Attack.Effects.x06A,    // Covet, Thief
				Attack.Effects.x0B2,    // Switcheroo, Trick
				Attack.Effects.x144,    // Bestow
				Attack.Effects.x0AB,    // Focus Punch
				Attack.Effects.x0AD,    // Follow Me, Rage Powder
				Attack.Effects.x153     // Belch
			};
			if (Core.USENEWBATTLEMECHANICS)
			{
				blacklist.AddRange(new List<Attack.Effects> {
					Attack.Effects.x01D,		// Roar, Whirlwind
													// Two-turn attacks
					Attack.Effects.x028,		// Razor Wind
					Attack.Effects.x098,		// SolarBeam
					Attack.Effects.x14C,		// Freeze Shock
					Attack.Effects.x14D,		// Ice Burn
					Attack.Effects.x04C,		// Sky Attack
					Attack.Effects.x092,		// Skull Bash
					Attack.Effects.x09C,		// Fly
					Attack.Effects.x101,		// Dig
					Attack.Effects.x100,		// Dive
					Attack.Effects.x108,		// Bounce
					//Attack.Effects.x111,		// Shadow Force
					Attack.Effects.x138,		// Sky Drop
					Attack.Effects.x111,		// Phantom Force
					Attack.Effects.x16E		// Geomancy
				});
			}
			if (this.battle.lastMoveUsed <= 0 ||
			   blacklist.Contains(Kernal.MoveData[(Moves)attacker.lastMoveUsed].Effect))
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			attacker.UseMoveSimple(this.battle.lastMoveUsed);
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// Uses the move the target was about to use this round, with 1.5x power. (Me First)
	/// <summary>
	public partial class PokeBattle_Move_0B0 : PokeBattle_Move
	{
		public PokeBattle_Move_0B0() : base() { }
		//public PokeBattle_Move_0B0(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			List<Attack.Effects> blacklist = new List<Attack.Effects> {
				Attack.Effects.x0FF,    // Struggle
				Attack.Effects.x10C,    // Chatter
				Attack.Effects.x05A,    // Counter
				Attack.Effects.x091,    // Mirror Coat
				Attack.Effects.x0E4,    // Metal Burst
				Attack.Effects.x0F2,    // Me First
				Attack.Effects.x06A,    // Covet, Thief
				Attack.Effects.x0AB,    // Focus Punch
				Attack.Effects.x153     // Belch
			};
			IBattleMove oppmove = this.battle.choices[opponent.Index].Move;
			if ((int)this.battle.choices[opponent.Index].Action != 1 || // Didn't choose a move
			   opponent.hasMovedThisRound() ||
			   oppmove.id == Moves.NONE || oppmove.id <= 0 ||
			   oppmove.IsStatus ||
			   blacklist.Contains(oppmove.Effect))
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			attacker.effects.MeFirst = true;

			attacker.UseMoveSimple(oppmove.id);
			attacker.effects.MeFirst = false;
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// This round, reflects all moves with the "C" flag targeting the user back at
	/// their origin. (Magic Coat)
	/// <summary>
	public partial class PokeBattle_Move_0B1 : PokeBattle_Move
	{
		public PokeBattle_Move_0B1() : base() { }
		//public PokeBattle_Move_0B1(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			_host.StartCoroutine(ShowAnimation(this.id, attacker, null, hitnum, alltargets, showanimation));

			attacker.effects.MagicCoat = true;
			_host.StartCoroutine(battle.Display(Game._INTL("{1} shrouded itself with Magic Coat!", attacker.ToString())));
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// This round, snatches all used moves with the "D" flag. (Snatch)
	/// <summary>
	public partial class PokeBattle_Move_0B2 : PokeBattle_Move
	{
		public PokeBattle_Move_0B2() : base() { }
		//public PokeBattle_Move_0B2(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			_host.StartCoroutine(ShowAnimation(this.id, attacker, null, hitnum, alltargets, showanimation));

			attacker.effects.Snatch = true;
			_host.StartCoroutine(battle.Display(Game._INTL("{1} waits for a target to make a move!", attacker.ToString())));
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// Uses a different move depending on the environment. (Nature Power)
	/// <summary>
	public partial class PokeBattle_Move_0B3 : PokeBattle_Move
	{
		public PokeBattle_Move_0B3() : base() { }
		//public PokeBattle_Move_0B3(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			Moves move = Moves.TRI_ATTACK;
			switch (this.battle.environment)
			{
				case Environments.Grass:
				case Environments.TallGrass:
				case Environments.Forest:
					move = (Core.USENEWBATTLEMECHANICS) ? Moves.ENERGY_BALL : Moves.SEED_BOMB; break;

				case Environments.MovingWater: move = Moves.HYDRO_PUMP; break;
				case Environments.StillWater: move = Moves.MUD_BOMB; break;
				case Environments.Underwater: move = Moves.HYDRO_PUMP; break;
				case Environments.Cave:
					move = (Core.USENEWBATTLEMECHANICS) ? Moves.POWER_GEM : Moves.ROCK_SLIDE; break;

				case Environments.Rock:

					move = (Core.USENEWBATTLEMECHANICS) ? Moves.EARTH_POWER : Moves.ROCK_SLIDE; break;

				case Environments.Sand:
					move = (Core.USENEWBATTLEMECHANICS) ? Moves.EARTH_POWER : Moves.EARTHQUAKE; break;
				// Ice tiles in Gen 6 should be Ice Beam
				case Environments.Snow:
					move = (Core.USENEWBATTLEMECHANICS) ? Moves.FROST_BREATH : Moves.ICE_BEAM; break;

				case Environments.Volcano: move = Moves.LAVA_PLUME; break;
				case Environments.Graveyard: move = Moves.SHADOW_BALL; break;
				case Environments.Sky: move = Moves.AIR_SLASH; break;
				case Environments.Space: move = Moves.DRACO_METEOR; break;
			}
			if (this.battle.field.ElectricTerrain > 0)
			{
				move = Moves.THUNDERBOLT;
			}
			else if (this.battle.field.GrassyTerrain > 0)
			{
				move = Moves.ENERGY_BALL;
			}
			else if (this.battle.field.MistyTerrain > 0)
			{
				move = Moves.MOONBLAST;
			}
			if (move == 0)
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			string thismovename = Name;

			string movename = Game._INTL(move.ToString(TextScripts.Name));
			_host.StartCoroutine(battle.Display(Game._INTL("{1} turned into {2}!", thismovename, movename)));
			int target = (Core.USENEWBATTLEMECHANICS && opponent.IsNotNullOrNone()) ? opponent.Index : -1;
			attacker.UseMoveSimple(move, -1, target);
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// Uses a random move the user knows. Fails if user is not asleep. (Sleep Talk)
	/// <summary>
	public partial class PokeBattle_Move_0B4 : PokeBattle_Move
	{
		public PokeBattle_Move_0B4() : base() { }
		//public PokeBattle_Move_0B4(Battle battle, Attack.Move move) : base(battle, move) { }
		public override bool CanUseWhileAsleep()
		{
			return true;
		}

		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result = null)
		{
			if (attacker.Status != Status.SLEEP)
			{
				yield return battle.Display(Game._INTL("But it failed!"));
				result?.Invoke(-1); yield break;
			}
			List<Attack.Effects> blacklist = new List<Attack.Effects> {
				Attack.Effects.x0FF,		// Struggle
				Attack.Effects.x10C,		// Chatter
				Attack.Effects.x053,		// Mimic
				Attack.Effects.x060,		// Sketch
				Attack.Effects.x00A,		// Mirror Move
				Attack.Effects.x0F3,		// Copycat
				Attack.Effects.x0F2,		// Me First
				Attack.Effects.x0AE,		// Nature Power
				Attack.Effects.x062,		// Sleep Talk
				Attack.Effects.x0B5,		// Assist
				Attack.Effects.x054,		// Metronome
				Attack.Effects.x0A0,		// Uproar
				Attack.Effects.x01B,		// Bide
				Attack.Effects.x0AB,		// Focus Punch
												// Two-turn attacks
				Attack.Effects.x028,		// Razor Wind
				Attack.Effects.x098,		// SolarBeam
				Attack.Effects.x14C,		// Freeze Shock
				Attack.Effects.x14D,		// Ice Burn
				Attack.Effects.x04C,		// Sky Attack
				Attack.Effects.x092,		// Skull Bash
				Attack.Effects.x09C,		// Fly
				Attack.Effects.x101,		// Dig
				Attack.Effects.x100,		// Dive
				Attack.Effects.x108,		// Bounce
				//Attack.Effects.x111,		// Shadow Force
				Attack.Effects.x138,		// Sky Drop
				Attack.Effects.x111,		// Phantom Force
				Attack.Effects.x16E		// Geomancy
			};

			List<int> choices = new List<int>(); //[];
			for (int i = 0; i < 4; i++)
			{
				bool found = false;
				if (attacker.moves[i].id == 0) continue; //next
				if (blacklist.Contains(attacker.moves[i].Effect)) found = true;
				if (found) continue; //next
				//if (this.battle.CanChooseMove(attacker.Index, i, false, true)) choices.Add(i);
				bool canChooseMove = false;
				yield return this.battle.CanChooseMove(attacker.Index, i, false, true, result: value => canChooseMove = value);
				if (canChooseMove) choices.Add(i);
			}
			if (choices.Count == 0)
			{
				yield return battle.Display(Game._INTL("But it failed!"));
				result?.Invoke(-1); yield break;
			}
			_host.StartCoroutine(ShowAnimation(this.id, attacker, null, hitnum, alltargets, showanimation));

			int choice = choices[this.battle.Random(choices.Count)];
			attacker.UseMoveSimple(attacker.moves[choice].id, -1, attacker.OppositeOpposing.Index);
			result?.Invoke(0);
		}
	}

	/// <summary>
	/// Uses a random move known by any non-user Pokémon in the user's party. (Assist)
	/// <summary>
	public partial class PokeBattle_Move_0B5 : PokeBattle_Move
	{
		public PokeBattle_Move_0B5() : base() { }
		//public PokeBattle_Move_0B5(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			List<Attack.Effects> blacklist = new List<Attack.Effects> {
				Attack.Effects.x0FF,		// Struggle
				Attack.Effects.x10C,		// Chatter
				Attack.Effects.x053,		// Mimic
				Attack.Effects.x060,		// Sketch
				Attack.Effects.x03A,		// Transform
				Attack.Effects.x05A,		// Counter
				Attack.Effects.x091,		// Mirror Coat
				Attack.Effects.x0E4,		// Metal Burst
				Attack.Effects.x0B1,		// Helping Hand
				Attack.Effects.x070,		// Detect, Protect
				Attack.Effects.x0E0,		// Feint
				Attack.Effects.x00A,		// Mirror Move
				Attack.Effects.x0F3,		// Copycat
				Attack.Effects.x0F2,		// Me First
				Attack.Effects.x0C4,		// Snatch
				Attack.Effects.x0AE,		// Nature Power
				Attack.Effects.x062,		// Sleep Talk
				Attack.Effects.x0B5,		// Assist
				Attack.Effects.x054,		// Metronome
				//Attack.Effects.x111,		// Shadow Force
				Attack.Effects.x063,		// Destiny Bond
				Attack.Effects.x075,		// Endure
				Attack.Effects.x01D,		// Roar, Whirlwind
				Attack.Effects.x13A,		// Circle Throw, Dragon Tail
				Attack.Effects.x06A,		// Covet, Thief
				Attack.Effects.x0B2,		// Switcheroo, Trick
				Attack.Effects.x144,		// Bestow
				Attack.Effects.x0AB,		// Focus Punch
				Attack.Effects.x0AD,		// Follow Me, Rage Powder
				Attack.Effects.x179,		// Mat Block
				Attack.Effects.x164,		// King's Shield
				Attack.Effects.x16A,		// Spiky Shield
				Attack.Effects.x111,		// Phantom Force
				Attack.Effects.x153		// Belch
			};
			if (Core.USENEWBATTLEMECHANICS)
			{
				blacklist.AddRange(new List<Attack.Effects>{
												// Two-turn attacks
					Attack.Effects.x028,	// Razor Wind
					Attack.Effects.x098,	// SolarBeam
					Attack.Effects.x14C,	// Freeze Shock
					Attack.Effects.x14D,	// Ice Burn
					Attack.Effects.x04C,	// Sky Attack
					Attack.Effects.x092,	// Skull Bash
					Attack.Effects.x09C,	// Fly
					Attack.Effects.x101,	// Dig
					Attack.Effects.x100,	// Dive
					Attack.Effects.x108,	// Bounce
					//Attack.Effects.x111,	// Shadow Force
					Attack.Effects.x138,	// Sky Drop
					Attack.Effects.x111,	// Phantom Force
					Attack.Effects.x16E	// Geomancy
				});
			}
			List<Moves> moves = new List<Moves>();

			IPokemon[] party = this.battle.Party(attacker.Index); // NOTE: Party is common to both allies in multi battles
			for (int i = 0; i < party.Length; i++)
			{
				if (i != attacker.pokemonIndex && party[i].IsNotNullOrNone() && !(Core.USENEWBATTLEMECHANICS && party[i].isEgg))
				{
					foreach (var j in party[i].moves)
					{
						if (j.Type == Types.SHADOW) continue; //next
						if (j.id == 0) continue; //next
						//bool found=false;
						if (!blacklist.Contains(Kernal.MoveData[(Moves)MoveId].Effect)) moves.Add(j.id);
					}
				}

			}
			if (moves.Count == 0)
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			_host.StartCoroutine(ShowAnimation(this.id, attacker, null, hitnum, alltargets, showanimation));

			Moves move = moves[this.battle.Random(moves.Count)];
			attacker.UseMoveSimple(move);
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// Uses a random move that exists. (Metronome)
	/// <summary>
	public partial class PokeBattle_Move_0B6 : PokeBattle_Move
	{
		public PokeBattle_Move_0B6() : base() { }
		//public PokeBattle_Move_0B6(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			List<Attack.Effects> blacklist = new List<Attack.Effects> {
				Attack.Effects.x0FF,	// Struggle
				Attack.Effects.x05D,	// Snore
				Attack.Effects.x10C,	// Chatter
				Attack.Effects.x053,	// Mimic
				Attack.Effects.x060,	// Sketch
				Attack.Effects.x03A,	// Transform
				Attack.Effects.x05A,	// Counter
				Attack.Effects.x091,	// Mirror Coat
				Attack.Effects.x0E4,	// Metal Burst
				Attack.Effects.x0B1,	// Helping Hand
				Attack.Effects.x070,	// Detect, Protect
				Attack.Effects.x133,	// Quick Guard
				Attack.Effects.x117,	// Wide Guard
				Attack.Effects.x0E0,	// Feint
				Attack.Effects.x00A,	// Mirror Move
				Attack.Effects.x0F3,	// Copycat
				Attack.Effects.x0F2,	// Me First
				Attack.Effects.x0C4,	// Snatch
				Attack.Effects.x0AE,	// Nature Power
				Attack.Effects.x062,	// Sleep Talk
				Attack.Effects.x0B5,	// Assist
				Attack.Effects.x054,	// Metronome
				Attack.Effects.x063,	// Destiny Bond
				Attack.Effects.x075,	// Endure
				Attack.Effects.x06A,	// Covet, Thief
				Attack.Effects.x0B2,	// Switcheroo, Trick
				Attack.Effects.x144,	// Bestow
				Attack.Effects.x0AB,	// Focus Punch
				Attack.Effects.x0AD,	// Follow Me, Rage Powder
				Attack.Effects.x12D,	// After You
				Attack.Effects.x13C	// Quash
			};
			List<Moves> blacklistmoves = new List<Moves> {
				Moves.FREEZE_SHOCK,
				Moves.ICE_BURN,
				Moves.RELIC_SONG,
				Moves.SECRET_SWORD,
				Moves.SNARL,
				Moves.TECHNO_BLAST,
				Moves.V_CREATE,
				Moves.GEOMANCY
			};
			for (int i = 0; i < 1000; i++) //loop do break unless i<1000
			{
				Moves move = (Moves)(this.battle.Random(Kernal.MoveData.Keys.Count) + 1);
				if (Kernal.MoveData[(Moves)move].Type == Types.SHADOW) continue; //next
				bool found = false;
				if (blacklist.Contains(Kernal.MoveData[(Moves)move].Effect))
					found = true;
				else
				{
					foreach (Moves j in blacklistmoves)
					{
						if (move == j)
						{
							found = true;
							break;
						}
					}

				}
				if (!found)
				{
					_host.StartCoroutine(ShowAnimation(this.id, attacker, null, hitnum, alltargets, showanimation));

					attacker.UseMoveSimple(move);
					result(0);
					yield break;
				}
				i += 1;
			}
			_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
			result(-1);
			yield break;
		}
	}

	/// <summary>
	/// The target can no longer use the same move twice in a row. (Torment)
	/// <summary>
	public partial class PokeBattle_Move_0B7 : PokeBattle_Move
	{
		public PokeBattle_Move_0B7() : base() { }
		//public PokeBattle_Move_0B7(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (opponent.effects.Torment)
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			if (!attacker.hasMoldBreaker())
			{
				if (opponent.hasWorkingAbility(Abilities.AROMA_VEIL))
				{
					_host.StartCoroutine(battle.Display(Game._INTL("But it failed because of {1}'s {2}!",
					   opponent.ToString(),Game._INTL(opponent.Ability.ToString(TextScripts.Name)))));
					result(-1);
					yield break;
				}
				else if (opponent.Partner.hasWorkingAbility(Abilities.AROMA_VEIL))
				{

					_host.StartCoroutine(battle.Display(Game._INTL("But it failed because of {1}'s {2}!",
					   opponent.Partner.ToString(),Game._INTL(opponent.Partner.Ability.ToString(TextScripts.Name)))));
					result(-1);
					yield break;
				}
			}

			_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));

			opponent.effects.Torment = true;
			_host.StartCoroutine(battle.Display(Game._INTL("{1} was subjected to torment!", opponent.ToString())));
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// Disables all target's moves that the user also knows. (Imprison)
	/// <summary>
	public partial class PokeBattle_Move_0B8 : PokeBattle_Move
	{
		public PokeBattle_Move_0B8() : base() { }
		//public PokeBattle_Move_0B8(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (attacker.effects.Imprison)
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));

			attacker.effects.Imprison = true;
			_host.StartCoroutine(battle.Display(Game._INTL("{1} sealed the opponent's move(s)!", attacker.ToString())));
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// For 5 rounds, disables the last move the target used. (Disable)
	/// <summary>
	public partial class PokeBattle_Move_0B9 : PokeBattle_Move
	{
		public PokeBattle_Move_0B9() : base() { }
		//public PokeBattle_Move_0B9(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (opponent.effects.Disable > 0)
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			if (!attacker.hasMoldBreaker())
			{
				if (opponent.hasWorkingAbility(Abilities.AROMA_VEIL))
				{
					_host.StartCoroutine(battle.Display(Game._INTL("But it failed because of {1}'s {2}!",
					   opponent.ToString(),Game._INTL(opponent.Ability.ToString(TextScripts.Name)))));
					result(-1);
					yield break;
				}
				else if (opponent.Partner.hasWorkingAbility(Abilities.AROMA_VEIL))
				{

					_host.StartCoroutine(battle.Display(Game._INTL("But it failed because of {1}'s {2}!",
					   opponent.Partner.ToString(),Game._INTL(opponent.Partner.Ability.ToString(TextScripts.Name)))));
					result(-1);
					yield break;
				}
			}
			foreach (var i in opponent.moves)
			{
				if (i.id > 0 && i.id == opponent.lastMoveUsed && (i.PP > 0 || i.TotalPP == 0))
				{
					_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));

					opponent.effects.Disable = 5;
					opponent.effects.DisableMove = opponent.lastMoveUsed;
					_host.StartCoroutine(battle.Display(Game._INTL("{1}'s {2} was disabled!", opponent.ToString(), Kernal.MoveData[(Moves)i.id].Name)));
					result(0);
					yield break;
				}
			}

			_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
			result(-1);
			yield break;
		}
	}

	/// <summary>
	/// For 4 rounds, disables the target's non-damaging moves. (Taunt)
	/// <summary>
	public partial class PokeBattle_Move_0BA : PokeBattle_Move
	{
		public PokeBattle_Move_0BA() : base() { }
		//public PokeBattle_Move_0BA(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (opponent.effects.Taunt > 0 ||
			   (Core.USENEWBATTLEMECHANICS &&
			   !attacker.hasMoldBreaker() && opponent.hasWorkingAbility(Abilities.OBLIVIOUS)))
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			if (!attacker.hasMoldBreaker())
			{
				if (opponent.hasWorkingAbility(Abilities.AROMA_VEIL))
				{
					_host.StartCoroutine(battle.Display(Game._INTL("But it failed because of {1}'s {2}!",
					   opponent.ToString(),Game._INTL(opponent.Ability.ToString(TextScripts.Name)))));
					result(-1);
					yield break;
				}
				else if (opponent.Partner.hasWorkingAbility(Abilities.AROMA_VEIL))
				{

					_host.StartCoroutine(battle.Display(Game._INTL("But it failed because of {1}'s {2}!",
					   opponent.Partner.ToString(),Game._INTL(opponent.Partner.Ability.ToString(TextScripts.Name)))));
					result(-1);
					yield break;
				}
			}

			_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));

			opponent.effects.Taunt = 4;
			_host.StartCoroutine(battle.Display(Game._INTL("{1} fell for the taunt!", opponent.ToString())));
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// For 5 rounds, disables the target's healing moves. (Heal Block)
	/// <summary>
	public partial class PokeBattle_Move_0BB : PokeBattle_Move
	{
		public PokeBattle_Move_0BB() : base() { }
		//public PokeBattle_Move_0BB(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (opponent.effects.HealBlock > 0)
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			if (!attacker.hasMoldBreaker())
			{
				if (opponent.hasWorkingAbility(Abilities.AROMA_VEIL))
				{
					_host.StartCoroutine(battle.Display(Game._INTL("But it failed because of {1}'s {2}!",
					   opponent.ToString(),Game._INTL(opponent.Ability.ToString(TextScripts.Name)))));
					result(-1);
					yield break;
				}
				else if (opponent.Partner.hasWorkingAbility(Abilities.AROMA_VEIL))
				{

					_host.StartCoroutine(battle.Display(Game._INTL("But it failed because of {1}'s {2}!",
					   opponent.Partner.ToString(),Game._INTL(opponent.Partner.Ability.ToString(TextScripts.Name)))));
					result(-1);
					yield break;
				}
			}

			_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));

			opponent.effects.HealBlock = 5;
			_host.StartCoroutine(battle.Display(Game._INTL("{1} was prevented from healing!", opponent.ToString())));
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// For 4 rounds, the target must use the same move each round. (Encore)
	/// <summary>
	public partial class PokeBattle_Move_0BC : PokeBattle_Move
	{
		public PokeBattle_Move_0BC() : base() { }
		//public PokeBattle_Move_0BC(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			List<Attack.Effects> blacklist = new List<Attack.Effects> {
				Attack.Effects.x0FF,    // Struggle
				Attack.Effects.x053,    // Mimic
				Attack.Effects.x060,    // Sketch
				Attack.Effects.x03A,    // Transform
				Attack.Effects.x00A,    // Mirror Move
				Attack.Effects.x05B     // Encore
			};
			if (opponent.effects.Encore > 0)
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			if (opponent.lastMoveUsed <= 0 ||
			   blacklist.Contains(Kernal.MoveData[(Moves)opponent.lastMoveUsed].Effect))
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			if (!attacker.hasMoldBreaker())
			{
				if (opponent.hasWorkingAbility(Abilities.AROMA_VEIL))
				{
					_host.StartCoroutine(battle.Display(Game._INTL("But it failed because of {1}'s {2}!",
					   opponent.ToString(),Game._INTL(opponent.Ability.ToString(TextScripts.Name)))));
					result(-1);
					yield break;
				}
				else if (opponent.Partner.hasWorkingAbility(Abilities.AROMA_VEIL))
				{

					_host.StartCoroutine(battle.Display(Game._INTL("But it failed because of {1}'s {2}!",
					   opponent.Partner.ToString(),Game._INTL(opponent.Partner.Ability.ToString(TextScripts.Name)))));
					result(-1);
					yield break;
				}
			}
			for (int i = 0; i < 4; i++)
			{
				if (opponent.lastMoveUsed == opponent.moves[i].id &&
				   (opponent.moves[i].PP > 0 || opponent.moves[i].TotalPP == 0))
				{
					_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));

					opponent.effects.Encore = 4;
					opponent.effects.EncoreIndex = i;
					opponent.effects.EncoreMove = opponent.moves[i].id;

					_host.StartCoroutine(battle.Display(Game._INTL("{1} received an encore!", opponent.ToString())));
					result(0);
					yield break;
				}
			}

			_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
			result(-1);
			yield break;
		}
	}

	/// <summary>
	/// Hits twice.
	/// <summary>
	public partial class PokeBattle_Move_0BD : PokeBattle_Move
	{
		public PokeBattle_Move_0BD() : base() { }
		//public PokeBattle_Move_0BD(Battle battle, Attack.Move move) : base(battle, move) { }
		public override bool IsMultiHit()
		{
			return true;
		}

		public override int NumHits(IBattler attacker)
		{
			return 2;
		}
	}

	/// <summary>
	/// Hits twice. May poison the target on each hit. (Twineedle)
	/// <summary>
	public partial class PokeBattle_Move_0BE : PokeBattle_Move
	{
		public PokeBattle_Move_0BE() : base() { }
		//public PokeBattle_Move_0BE(Battle battle, Attack.Move move) : base(battle, move) { }
		public override bool IsMultiHit()
		{
			return true;
		}

		public override int NumHits(IBattler attacker)
		{
			return 2;
		}

		public override void AdditionalEffect(IBattler attacker, IBattler opponent)
		{
			if (opponent.damagestate.Substitute) return;
			if (opponent is IBattlerEffect b && b.CanPoison(attacker, false, this))
			{
				b.Poison(attacker);
			}
		}
	}

	/// <summary>
	/// Hits 3 times. Power is multiplied by the hit number. (Triple Kick)
	/// An accuracy check is performed for each hit.
	/// <summary>
	public partial class PokeBattle_Move_0BF : PokeBattle_Move
	{
		public bool checks { get; set; }
		public PokeBattle_Move_0BF() : base() { }
		//public PokeBattle_Move_0BF(Battle battle, Attack.Move move) : base(battle, move) { }
		public override bool IsMultiHit()
		{
			return true;
		}

		public override int NumHits(IBattler attacker)
		{
			return 3;
		}

		public override bool successCheckPerHit()
		{
			return this.checks;
		}

		public override bool OnStartUse(IBattler attacker)
		{
			this.calcbasedmg = base.Power;
			this.checks = !attacker.hasWorkingAbility(Abilities.SKILL_LINK);
			return true;
		}

		public override int BaseDamage(int basedmg, IBattler attacker, IBattler opponent)
		{
			int ret = this.calcbasedmg;
			this.calcbasedmg += basedmg;
			return ret;
		}
	}

	/// <summary>
	/// Hits 2-5 times.
	/// <summary>
	public partial class PokeBattle_Move_0C0 : PokeBattle_Move
	{
		public PokeBattle_Move_0C0() : base() { }
		//public PokeBattle_Move_0C0(Battle battle, Attack.Move move) : base(battle, move) { }
		public override bool IsMultiHit()
		{
			return true;
		}

		public override int NumHits(IBattler attacker)
		{
			int[] hitchances = new int[] { 2, 2, 3, 3, 4, 5 };

			int ret = hitchances[this.battle.Random(hitchances.Length)];
			if (attacker.hasWorkingAbility(Abilities.SKILL_LINK)) ret = 5;
			return ret;
		}
	}

	/// <summary>
	/// Hits X times, where X is 1 (the user) plus the number of non-user unfainted
	/// status-free Pokémon in the user's party (the participants). Fails if X is 0.
	/// Base power of each hit depends on the base Attack stat for the species of that
	/// hit's participant. (Beat Up)
	/// <summary>
	public partial class PokeBattle_Move_0C1 : PokeBattle_Move
	{
		public List<byte> participants { get; set; }
		public PokeBattle_Move_0C1() : base() { }
		//public PokeBattle_Move_0C1(Battle battle, Attack.Move move) : base(battle, move) { }
		public override bool IsMultiHit()
		{
			return true;
		}

		public override int NumHits(IBattler attacker)
		{
			return this.participants.Count;
		}

		public override bool OnStartUse(IBattler attacker)
		{

			IPokemon[] party = this.battle.Party(attacker.Index);
			this.participants = new List<byte>();
			for (byte i = 0; i < party.Length; i++)
			{
				if (attacker.pokemonIndex == i)
				{
					this.participants.Add(i);

				}
				else if (party[i].IsNotNullOrNone() && !party[i].isEgg && party[i].HP > 0 && party[i].Status == 0)
				{
					this.participants.Add(i);
				}

			}
			if (this.participants.Count == 0)
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				return false;
			}
			return true;
		}

		public override int BaseDamage(int basedmg, IBattler attacker, IBattler opponent)
		{

			IPokemon[] party = this.battle.Party(attacker.Index);
			int atk = party[this.participants[0]].baseStats[1];

			this.participants.RemoveAt(0);//[0]=null; //this.participants.compact!;
			return 5 + (atk / 10);
		}
	}

	/// <summary>
	/// Two turn attack. Attacks first turn, skips second turn (if successful).
	/// <summary>
	public partial class PokeBattle_Move_0C2 : PokeBattle_Move
	{
		public PokeBattle_Move_0C2() : base() { }
		//public PokeBattle_Move_0C2(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			int ret = -1; _host.StartCoroutine(base.GetEffect(attacker, opponent, hitnum, alltargets, showanimation, result:value=>ret=value)); result(ret);
			if (opponent.damagestate.CalcDamage > 0)
			{
				attacker.effects.HyperBeam = 2;
				attacker.currentMove = this.id;
			}
			result(ret);
			yield break;
		}
	}

	/// <summary>
	/// Two turn attack. Skips first turn, attacks second turn. (Razor Wind)
	/// <summary>
	public partial class PokeBattle_Move_0C3 : PokeBattle_Move
	{
		public PokeBattle_Move_0C3() : base() { }
		//public PokeBattle_Move_0C3(Battle battle, Attack.Move move) : base(battle, move) { }
		public override bool TwoTurnAttack(IBattler attacker)
		{
			this.immediate = false;
			if (!this.immediate && attacker.hasWorkingItem(Items.POWER_HERB))
			{
				this.immediate = true;
			}
			if (this.immediate) return false;
			return attacker.effects.TwoTurnAttack == 0;
		}

		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (this.immediate || attacker.effects.TwoTurnAttack > 0)
			{
				_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, 1, alltargets, showanimation)); // Charging anim
				_host.StartCoroutine(battle.Display(Game._INTL("{1} whipped up a whirlwind!", attacker.ToString())));
			}
			if (this.immediate)
			{
				_host.StartCoroutine(this.battle.CommonAnimation("UseItem", attacker, null));

				_host.StartCoroutine(battle.Display(Game._INTL("{1} became fully charged due to its Power Herb!", attacker.ToString())));
				_host.StartCoroutine(attacker.ConsumeItem());
			}
			if (attacker.effects.TwoTurnAttack > 0) { result(0); yield break; }
			int ret = -1; _host.StartCoroutine(base.GetEffect(attacker, opponent, hitnum, alltargets, showanimation, result:value=>ret=value)); result(ret);
			yield break;
		}
	}

	/// <summary>
	/// Two turn attack. Skips first turn, attacks second turn. (SolarBeam)
	/// Power halved in all weather except sunshine. In sunshine, takes 1 turn instead.
	/// <summary>
	public partial class PokeBattle_Move_0C4 : PokeBattle_Move
	{
		public bool sunny { get; set; }
		public PokeBattle_Move_0C4() : base() { }
		//public PokeBattle_Move_0C4(Battle battle, Attack.Move move) : base(battle, move) { }
		public override bool TwoTurnAttack(IBattler attacker)
		{
			this.immediate = false; this.sunny = false;
			if (attacker.effects.TwoTurnAttack == 0)
			{
				if (this.battle.Weather == Weather.SUNNYDAY ||
				   this.battle.Weather == Weather.HARSHSUN)
				{
					this.immediate = true; this.sunny = true;
				}
			}
			if (!this.immediate && attacker.hasWorkingItem(Items.POWER_HERB))
			{
				this.immediate = true;
			}
			if (this.immediate) return false;
			return attacker.effects.TwoTurnAttack == 0;
		}

		public int BaseDamageMultiplier(int damagemult, IBattler attacker, IBattler opponent)
		{
			if (this.battle.Weather != 0 &&
			   this.battle.Weather != Weather.SUNNYDAY &&
			   this.battle.Weather != Weather.HARSHSUN)
			{
				return (int)Math.Round(damagemult * 0.5f);
			}
			return damagemult;
		}

		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (this.immediate || attacker.effects.TwoTurnAttack > 0)
			{
				_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, 1, alltargets, showanimation)); // Charging anim
				_host.StartCoroutine(battle.Display(Game._INTL("{1} took in sunlight!", attacker.ToString())));
			}
			if (this.immediate && !this.sunny)
			{
				_host.StartCoroutine(this.battle.CommonAnimation("UseItem", attacker, null));

				_host.StartCoroutine(battle.Display(Game._INTL("{1} became fully charged due to its Power Herb!", attacker.ToString())));
				_host.StartCoroutine(attacker.ConsumeItem());
			}
			if (attacker.effects.TwoTurnAttack > 0) { result(0); yield break; }
			int ret = -1; _host.StartCoroutine(base.GetEffect(attacker, opponent, hitnum, alltargets, showanimation, result:value=>ret=value)); result(ret);
			yield break;
		}
	}

	/// <summary>
	/// Two turn attack. Skips first turn, attacks second turn. (Freeze Shock)
	/// May paralyze the target.
	/// <summary>
	public partial class PokeBattle_Move_0C5 : PokeBattle_Move
	{
		public PokeBattle_Move_0C5() : base() { }
		//public PokeBattle_Move_0C5(Battle battle, Attack.Move move) : base(battle, move) { }
		public override bool TwoTurnAttack(IBattler attacker)
		{
			this.immediate = false;
			if (!this.immediate && attacker.hasWorkingItem(Items.POWER_HERB))
			{
				this.immediate = true;
			}
			if (this.immediate) return false;
			return attacker.effects.TwoTurnAttack == 0;
		}

		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (this.immediate || attacker.effects.TwoTurnAttack > 0)
			{
				_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, 1, alltargets, showanimation)); // Charging anim
				_host.StartCoroutine(battle.Display(Game._INTL("{1} became cloaked in a freezing light!", attacker.ToString())));
			}
			if (this.immediate)
			{
				_host.StartCoroutine(this.battle.CommonAnimation("UseItem", attacker, null));

				_host.StartCoroutine(battle.Display(Game._INTL("{1} became fully charged due to its Power Herb!", attacker.ToString())));
				_host.StartCoroutine(attacker.ConsumeItem());
			}
			if (attacker.effects.TwoTurnAttack > 0) { result(0); yield break; }
			int ret = -1; _host.StartCoroutine(base.GetEffect(attacker, opponent, hitnum, alltargets, showanimation, result:value=>ret=value)); result(ret);
			yield break;
		}

		public override void AdditionalEffect(IBattler attacker, IBattler opponent)
		{
			if (opponent.damagestate.Substitute) return;
			if (opponent is IBattlerEffect b && b.CanParalyze(attacker, false, this))
			{
				b.Paralyze(attacker);
			}
		}
	}

	/// <summary>
	/// Two turn attack. Skips first turn, attacks second turn. (Ice Burn)
	/// May burn the target.
	/// <summary>
	public partial class PokeBattle_Move_0C6 : PokeBattle_Move
	{
		public PokeBattle_Move_0C6() : base() { }
		//public PokeBattle_Move_0C6(Battle battle, Attack.Move move) : base(battle, move) { }
		public override bool TwoTurnAttack(IBattler attacker)
		{
			this.immediate = false;
			if (!this.immediate && attacker.hasWorkingItem(Items.POWER_HERB))
			{
				this.immediate = true;
			}
			if (this.immediate) return false;
			return attacker.effects.TwoTurnAttack == 0;
		}

		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (this.immediate || attacker.effects.TwoTurnAttack > 0)
			{
				_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, 1, alltargets, showanimation)); // Charging anim
				_host.StartCoroutine(battle.Display(Game._INTL("{1} became cloaked in freezing air!", attacker.ToString())));
			}
			if (this.immediate)
			{
				_host.StartCoroutine(this.battle.CommonAnimation("UseItem", attacker, null));

				_host.StartCoroutine(battle.Display(Game._INTL("{1} became fully charged due to its Power Herb!", attacker.ToString())));
				_host.StartCoroutine(attacker.ConsumeItem());
			}
			if (attacker.effects.TwoTurnAttack > 0) { result(0); yield break; }
			int ret = -1; _host.StartCoroutine(base.GetEffect(attacker, opponent, hitnum, alltargets, showanimation, result:value=>ret=value)); result(ret);
			yield break;
		}

		public override void AdditionalEffect(IBattler attacker, IBattler opponent)
		{
			if (opponent.damagestate.Substitute) return;
			if (opponent is IBattlerEffect b && b.CanBurn(attacker, false, this))
			{
				b.Burn(attacker);
			}
		}
	}

	/// <summary>
	/// Two turn attack. Skips first turn, attacks second turn. (Sky Attack)
	/// May make the target flinch.
	/// <summary>
	public partial class PokeBattle_Move_0C7 : PokeBattle_Move
	{
		public PokeBattle_Move_0C7() : base() { }
		//public PokeBattle_Move_0C7(Battle battle, Attack.Move move) : base(battle, move) { }
		public override bool TwoTurnAttack(IBattler attacker)
		{
			this.immediate = false;
			if (!this.immediate && attacker.hasWorkingItem(Items.POWER_HERB))
			{
				this.immediate = true;
			}
			if (this.immediate) return false;
			return attacker.effects.TwoTurnAttack == 0;
		}

		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (this.immediate || attacker.effects.TwoTurnAttack > 0)
			{
				_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, 1, alltargets, showanimation)); // Charging anim
				_host.StartCoroutine(battle.Display(Game._INTL("{1} became cloaked in a harsh light!", attacker.ToString())));
			}
			if (this.immediate)
			{
				_host.StartCoroutine(this.battle.CommonAnimation("UseItem", attacker, null));

				_host.StartCoroutine(battle.Display(Game._INTL("{1} became fully charged due to its Power Herb!", attacker.ToString())));
				_host.StartCoroutine(attacker.ConsumeItem());
			}
			if (attacker.effects.TwoTurnAttack > 0) { result(0); yield break; }
			int ret = -1; _host.StartCoroutine(base.GetEffect(attacker, opponent, hitnum, alltargets, showanimation, result:value=>ret=value)); result(ret);
			yield break;
		}

		public override void AdditionalEffect(IBattler attacker, IBattler opponent)
		{
			if (opponent.damagestate.Substitute) return;
			if (opponent is IBattlerEffectIE o) o.Flinch(attacker);
		}
	}

	/// <summary>
	/// Two turn attack. Ups user's Defense by 1 stage first turn, attacks second turn.
	/// (Skull Bash)
	/// <summary>
	public partial class PokeBattle_Move_0C8 : PokeBattle_Move
	{
		public PokeBattle_Move_0C8() : base() { }
		//public PokeBattle_Move_0C8(Battle battle, Attack.Move move) : base(battle, move) { }
		public override bool TwoTurnAttack(IBattler attacker)
		{
			this.immediate = false;
			if (!this.immediate && attacker.hasWorkingItem(Items.POWER_HERB))
			{
				this.immediate = true;
			}
			if (this.immediate) return false;
			return attacker.effects.TwoTurnAttack == 0;
		}

		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (this.immediate || attacker.effects.TwoTurnAttack > 0)
			{
				_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, 1, alltargets, showanimation)); // Charging anim
				_host.StartCoroutine(battle.Display(Game._INTL("{1} tucked in its head!", attacker.ToString())));
				if (attacker is IBattlerEffect b && b.CanIncreaseStatStage(Stats.DEFENSE, attacker, false, this))
				{
					b.IncreaseStat(Stats.DEFENSE, 1, attacker, false, this);
				}
			}
			if (this.immediate)
			{
				_host.StartCoroutine(this.battle.CommonAnimation("UseItem", attacker, null));

				_host.StartCoroutine(battle.Display(Game._INTL("{1} became fully charged due to its Power Herb!", attacker.ToString())));
				_host.StartCoroutine(attacker.ConsumeItem());
			}
			if (attacker.effects.TwoTurnAttack > 0) { result(0); yield break; }
			int ret = -1; _host.StartCoroutine(base.GetEffect(attacker, opponent, hitnum, alltargets, showanimation, result:value=>ret=value)); result(ret);
			yield break;
		}
	}

	/// <summary>
	/// Two turn attack. Skips first turn, attacks second turn. (Fly)
	/// (Handled in Pokemon's SuccessCheck): Is semi-invulnerable during use.
	/// <summary>
	public partial class PokeBattle_Move_0C9 : PokeBattle_Move
	{
		public PokeBattle_Move_0C9() : base() { }
		//public PokeBattle_Move_0C9(Battle battle, Attack.Move move) : base(battle, move) { }
		public override bool UnusableInGravity()
		{
			return true;
		}

		public override bool TwoTurnAttack(IBattler attacker)
		{
			this.immediate = false;
			if (!this.immediate && attacker.hasWorkingItem(Items.POWER_HERB))
			{
				this.immediate = true;
			}
			if (this.immediate) return false;
			return attacker.effects.TwoTurnAttack == 0;
		}

		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (this.immediate || attacker.effects.TwoTurnAttack > 0)
			{
				_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, 1, alltargets, showanimation)); // Charging anim
				_host.StartCoroutine(battle.Display(Game._INTL("{1} flew up high!", attacker.ToString())));
			}
			if (this.immediate)
			{
				_host.StartCoroutine(this.battle.CommonAnimation("UseItem", attacker, null));

				_host.StartCoroutine(battle.Display(Game._INTL("{1} became fully charged due to its Power Herb!", attacker.ToString())));
				_host.StartCoroutine(attacker.ConsumeItem());
			}
			if (attacker.effects.TwoTurnAttack > 0) { result(0); yield break; }
			int ret = -1; _host.StartCoroutine(base.GetEffect(attacker, opponent, hitnum, alltargets, showanimation, result:value=>ret=value)); result(ret);
			yield break;
		}
	}

	/// <summary>
	/// Two turn attack. Skips first turn, attacks second turn. (Dig)
	/// (Handled in Pokemon's SuccessCheck): Is semi-invulnerable during use.
	/// <summary>
	public partial class PokeBattle_Move_0CA : PokeBattle_Move
	{
		public PokeBattle_Move_0CA() : base() { }
		//public PokeBattle_Move_0CA(Battle battle, Attack.Move move) : base(battle, move) { }
		public override bool TwoTurnAttack(IBattler attacker)
		{
			this.immediate = false;
			if (!this.immediate && attacker.hasWorkingItem(Items.POWER_HERB))
			{
				this.immediate = true;
			}
			if (this.immediate) return false;
			return attacker.effects.TwoTurnAttack == 0;
		}

		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (this.immediate || attacker.effects.TwoTurnAttack > 0)
			{
				_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, 1, alltargets, showanimation)); // Charging anim
				_host.StartCoroutine(battle.Display(Game._INTL("{1} burrowed its way under the ground!", attacker.ToString())));
			}
			if (this.immediate)
			{
				_host.StartCoroutine(this.battle.CommonAnimation("UseItem", attacker, null));

				_host.StartCoroutine(battle.Display(Game._INTL("{1} became fully charged due to its Power Herb!", attacker.ToString())));
				_host.StartCoroutine(attacker.ConsumeItem());
			}
			if (attacker.effects.TwoTurnAttack > 0) { result(0); yield break; }
			int ret = -1; _host.StartCoroutine(base.GetEffect(attacker, opponent, hitnum, alltargets, showanimation, result:value=>ret=value)); result(ret);
			yield break;
		}
	}

	/// <summary>
	/// Two turn attack. Skips first turn, attacks second turn. (Dive)
	/// (Handled in Pokemon's SuccessCheck): Is semi-invulnerable during use.
	/// <summary>
	public partial class PokeBattle_Move_0CB : PokeBattle_Move
	{
		public PokeBattle_Move_0CB() : base() { }
		//public PokeBattle_Move_0CB(Battle battle, Attack.Move move) : base(battle, move) { }
		public override bool TwoTurnAttack(IBattler attacker)
		{
			this.immediate = false;
			if (!this.immediate && attacker.hasWorkingItem(Items.POWER_HERB))
			{
				this.immediate = true;
			}
			if (this.immediate) return false;
			return attacker.effects.TwoTurnAttack == 0;
		}

		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (this.immediate || attacker.effects.TwoTurnAttack > 0)
			{
				_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, 1, alltargets, showanimation)); // Charging anim
				_host.StartCoroutine(battle.Display(Game._INTL("{1} hid underwater!", attacker.ToString())));
			}
			if (this.immediate)
			{
				_host.StartCoroutine(this.battle.CommonAnimation("UseItem", attacker, null));

				_host.StartCoroutine(battle.Display(Game._INTL("{1} became fully charged due to its Power Herb!", attacker.ToString())));
				_host.StartCoroutine(attacker.ConsumeItem());
			}
			if (attacker.effects.TwoTurnAttack > 0) { result(0); yield break; }
			int ret = -1; _host.StartCoroutine(base.GetEffect(attacker, opponent, hitnum, alltargets, showanimation, result:value=>ret=value)); result(ret);
			yield break;
		}
	}

	/// <summary>
	/// Two turn attack. Skips first turn, attacks second turn. (Bounce)
	/// May paralyze the target.
	/// (Handled in Pokemon's SuccessCheck): Is semi-invulnerable during use.
	/// <summary>
	public partial class PokeBattle_Move_0CC : PokeBattle_Move
	{
		public PokeBattle_Move_0CC() : base() { }
		//public PokeBattle_Move_0CC(Battle battle, Attack.Move move) : base(battle, move) { }
		public override bool UnusableInGravity()
		{
			return true;
		}

		public override bool TwoTurnAttack(IBattler attacker)
		{
			this.immediate = false;
			if (!this.immediate && attacker.hasWorkingItem(Items.POWER_HERB))
			{
				this.immediate = true;
			}
			if (this.immediate) return false;
			return attacker.effects.TwoTurnAttack == 0;
		}

		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (this.immediate || attacker.effects.TwoTurnAttack > 0)
			{
				_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, 1, alltargets, showanimation)); // Charging anim
				_host.StartCoroutine(battle.Display(Game._INTL("{1} sprang up!", attacker.ToString())));
			}
			if (this.immediate)
			{
				_host.StartCoroutine(this.battle.CommonAnimation("UseItem", attacker, null));

				_host.StartCoroutine(battle.Display(Game._INTL("{1} became fully charged due to its Power Herb!", attacker.ToString())));
				_host.StartCoroutine(attacker.ConsumeItem());
			}
			if (attacker.effects.TwoTurnAttack > 0) { result(0); yield break; }
			int ret = -1; _host.StartCoroutine(base.GetEffect(attacker, opponent, hitnum, alltargets, showanimation, result:value=>ret=value)); result(ret);
			yield break;
		}

		public override void AdditionalEffect(IBattler attacker, IBattler opponent)
		{
			if (opponent.damagestate.Substitute) return;
			if (opponent is IBattlerEffect b && b.CanParalyze(attacker, false, this))
			{
				b.Paralyze(attacker);
			}
		}
	}

	/// <summary>
	/// Two turn attack. Skips first turn, attacks second turn. (Shadow Force)
	/// Is invulnerable during use.
	/// Ignores target's Detect, King's Shield, Mat Block, Protect and Spiky Shield
	/// this round. If successful, negates them this round.
	/// <summary>
	public partial class PokeBattle_Move_0CD : PokeBattle_Move
	{
		public PokeBattle_Move_0CD() : base() { }
		//public PokeBattle_Move_0CD(Battle battle, Attack.Move move) : base(battle, move) { }
		public override bool TwoTurnAttack(IBattler attacker)
		{
			this.immediate = false;
			if (!this.immediate && attacker.hasWorkingItem(Items.POWER_HERB))
			{
				this.immediate = true;
			}
			if (this.immediate) return false;
			return attacker.effects.TwoTurnAttack == 0;
		}

		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (this.immediate || attacker.effects.TwoTurnAttack > 0)
			{
				_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, 1, alltargets, showanimation)); // Charging anim
				_host.StartCoroutine(battle.Display(Game._INTL("{1} vanished instantly!", attacker.ToString())));
			}
			if (this.immediate)
			{
				_host.StartCoroutine(this.battle.CommonAnimation("UseItem", attacker, null));

				_host.StartCoroutine(battle.Display(Game._INTL("{1} became fully charged due to its Power Herb!", attacker.ToString())));
				_host.StartCoroutine(attacker.ConsumeItem());
			}
			if (attacker.effects.TwoTurnAttack > 0) { result(0); yield break; }
			int ret = -1; base.GetEffect(attacker, opponent, hitnum, alltargets, showanimation, result:value=>ret=value); result(ret);
			if (ret > 0)
			{
				opponent.effects.ProtectNegation = true;
				opponent.OwnSide.CraftyShield = false;
			}
			result(ret);
			yield break;
		}
	}

	/// <summary>
	/// Two turn attack. Skips first turn, attacks second turn. (Sky Drop)
	/// (Handled in Pokemon's SuccessCheck):  Is semi-invulnerable during use.
	/// Target is also semi-invulnerable during use, and can't take any action.
	/// Doesn't damage airborne Pokémon (but still makes them unable to move during).
	/// <summary>
	public partial class PokeBattle_Move_0CE : PokeBattle_Move
	{
		public PokeBattle_Move_0CE() : base() { }
		//public PokeBattle_Move_0CE(Battle battle, Attack.Move move) : base(battle, move) { }
		public override bool UnusableInGravity()
		{
			return true;
		}

		public override bool MoveFailed(IBattler attacker, IBattler opponent)
		{
			bool ret = false;

			if (opponent.effects.Substitute > 0 && !ignoresSubstitute(attacker)) ret = true;
			if (opponent.effects.TwoTurnAttack > 0) ret = true;
			if (opponent.effects.SkyDrop && attacker.effects.TwoTurnAttack > 0) ret = true;
			if (!opponent.IsOpposing(attacker.Index)) ret = true;
			if (Core.USENEWBATTLEMECHANICS && opponent.Weight(attacker) >= 2000) ret = true;
			return ret;
		}

		public override bool TwoTurnAttack(IBattler attacker)
		{
			return attacker.effects.TwoTurnAttack == 0;
		}

		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (attacker.effects.TwoTurnAttack > 0)
			{
				_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, 1, alltargets, showanimation)); // Charging anim
				_host.StartCoroutine(battle.Display(Game._INTL("{1} took {2} into the sky!", attacker.ToString(), opponent.ToString(true))));
				opponent.effects.SkyDrop = true;
			}
			if (attacker.effects.TwoTurnAttack > 0) { result(0); yield break; }
			int ret = -1; _host.StartCoroutine(base.GetEffect(attacker, opponent, hitnum, alltargets, showanimation, result:value=>ret=value)); result(ret);
			_host.StartCoroutine(battle.Display(Game._INTL("{1} was freed from the Sky Drop!", opponent.ToString())));
			opponent.effects.SkyDrop = false;
			result(ret);
			yield break;
		}

		public override float TypeModifier(Types type, IBattler attacker, IBattler opponent)
		{
			if (opponent.HasType(Types.FLYING)) return 0;
			if (!attacker.hasMoldBreaker() &&
			   opponent.hasWorkingAbility(Abilities.LEVITATE) &&
			   !opponent.effects.SmackDown) return 0;
			return base.TypeModifier(type, attacker, opponent);
		}
	}

	/// <summary>
	/// Trapping move. Traps for 5 or 6 rounds. Trapped Pokémon lose 1/16 of max HP
	/// at end of each round.
	/// <summary>
	public partial class PokeBattle_Move_0CF : PokeBattle_Move
	{
		public PokeBattle_Move_0CF() : base() { }
		//public PokeBattle_Move_0CF(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			int ret = -1; _host.StartCoroutine(base.GetEffect(attacker, opponent, hitnum, alltargets, showanimation, result:value=>ret=value)); result(ret);
			if (opponent.damagestate.CalcDamage > 0 && !opponent.isFainted() &&
			   !opponent.damagestate.Substitute)
			{
				if (opponent.effects.MultiTurn == 0)
				{
					opponent.effects.MultiTurn = 5 + this.battle.Random(2);
					if (attacker.hasWorkingItem(Items.GRIP_CLAW))
					{
						opponent.effects.MultiTurn = (Core.USENEWBATTLEMECHANICS) ? 8 : 6;
					}
					opponent.effects.MultiTurnAttack = this.id;

					opponent.effects.MultiTurnUser = attacker.Index;
					if (id == Moves.BIND)
					{
						_host.StartCoroutine(battle.Display(Game._INTL("{1} was squeezed by {2}!", opponent.ToString(), attacker.ToString(true))));
					}
					else if (id == Moves.CLAMP)
					{
						_host.StartCoroutine(battle.Display(Game._INTL("{1} clamped {2}!", attacker.ToString(), opponent.ToString(true))));
					}
					else if (id == Moves.FIRE_SPIN)
					{
						_host.StartCoroutine(battle.Display(Game._INTL("{1} was trapped in the fiery vortex!", opponent.ToString())));
					}
					else if (id == Moves.MAGMA_STORM)
					{
						_host.StartCoroutine(battle.Display(Game._INTL("{1} became trapped by Magma Storm!", opponent.ToString())));
					}
					else if (id == Moves.SAND_TOMB)
					{
						_host.StartCoroutine(battle.Display(Game._INTL("{1} became trapped by Sand Tomb!", opponent.ToString())));
					}
					else if (id == Moves.WRAP)
					{
						_host.StartCoroutine(battle.Display(Game._INTL("{1} was wrapped by {2}!", opponent.ToString(), attacker.ToString(true))));
					}
					else if (id == Moves.INFESTATION)
					{
						_host.StartCoroutine(battle.Display(Game._INTL("{1} has been afflicted with an infestation by {2}!", opponent.ToString(), attacker.ToString(true))));
					}
					else
					{
						_host.StartCoroutine(battle.Display(Game._INTL("{1} was trapped in the vortex!", opponent.ToString())));
					}
				}

			}
			result(ret);
			yield break;
		}
	}

	/// <summary>
	/// Trapping move. Traps for 5 or 6 rounds. Trapped Pokémon lose 1/16 of max HP
	/// at end of each round. (Whirlpool)
	/// Power is doubled if target is using Dive.
	/// (Handled in Pokemon's SuccessCheck): Hits some semi-invulnerable targets.
	/// <summary>
	public partial class PokeBattle_Move_0D0 : PokeBattle_Move
	{
		public PokeBattle_Move_0D0() : base() { }
		//public PokeBattle_Move_0D0(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			int ret = -1; _host.StartCoroutine(base.GetEffect(attacker, opponent, hitnum, alltargets, showanimation, result:value=>ret=value)); result(ret);
			if (opponent.damagestate.CalcDamage > 0 && !opponent.isFainted() &&
			   !opponent.damagestate.Substitute)
			{
				if (opponent.effects.MultiTurn == 0)
				{
					opponent.effects.MultiTurn = 5 + this.battle.Random(2);
					if (attacker.hasWorkingItem(Items.GRIP_CLAW))
					{
						opponent.effects.MultiTurn = (Core.USENEWBATTLEMECHANICS) ? 8 : 6;
					}
					opponent.effects.MultiTurnAttack = this.id;

					opponent.effects.MultiTurnUser = attacker.Index;

					_host.StartCoroutine(battle.Display(Game._INTL("{1} became trapped in the vortex!", opponent.ToString())));
				}
			}
			result(ret);
			yield break;
		}

		public int ModifyDamage(int damagemult, IBattler attacker, IBattler opponent)
		{
			if (Kernal.MoveData[(Moves)opponent.effects.TwoTurnAttack].Effect == Attack.Effects.x100)	// Dive
			{
				return (int)Math.Round(damagemult * 2.0f);
			}
			return damagemult;
		}
	}

	/// <summary>
	/// User must use this move for 2 more rounds. No battlers can sleep. (Uproar)
	/// <summary>
	public partial class PokeBattle_Move_0D1 : PokeBattle_Move
	{
		public PokeBattle_Move_0D1() : base() { }
		//public PokeBattle_Move_0D1(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			int ret = -1; _host.StartCoroutine(base.GetEffect(attacker, opponent, hitnum, alltargets, showanimation, result:value=>ret=value)); result(ret);
			if (opponent.damagestate.CalcDamage > 0)
			{
				if (attacker.effects.Uproar == 0)
				{
					attacker.effects.Uproar = 3;
					_host.StartCoroutine(battle.Display(Game._INTL("{1} caused an uproar!", attacker.ToString())));
					attacker.currentMove = this.id;
				}

			}
			result(ret);
			yield break;
		}
	}

	/// <summary>
	/// User must use this move for 1 or 2 more rounds. At end, user becomes confused.
	/// (Outrage, Petal Dange, Thrash)
	/// <summary>
	public partial class PokeBattle_Move_0D2 : PokeBattle_Move
	{
		public PokeBattle_Move_0D2() : base() { }
		//public PokeBattle_Move_0D2(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			int ret = -1; _host.StartCoroutine(base.GetEffect(attacker, opponent, hitnum, alltargets, showanimation, result:value=>ret=value)); result(ret);
			if (opponent.damagestate.CalcDamage > 0 &&
			   attacker.effects.Outrage == 0 &&
			   attacker.Status != Status.SLEEP)
			{
				attacker.effects.Outrage = 2 + this.battle.Random(2);

				attacker.currentMove = this.id;
			}
			else if (TypeModifier(this.type, attacker, opponent) == 0)
			{
				// Cancel effect if attack is ineffective
				attacker.effects.Outrage = 0;
			}

			if (attacker.effects.Outrage > 0)
			{

				attacker.effects.Outrage -= 1;
				if (attacker.effects.Outrage == 0 && attacker is IBattlerEffect b && b.CanConfuseSelf(false))
				{
					b.Confuse();
					_host.StartCoroutine(battle.Display(Game._INTL("{1} became confused due to fatigue!", attacker.ToString())));
				}
			}
			result(ret);
			yield break;
		}
	}

	/// <summary>
	/// User must use this move for 4 more rounds. Power doubles each round.
	/// Power is also doubled if user has curled up. (Ice Ball, Rollout)
	/// <summary>
	public partial class PokeBattle_Move_0D3 : PokeBattle_Move
	{
		public PokeBattle_Move_0D3() : base() { }
		//public PokeBattle_Move_0D3(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int BaseDamage(int basedmg, IBattler attacker, IBattler opponent)
		{
			byte shift = (byte)(4 - attacker.effects.Rollout); // from 0 through 4, 0 is most powerful
			if (attacker.effects.DefenseCurl) shift += 1;
			basedmg = basedmg << shift;
			return basedmg;
		}

		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{

			if (attacker.effects.Rollout == 0) attacker.effects.Rollout = 5;
			attacker.effects.Rollout -= 1;
			attacker.currentMove = MoveId;
			int ret = -1; _host.StartCoroutine(base.GetEffect(attacker, opponent, hitnum, alltargets, showanimation, result:value=>ret=value)); result(ret);
			if (opponent.damagestate.CalcDamage == 0 ||
			   TypeModifier(this.type, attacker, opponent) == 0 ||
			   attacker.Status == Status.SLEEP)
			{
				// Cancel effect if attack is ineffective
				attacker.effects.Rollout = 0;
			}
			result(ret);
			yield break;
		}
	}

	/// <summary>
	/// User bides its time this round and next round. The round after, deals 2x the
	/// total damage it took while biding to the last battler that damaged it. (Bide)
	/// <summary>
	public partial class PokeBattle_Move_0D4 : PokeBattle_Move
	{
		public PokeBattle_Move_0D4() : base() { }
		//public PokeBattle_Move_0D4(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int DisplayUseMessage(IBattler attacker)
		{
			if (attacker.effects.Bide == 0)
			{
				_host.StartCoroutine(battle.DisplayBrief(Game._INTL("{1} used\r\n{2}!", attacker.ToString(), Name)));
				attacker.effects.Bide = 2;
				attacker.effects.BideDamage = 0;
				attacker.effects.BideTarget = -1;
				attacker.currentMove = this.id;
				ShowAnimation(this.id, (IBattlerIE)attacker, null); //_host.StartCoroutine();
				return 1;
			}
			else
			{
				attacker.effects.Bide -= 1;
				if (attacker.effects.Bide == 0)
				{
					_host.StartCoroutine(battle.DisplayBrief(Game._INTL("{1} unleashed energy!", attacker.ToString())));
					return 0;
				}
				else
				{
					_host.StartCoroutine(battle.DisplayBrief(Game._INTL("{1} is storing energy!", attacker.ToString())));
					return 2;
				}
			}
		}

		public override void AddTarget(IList<IBattler> targets, IBattler attacker)
		{
			if (attacker.effects.BideTarget >= 0)
			{
				if (!attacker.AddTarget(targets, this.battle.battlers[attacker.effects.BideTarget]))
				{
					attacker.RandomTarget(targets);
				}
			}
			else
			{
				attacker.RandomTarget(targets);
			}
		}

		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (attacker.effects.BideDamage == 0 || opponent.Species == Pokemons.NONE)
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			if (Core.USENEWBATTLEMECHANICS)
			{
				float typemod = TypeModifier(GetType(this.type, attacker, opponent), attacker, opponent);
				if (typemod == 0)
				{
					_host.StartCoroutine(battle.Display(Game._INTL("It doesn't affect {1}...", opponent.ToString(true))));
					result(-1);
					yield break;
				}
			}

			int ret = EffectFixedDamage(attacker.effects.BideDamage * 2, attacker, opponent, hitnum, alltargets, showanimation);
			result(ret);
			yield break;
		}
	}

	/// <summary>
	/// Heals user by 1/2 of its max HP.
	/// <summary>
	public partial class PokeBattle_Move_0D5 : PokeBattle_Move
	{
		public PokeBattle_Move_0D5() : base() { }
		//public PokeBattle_Move_0D5(Battle battle, Attack.Move move) : base(battle, move) { }
		public override bool isHealingMove()
		{
			return true;
		}

		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (attacker.HP == attacker.TotalHP)
			{
				_host.StartCoroutine(battle.Display(Game._INTL("{1}'s HP is full!", attacker.ToString())));
				result(-1);
				yield break;
			}
			_host.StartCoroutine(ShowAnimation(this.id, attacker, null, hitnum, alltargets, showanimation));

			attacker.RecoverHP((int)Math.Floor((attacker.TotalHP + 1) / 2f), true);
			_host.StartCoroutine(battle.Display(Game._INTL("{1}'s HP was restored.", attacker.ToString())));
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// Heals user by 1/2 of its max HP. (Roost)
	/// User roosts, and its Flying type is ignored for attacks used against it.
	/// <summary>
	public partial class PokeBattle_Move_0D6 : PokeBattle_Move
	{
		public PokeBattle_Move_0D6() : base() { }
		//public PokeBattle_Move_0D6(Battle battle, Attack.Move move) : base(battle, move) { }
		public override bool isHealingMove()
		{
			return true;
		}

		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (attacker.HP == attacker.TotalHP)
			{
				_host.StartCoroutine(battle.Display(Game._INTL("{1}'s HP is full!", attacker.ToString())));
				result(-1);
				yield break;
			}
			_host.StartCoroutine(ShowAnimation(this.id, attacker, null, hitnum, alltargets, showanimation));

			attacker.RecoverHP((int)Math.Floor((attacker.TotalHP + 1) / 2f), true);
			attacker.effects.Roost = true;
			_host.StartCoroutine(battle.Display(Game._INTL("{1}'s HP was restored.", attacker.ToString())));
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// Pokemon in user's position is healed by 1/2 of its max HP, at the end of the
	/// next round. (Wish)
	/// <summary>
	public partial class PokeBattle_Move_0D7 : PokeBattle_Move
	{
		public PokeBattle_Move_0D7() : base() { }
		//public PokeBattle_Move_0D7(Battle battle, Attack.Move move) : base(battle, move) { }
		public override bool isHealingMove()
		{
			return true;
		}

		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (attacker.effects.Wish > 0)
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			_host.StartCoroutine(ShowAnimation(this.id, attacker, null, hitnum, alltargets, showanimation));

			attacker.effects.Wish = 2;
			attacker.effects.WishAmount = (int)Math.Floor((attacker.TotalHP + 1) / 2f);
			attacker.effects.WishMaker = attacker.pokemonIndex;
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// Heals user by an amount depending on the weather. (Moonlight, Morning Sun,
	/// Synthesis)
	/// <summary>
	public partial class PokeBattle_Move_0D8 : PokeBattle_Move
	{
		public PokeBattle_Move_0D8() : base() { }
		//public PokeBattle_Move_0D8(Battle battle, Attack.Move move) : base(battle, move) { }
		public override bool isHealingMove()
		{
			return true;
		}

		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (attacker.HP == attacker.TotalHP)
			{
				_host.StartCoroutine(battle.Display(Game._INTL("{1}'s HP is full!", attacker.ToString())));
				result(-1);
				yield break;
			}
			int hpgain = 0;
			if (this.battle.Weather == Weather.SUNNYDAY ||
			   this.battle.Weather == Weather.HARSHSUN)
			{
				hpgain = (int)Math.Floor(attacker.TotalHP * 2 / 3f);
			}
			else if (this.battle.Weather != 0)
			{
				hpgain = (int)Math.Floor(attacker.TotalHP / 4f);
			}
			else
			{
				hpgain = (int)Math.Floor(attacker.TotalHP / 2f);
			}
			_host.StartCoroutine(ShowAnimation(this.id, attacker, null, hitnum, alltargets, showanimation));
			attacker.RecoverHP(hpgain, true);

			_host.StartCoroutine(battle.Display(Game._INTL("{1}'s HP was restored.", attacker.ToString())));
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// Heals user to full HP. User falls asleep for 2 more rounds. (Rest)
	/// <summary>
	public partial class PokeBattle_Move_0D9 : PokeBattle_Move
	{
		public PokeBattle_Move_0D9() : base() { }
		//public PokeBattle_Move_0D9(Battle battle, Attack.Move move) : base(battle, move) { }
		public override bool isHealingMove()
		{
			return true;
		}

		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (attacker is IBattlerClause b && !b.CanSleep(attacker, true, this, true))
			{
				result(-1);
				yield break;
			}
			if (attacker.Status == Status.SLEEP)
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			if (attacker.HP == attacker.TotalHP)
			{
				_host.StartCoroutine(battle.Display(Game._INTL("{1}'s HP is full!", attacker.ToString())));
				result(-1);
				yield break;
			}
			_host.StartCoroutine(ShowAnimation(this.id, attacker, null, hitnum, alltargets, showanimation));

			if (attacker is IBattlerEffectIE a) a.SleepSelf(3);
			_host.StartCoroutine(battle.Display(Game._INTL("{1} slept and became healthy!", attacker.ToString())));
			int hp = -1; attacker.RecoverHP(attacker.TotalHP - attacker.HP, true, result:value=>hp=value);
			if (hp > 0) battle.Display(Game._INTL("{1}'s HP was restored.", attacker.ToString()));
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// Rings the user. Ringed Pokémon gain 1/16 of max HP at the end of each round.
	/// (Aqua Ring)
	/// <summary>
	public partial class PokeBattle_Move_0DA : PokeBattle_Move
	{
		public PokeBattle_Move_0DA() : base() { }
		//public PokeBattle_Move_0DA(Battle battle, Attack.Move move) : base(battle, move) { }
		public override bool isHealingMove()
		{
			return true;
		}

		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (attacker.effects.AquaRing)
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			_host.StartCoroutine(ShowAnimation(this.id, attacker, null, hitnum, alltargets, showanimation));

			attacker.effects.AquaRing = true;
			_host.StartCoroutine(battle.Display(Game._INTL("{1} surrounded itself with a veil of water!", attacker.ToString())));
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// Ingrains the user. Ingrained Pokémon gain 1/16 of max HP at the end of each
	/// round, and cannot flee or switch out. (Ingrain)
	/// <summary>
	public partial class PokeBattle_Move_0DB : PokeBattle_Move
	{
		public PokeBattle_Move_0DB() : base() { }
		//public PokeBattle_Move_0DB(Battle battle, Attack.Move move) : base(battle, move) { }
		public override bool isHealingMove()
		{
			return true;
		}

		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (attacker.effects.Ingrain)
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			_host.StartCoroutine(ShowAnimation(this.id, attacker, null, hitnum, alltargets, showanimation));

			attacker.effects.Ingrain = true;
			_host.StartCoroutine(battle.Display(Game._INTL("{1} planted its roots!", attacker.ToString())));
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// Seeds the target. Seeded Pokémon lose 1/8 of max HP at the end of each round,
	/// and the Pokémon in the user's position gains the same amount. (Leech Seed)
	/// <summary>
	public partial class PokeBattle_Move_0DC : PokeBattle_Move
	{
		public PokeBattle_Move_0DC() : base() { }
		//public PokeBattle_Move_0DC(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (opponent.effects.Substitute > 0 && !ignoresSubstitute(attacker))
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			if (TypeImmunityByAbility(GetType(this.type, attacker, opponent), attacker, opponent)) { result(-1); yield break; }
			if (opponent.effects.LeechSeed >= 0)
			{
				_host.StartCoroutine(battle.Display(Game._INTL("{1} evaded the attack!", opponent.ToString())));
				result(-1);
				yield break;
			}
			if (opponent.HasType(Types.GRASS))
			{
				_host.StartCoroutine(battle.Display(Game._INTL("It doesn't affect {1}...", opponent.ToString(true))));
				result(-1);
				yield break;
			}
			_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));

			opponent.effects.LeechSeed = attacker.Index;
			_host.StartCoroutine(battle.Display(Game._INTL("{1} was seeded!", opponent.ToString())));
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// User gains half the HP it inflicts as damage.
	/// <summary>
	public partial class PokeBattle_Move_0DD : PokeBattle_Move
	{
		public PokeBattle_Move_0DD() : base() { }
		//public PokeBattle_Move_0DD(Battle battle, Attack.Move move) : base(battle, move) { }
		public override bool isHealingMove()
		{
			return Core.USENEWBATTLEMECHANICS;
		}

		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			int ret = -1; _host.StartCoroutine(base.GetEffect(attacker, opponent, hitnum, alltargets, showanimation, result:value=>ret=value)); result(ret);
			if (opponent.damagestate.CalcDamage > 0)
			{
				int hpgain = (int)Math.Round(opponent.damagestate.HPLost / 2f);
				if (opponent.hasWorkingAbility(Abilities.LIQUID_OOZE))
				{
					attacker.ReduceHP(hpgain, true);
					_host.StartCoroutine(battle.Display(Game._INTL("{1} sucked up the liquid ooze!", attacker.ToString())));
				}
				else if (attacker.effects.HealBlock == 0)
				{

					if (attacker.hasWorkingItem(Items.BIG_ROOT)) hpgain = (int)Math.Floor(hpgain * 1.3f);

					attacker.RecoverHP(hpgain, true);
					_host.StartCoroutine(battle.Display(Game._INTL("{1} had its energy drained!", opponent.ToString())));
				}
			}
			result(ret);
			yield break;
		}
	}

	/// <summary>
	/// User gains half the HP it inflicts as damage. (Dream Eater)
	/// (Handled in Pokemon's SuccessCheck): Fails if target is not asleep.
	/// <summary>
	public partial class PokeBattle_Move_0DE : PokeBattle_Move
	{
		public PokeBattle_Move_0DE() : base() { }
		//public PokeBattle_Move_0DE(Battle battle, Attack.Move move) : base(battle, move) { }
		public override bool isHealingMove()
		{
			return Core.USENEWBATTLEMECHANICS;
		}

		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			int ret = -1; _host.StartCoroutine(base.GetEffect(attacker, opponent, hitnum, alltargets, showanimation, result:value=>ret=value)); result(ret);
			if (opponent.damagestate.CalcDamage > 0)
			{
				int hpgain = (int)Math.Round(opponent.damagestate.HPLost / 2f);
				if (opponent.hasWorkingAbility(Abilities.LIQUID_OOZE))
				{
					attacker.ReduceHP(hpgain, true);
					_host.StartCoroutine(battle.Display(Game._INTL("{1} sucked up the liquid ooze!", attacker.ToString())));
				}
				else if (attacker.effects.HealBlock == 0)
				{

					if (attacker.hasWorkingItem(Items.BIG_ROOT)) hpgain = (int)Math.Floor(hpgain * 1.3f);

					attacker.RecoverHP(hpgain, true);
					_host.StartCoroutine(battle.Display(Game._INTL("{1} had its energy drained!", opponent.ToString())));
				}
			}
			result(ret);
			yield break;
		}
	}

	/// <summary>
	/// Heals target by 1/2 of its max HP. (Heal Pulse)
	/// <summary>
	public partial class PokeBattle_Move_0DF : PokeBattle_Move
	{
		public PokeBattle_Move_0DF() : base() { }
		//public PokeBattle_Move_0DF(Battle battle, Attack.Move move) : base(battle, move) { }
		public override bool isHealingMove()
		{
			return true;
		}

		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (opponent.effects.Substitute > 0 && !ignoresSubstitute(attacker))
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			if (opponent.HP == opponent.TotalHP)
			{
				_host.StartCoroutine(battle.Display(Game._INTL("{1}'s HP is full!", opponent.ToString())));
				result(-1);
				yield break;
			}
			_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));

			int hpgain = (int)Math.Floor((opponent.TotalHP + 1) / 2f);
			if (attacker.hasWorkingAbility(Abilities.MEGA_LAUNCHER)) hpgain = (int)Math.Round(opponent.TotalHP * 3 / 4f);
			opponent.RecoverHP(hpgain, true);
			_host.StartCoroutine(battle.Display(Game._INTL("{1}'s HP was restored.", opponent.ToString())));
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// User faints. (Explosion, Selfdestruct)
	/// <summary>
	public partial class PokeBattle_Move_0E0 : PokeBattle_Move, IBattleMove
	{
		public PokeBattle_Move_0E0() : base() { }
		//public PokeBattle_Move_0E0(Battle battle, Attack.Move move) : base(battle, move) { }
		//private bool _pbOnStartUse(IBattler attacker)
		bool IBattleMove.OnStartUse(IBattler attacker)
		{
			if (!attacker.hasMoldBreaker())
			{
				IBattler bearer = this.battle.CheckGlobalAbility(Abilities.DAMP);
				if (bearer != null)
				{
					_host.StartCoroutine(battle.Display(Game._INTL("{1}'s {2} prevents {3} from using {4}!",
					   bearer.ToString(), Game._INTL(bearer.Ability.ToString(TextScripts.Name)), attacker.ToString(true), Name)));
					return false;
				}
			}
			return true;
		}

		public override void ShowAnimation(Moves id, IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true)
		{

			base.ShowAnimation(id, attacker, opponent, hitnum, alltargets, showanimation);
			if (!attacker.isFainted())
			{
				attacker.ReduceHP(attacker.HP);

				if (attacker.isFainted()) attacker.Faint();
			}
		}
	}

	/// <summary>
	/// Inflicts fixed damage equal to user's current HP. (Final Gambit)
	/// User faints (if successful).
	/// <summary>
	public partial class PokeBattle_Move_0E1 : PokeBattle_Move
	{
		public PokeBattle_Move_0E1() : base() { }
		//public PokeBattle_Move_0E1(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			float typemod = TypeModifier(GetType(this.type, attacker, opponent), attacker, opponent);
			if (typemod == 0)
			{
				_host.StartCoroutine(battle.Display(Game._INTL("It doesn't affect {1}...", opponent.ToString(true))));
				result(-1);
				yield break;
			}
			int ret = EffectFixedDamage(attacker.HP, attacker, opponent, hitnum, alltargets, showanimation);
			result(ret);
			yield break;
		}

		public override void ShowAnimation(Moves id, IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true)
		{

			base.ShowAnimation(id, attacker, opponent, hitnum, alltargets, showanimation);
			if (!attacker.isFainted())
			{
				attacker.ReduceHP(attacker.HP);

				if (attacker.isFainted()) attacker.Faint();
			}
		}
	}

	/// <summary>
	/// Decreases the target's Attack and Special Attack by 2 stages each. (Memento)
	/// User faints (even if effect does nothing).
	/// <summary>
	public partial class PokeBattle_Move_0E2 : PokeBattle_Move
	{
		public PokeBattle_Move_0E2() : base() { }
		//public PokeBattle_Move_0E2(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (opponent.effects.Substitute > 0 && !ignoresSubstitute(attacker))
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));

			int ret = -1; bool showanim = true;
			if (opponent is IBattlerEffect b0 && b0.ReduceStat(Stats.ATTACK, 2, attacker, false, this, showanim))
			{
				ret = 0; showanim = false;
			}
			if (opponent is IBattlerEffect b1 && b1.ReduceStat(Stats.SPATK, 2, attacker, false, this, showanim))
			{
				ret = 0; showanim = false;
			}
			attacker.ReduceHP(attacker.HP);
			result(ret);
			yield break;
		}
	}

	/// <summary>
	/// User faints. The Pokémon that replaces the user is fully healed (HP and
	/// status). Fails if user won't be replaced. (Healing Wish)
	/// <summary>
	public partial class PokeBattle_Move_0E3 : PokeBattle_Move
	{
		public PokeBattle_Move_0E3() : base() { }
		//public PokeBattle_Move_0E3(Battle battle, Attack.Move move) : base(battle, move) { }
		public override bool isHealingMove()
		{
			return true;
		}

		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (!this.battle.CanChooseNonActive(attacker.Index))
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			_host.StartCoroutine(ShowAnimation(this.id, attacker, null, hitnum, alltargets, showanimation));

			attacker.ReduceHP(attacker.HP);
			attacker.effects.HealingWish = true;
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// User faints. The Pokémon that replaces the user is fully healed (HP, PP and
	/// status). Fails if user won't be replaced. (Lunar Dance)
	/// <summary>
	public partial class PokeBattle_Move_0E4 : PokeBattle_Move
	{
		public PokeBattle_Move_0E4() : base() { }
		//public PokeBattle_Move_0E4(Battle battle, Attack.Move move) : base(battle, move) { }
		public override bool isHealingMove()
		{
			return true;
		}

		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (!this.battle.CanChooseNonActive(attacker.Index))
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			_host.StartCoroutine(ShowAnimation(this.id, attacker, null, hitnum, alltargets, showanimation));

			attacker.ReduceHP(attacker.HP);
			attacker.effects.LunarDance = true;
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// All current battlers will perish after 3 more rounds. (Perish Song)
	/// <summary>
	public partial class PokeBattle_Move_0E5 : PokeBattle_Move
	{
		public PokeBattle_Move_0E5() : base() { }
		//public PokeBattle_Move_0E5(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			bool failed = true;
			for (int i = 0; i < 4; i++)
			{
				if (this.battle.battlers[i].effects.PerishSong == 0 &&
				   (attacker.hasMoldBreaker() ||
				   !this.battle.battlers[i].hasWorkingAbility(Abilities.SOUNDPROOF)))
				{
					failed = false; break;
				}
			}
			if (failed)
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			_host.StartCoroutine(ShowAnimation(this.id, attacker, null, hitnum, alltargets, showanimation));

			_host.StartCoroutine(battle.Display(Game._INTL("All Pokémon that hear the song will faint in three turns!")));
			for (int i = 0; i < 4; i++)
			{
				if (this.battle.battlers[i].effects.PerishSong == 0)
				{
					if (!attacker.hasMoldBreaker() && this.battle.battlers[i].hasWorkingAbility(Abilities.SOUNDPROOF))
					{
						_host.StartCoroutine(battle.Display(Game._INTL("{1}'s {2} blocks {3}!", this.battle.battlers[i].ToString(),
							 //Abilities.getName(this.battle.battlers[i].Ability), Name)));
							 Game._INTL(this.battle.battlers[i].Ability.ToString(TextScripts.Name)), Name)));
					}
					else
					{
						this.battle.battlers[i].effects.PerishSong = 4;
						this.battle.battlers[i].effects.PerishSongUser = attacker.Index;
					}
				}
			}
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// If user is KO'd before it next moves, the attack that caused it loses all PP.
	/// (Grudge)
	/// <summary>
	public partial class PokeBattle_Move_0E6 : PokeBattle_Move
	{
		public PokeBattle_Move_0E6() : base() { }
		//public PokeBattle_Move_0E6(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			_host.StartCoroutine(ShowAnimation(this.id, attacker, null, hitnum, alltargets, showanimation));

			attacker.effects.Grudge = true;
			_host.StartCoroutine(battle.Display(Game._INTL("{1} wants its target to bear a grudge!", attacker.ToString())));
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// If user is KO'd before it next moves, the battler that caused it also faints.
	/// (Destiny Bond)
	/// <summary>
	public partial class PokeBattle_Move_0E7 : PokeBattle_Move
	{
		public PokeBattle_Move_0E7() : base() { }
		//public PokeBattle_Move_0E7(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			_host.StartCoroutine(ShowAnimation(this.id, attacker, null, hitnum, alltargets, showanimation));

			attacker.effects.DestinyBond = true;
			_host.StartCoroutine(battle.Display(Game._INTL("{1} is trying to take its foe down with it!", attacker.ToString())));
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// If user would be KO'd this round, it survives with 1HP instead. (Endure)
	/// <summary>
	public partial class PokeBattle_Move_0E8 : PokeBattle_Move
	{
		public PokeBattle_Move_0E8() : base() { }
		//public PokeBattle_Move_0E8(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			List<Attack.Effects> ratesharers = new List<Attack.Effects> {
				Attack.Effects.x070,	// Detect, Protect
				Attack.Effects.x133,	// Quick Guard
				Attack.Effects.x117,	// Wide Guard
				Attack.Effects.x075,	// Endure
				Attack.Effects.x164,	// King's Shield
				Attack.Effects.x16A	// Spiky Shield
			};
			if (!ratesharers.Contains(Kernal.MoveData[(Moves)attacker.lastMoveUsed].Effect))
			{
				attacker.effects.ProtectRate = 1;
			}
			bool unmoved = false;
			foreach (IBattler poke in this.battle.battlers)
			{
				if (poke.Index == attacker.Index) continue; //next
				if ((int)this.battle.choices[poke.Index].Action == 1 && // Chose a move
				   !poke.hasMovedThisRound())
				{
					unmoved = true; break;
				}
			}
			if (!unmoved ||
			   this.battle.Random(65536) > Math.Floor(65536f / attacker.effects.ProtectRate))
			{
				attacker.effects.ProtectRate = 1;

				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			_host.StartCoroutine(ShowAnimation(this.id, attacker, null, hitnum, alltargets, showanimation));

			attacker.effects.Endure = true;
			attacker.effects.ProtectRate *= 2;
			_host.StartCoroutine(battle.Display(Game._INTL("{1} braced itself!", attacker.ToString())));
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// If target would be KO'd by this attack, it survives with 1HP instead. (False Swipe)
	/// <summary>
	public partial class PokeBattle_Move_0E9 : PokeBattle_Move
	{
		public PokeBattle_Move_0E9() : base() { }
		//public PokeBattle_Move_0E9(Battle battle, Attack.Move move) : base(battle, move) { }
		// Handled in superclass public object ReduceHPDamage, do not edit!
	}

	/// <summary>
	/// User flees from battle. Fails in trainer battles. (Teleport)
	/// <summary>
	public partial class PokeBattle_Move_0EA : PokeBattle_Move
	{
		public PokeBattle_Move_0EA() : base() { }
		//public PokeBattle_Move_0EA(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (this.battle.opponent.Length == 0 ||
			   !this.battle.CanRun(attacker.Index))
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));

			_host.StartCoroutine(battle.Display(Game._INTL("{1} fled from battle!", attacker.ToString())));
			this.battle.decision = (BattleResults)3;
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// In wild battles, makes target flee. Fails if target is a higher level than the
	/// user.
	/// In trainer battles, target switches out.
	/// For status moves. (Roar, Whirlwind)
	/// <summary>
	public partial class PokeBattle_Move_0EB : PokeBattle_Move
	{
		public PokeBattle_Move_0EB() : base() { }
		//public PokeBattle_Move_0EB(Battle battle, Attack.Move move) : base(battle, move) { }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result = null)
		{
			if (!attacker.hasMoldBreaker() && opponent.hasWorkingAbility(Abilities.SUCTION_CUPS))
			{
				yield return battle.Display(Game._INTL("{1} anchored itself with {2}!", opponent.ToString(), Game._INTL(opponent.Ability.ToString(TextScripts.Name))));
				result?.Invoke(-1); yield break;
			}
			if (opponent.effects.Ingrain)
			{
				yield return battle.Display(Game._INTL("{1} anchored itself with its roots!", opponent.ToString()));
				result?.Invoke(-1); yield break;
			}
			if (this.battle.opponent.Length == 0)
			{
				if (opponent.Level > attacker.Level)
				{
					yield return battle.Display(Game._INTL("But it failed!"));
					result?.Invoke(-1); yield break;
				}
				yield return ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation);

				this.battle.decision = (BattleResults)3; // Set decision to escaped;
				result?.Invoke(0); yield break;
			}
			else
			{
				bool choices = false;
				IPokemon[] party = this.battle.Party(opponent.Index);
				for (int i = 0; i < party.Length; i++)
				{
					bool canSwitch = false;
					yield return this.battle.CanSwitch(opponent.Index, i, false, true, result: value => canSwitch = value);
					if (canSwitch)
					{
						choices = true;
						break;
					}
				}
				if (!choices)
				{
					yield return battle.Display(Game._INTL("But it failed!"));
					result?.Invoke(-1); yield break;
				}
				yield return ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation);

				opponent.effects.Roar = true;
				result?.Invoke(0);
			}
		}
	}

	/// <summary>
	/// In wild battles, makes target flee. Fails if target is a higher level than the
	/// user.
	/// In trainer battles, target switches out.
	/// For damaging moves. (Circle Throw, Dragon Tail)
	/// <summary>
	public partial class PokeBattle_Move_0EC : PokeBattle_Move
	{
		public PokeBattle_Move_0EC() : base() { }
		//public PokeBattle_Move_0EC(Battle battle, Attack.Move move) : base(battle, move) { }
		public override IEnumerator EffectAfterHit(IBattlerIE attacker, IBattlerIE opponent, IEffectsMove turneffects)
		{
			if (!attacker.isFainted() && !opponent.isFainted() &&
			   opponent.damagestate.CalcDamage > 0 && !opponent.damagestate.Substitute &&
			   (attacker.hasMoldBreaker() || !opponent.hasWorkingAbility(Abilities.SUCTION_CUPS)) &&
			   !opponent.effects.Ingrain)
			{
				if (this.battle.opponent.Length == 0)//Wild Pokemon Battle
				{
					if (opponent.Level <= attacker.Level)
					{
						this.battle.decision = (BattleResults)3; // Set decision to escaped;
					}
				}
				else
				{

					IPokemon[] party = this.battle.Party(opponent.Index);
					for (int i = 0; i < party.Length - 1; i++)	//ToDo: Double check this
					{
						bool canSwitch = false;
						yield return this.battle.CanSwitch(opponent.Index, i, false, result: value => canSwitch = value);
						if (canSwitch)
						{
							opponent.effects.Roar = true;
							break;
						}
					}

				}
			}
		}
	}

	/// <summary>
	/// User switches out. Various effects affecting the user are passed to the
	/// replacement. (Baton Pass)
	/// <summary>
	public partial class PokeBattle_Move_0ED : PokeBattle_Move
	{
		public PokeBattle_Move_0ED() : base() { }
		//public PokeBattle_Move_0ED(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (!this.battle.CanChooseNonActive(attacker.Index))
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			_host.StartCoroutine(ShowAnimation(this.id, attacker, null, hitnum, alltargets, showanimation));

			attacker.effects.BatonPass = true;
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// After inflicting damage, user switches out. Ignores trapping moves.
	/// (U-turn, Volt Switch)
	/// TODO: Pursuit should interrupt this move.
	/// <summary>
	public partial class PokeBattle_Move_0EE : PokeBattle_Move
	{
		public PokeBattle_Move_0EE() : base() { }
		//public PokeBattle_Move_0EE(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			int ret = -1; _host.StartCoroutine(base.GetEffect(attacker, opponent, hitnum, alltargets, showanimation, result:value=>ret=value)); result(ret);
			if (!attacker.isFainted() && opponent.damagestate.CalcDamage > 0 &&
			   this.battle.CanChooseNonActive(attacker.Index) &&
			   !this.battle.AllFainted(this.battle.Party(opponent.Index)))
			{
				attacker.effects.Uturn = true;
			}
			result(ret);
			yield break;
		}
	}

	/// <summary>
	/// Target can no longer switch out or flee, as long as the user remains active.
	/// (Block, Mean Look, Spider Web, Thousand Waves)
	/// <summary>
	public partial class PokeBattle_Move_0EF : PokeBattle_Move
	{
		public PokeBattle_Move_0EF() : base() { }
		//public PokeBattle_Move_0EF(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (IsDamaging())
			{
				int ret = -1; _host.StartCoroutine(base.GetEffect(attacker, opponent, hitnum, alltargets, showanimation, result:value=>ret=value)); result(ret);
				if (opponent.damagestate.CalcDamage > 0 && !opponent.damagestate.Substitute &&
				   !opponent.isFainted())
				{
					if (opponent.effects.MeanLook < 0 &&
					   (!Core.USENEWBATTLEMECHANICS || !opponent.HasType(Types.GHOST)))
					{
						opponent.effects.MeanLook = attacker.Index;
						_host.StartCoroutine(battle.Display(Game._INTL("{1} can no longer escape!", opponent.ToString())));
					}
				}
				result(ret);
				yield break;
			}
			if (opponent.effects.MeanLook >= 0 ||
			   (opponent.effects.Substitute > 0 && !ignoresSubstitute(attacker)))
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			if (Core.USENEWBATTLEMECHANICS && opponent.HasType(Types.GHOST))
			{
				_host.StartCoroutine(battle.Display(Game._INTL("It doesn't affect {1}...", opponent.ToString(true))));
				result(-1);
				yield break;
			}
			_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));

			opponent.effects.MeanLook = attacker.Index;
			_host.StartCoroutine(battle.Display(Game._INTL("{1} can no longer escape!", opponent.ToString())));
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// Target drops its item. It regains the item at the end of the battle. (Knock Off)
	/// If target has a losable item, damage is multiplied by 1.5.
	/// <summary>
	public partial class PokeBattle_Move_0F0 : PokeBattle_Move
	{
		public PokeBattle_Move_0F0() : base() { }
		//public PokeBattle_Move_0F0(Battle battle, Attack.Move move) : base(battle, move) { }
		public override void EffectAfterHit(IBattler attacker, IBattler opponent, IEffectsMove turneffects) { this.EffectAfterHit((IBattlerIE)attacker, (IBattlerIE)opponent, turneffects); }
		public override IEnumerator EffectAfterHit(IBattlerIE attacker, IBattlerIE opponent, IEffectsMove turneffects)
		{
			if (!attacker.isFainted() && !opponent.isFainted() && opponent.Item != 0 &&
				opponent.damagestate.CalcDamage > 0 && !opponent.damagestate.Substitute)
			{
				if (!attacker.hasMoldBreaker() && opponent.hasWorkingAbility(Abilities.STICKY_HOLD))
				{
					string abilityname = Game._INTL(opponent.Ability.ToString(TextScripts.Name));
					_host.StartCoroutine(battle.Display(Game._INTL("{1}'s {2} made {3} ineffective!", opponent.ToString(), abilityname, Kernal.MoveData[MoveId].Name)));
				}
				else if (!this.battle.IsUnlosableItem(opponent, opponent.Item))
				{
					string itemname = Kernal.ItemData[opponent.Item].Name;

					opponent.Item = 0;
					opponent.effects.ChoiceBand = Moves.NONE;//-1;
					opponent.effects.Unburden = true;
					_host.StartCoroutine(battle.Display(Game._INTL("{1} dropped its {2}!", opponent.ToString(), itemname)));
				}
			}
			yield break;
		}

		public int ModifyDamage(int damagemult, IBattler attacker, IBattler opponent)
		{
			if (Core.USENEWBATTLEMECHANICS &&
			   !this.battle.IsUnlosableItem(opponent, opponent.Item))
			{
				// Still boosts damage even if opponent has Sticky Hold
				return (int)Math.Round(damagemult * 1.5f);
			}
			return damagemult;
		}
	}

	/// <summary>
	/// User steals the target's item, if the user has none itself. (Covet, Thief)
	/// Items stolen from wild Pokémon are kept after the battle.
	/// <summary>
	public partial class PokeBattle_Move_0F1 : PokeBattle_Move
	{
		public PokeBattle_Move_0F1() : base() { }
		//public PokeBattle_Move_0F1(Battle battle, Attack.Move move) : base(battle, move) { }
		public override void EffectAfterHit(IBattler attacker, IBattler opponent, IEffectsMove turneffects) { this.EffectAfterHit((IBattlerIE)attacker, (IBattlerIE)opponent, turneffects); }
		public override IEnumerator EffectAfterHit(IBattlerIE attacker, IBattlerIE opponent, IEffectsMove turneffects)
		{
			if (!attacker.isFainted() && !opponent.isFainted() && opponent.Item != 0 &&
			   opponent.damagestate.CalcDamage > 0 && !opponent.damagestate.Substitute)
			{
				if (!attacker.hasMoldBreaker() && opponent.hasWorkingAbility(Abilities.STICKY_HOLD))
				{
					string abilityname = Game._INTL(opponent.Ability.ToString(TextScripts.Name));
					_host.StartCoroutine(battle.Display(Game._INTL("{1}'s {2} made {3} ineffective!", opponent.ToString(), abilityname, Kernal.MoveData[MoveId].Name)));
				}
				else if (!this.battle.IsUnlosableItem(opponent, opponent.Item) &&
					!this.battle.IsUnlosableItem(attacker, opponent.Item) &&
					attacker.Item == 0 &&
					(this.battle.opponent.Length == 0 || !this.battle.IsOpposing(attacker.Index)))
				{
					string itemname = Kernal.ItemData[opponent.Item].Name;
					attacker.Item = opponent.Item;
					opponent.Item = 0;

					opponent.effects.ChoiceBand = Moves.NONE;//-1;

					opponent.effects.Unburden = true;
					if (this.battle.opponent.Length == 0 && // In a wild battle
					   attacker.pokemon.itemInitial == 0 &&
					   opponent.pokemon.itemInitial == attacker.Item)
					{
						attacker.pokemon.itemInitial = attacker.Item;
						opponent.pokemon.itemInitial = 0;
					}
					_host.StartCoroutine(battle.Display(Game._INTL("{1} stole {2}'s {3}!", attacker.ToString(), opponent.ToString(true), itemname)));
				}
			}
			yield break;
		}
	}

	/// <summary>
	/// User and target swap items. They remain swapped after wild battles.
	/// (Switcheroo, Trick)
	/// <summary>
	public partial class PokeBattle_Move_0F2 : PokeBattle_Move
	{
		public PokeBattle_Move_0F2() : base() { }
		//public PokeBattle_Move_0F2(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if ((opponent.effects.Substitute > 0 && !ignoresSubstitute(attacker)) ||
			   (attacker.Item == 0 && opponent.Item == 0) ||
			   (this.battle.opponent.Length == 0 && this.battle.IsOpposing(attacker.Index)))
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			if (this.battle.IsUnlosableItem(opponent, opponent.Item) ||
			   this.battle.IsUnlosableItem(attacker, opponent.Item) ||
			   this.battle.IsUnlosableItem(opponent, attacker.Item) ||
			   this.battle.IsUnlosableItem(attacker, attacker.Item))
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			if (!attacker.hasMoldBreaker() && opponent.hasWorkingAbility(Abilities.STICKY_HOLD))
			{
				string abilityname = Game._INTL(opponent.Ability.ToString(TextScripts.Name));
				_host.StartCoroutine(battle.Display(Game._INTL("{1}'s {2} made {3} ineffective!", opponent.ToString(), abilityname, Name)));
				result(-1);
				yield break;
			}
			_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));

			Items oldattitem = attacker.Item;
			Items oldoppitem = opponent.Item;

			string oldattitemname = Kernal.ItemData[oldattitem].Name;
			string oldoppitemname = Kernal.ItemData[oldoppitem].Name;

			Items tmpitem = attacker.Item;
			attacker.Item = opponent.Item;
			opponent.Item = tmpitem;
			if (this.battle.opponent.Length == 0 && // In a wild battle
			   attacker.pokemon.itemInitial == oldattitem &&
			   opponent.pokemon.itemInitial == oldoppitem)
			{
				attacker.pokemon.itemInitial = oldoppitem;
				opponent.pokemon.itemInitial = oldattitem;
			}
			_host.StartCoroutine(battle.Display(Game._INTL("{1} switched items with its opponent!", attacker.ToString())));
			if (oldoppitem > 0 && oldattitem > 0)
			{
				_host.StartCoroutine(battle.DisplayPaused(Game._INTL("{1} obtained {2}.", attacker.ToString(), oldoppitemname)));
				_host.StartCoroutine(battle.Display(Game._INTL("{1} obtained {2}.", opponent.ToString(), oldattitemname)));
			}
			else
			{
				if (oldoppitem > 0) battle.Display(Game._INTL("{1} obtained {2}.", attacker.ToString(), oldoppitemname));
				if (oldattitem > 0) battle.Display(Game._INTL("{1} obtained {2}.", opponent.ToString(), oldattitemname));
			}
			attacker.effects.ChoiceBand = Moves.NONE;//-1;

			opponent.effects.ChoiceBand = Moves.NONE;//-1;
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// User gives its item to the target. The item remains given after wild battles.
	/// (Bestow)
	/// <summary>
	public partial class PokeBattle_Move_0F3 : PokeBattle_Move
	{
		public PokeBattle_Move_0F3() : base() { }
		//public PokeBattle_Move_0F3(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if ((opponent.effects.Substitute > 0 && !ignoresSubstitute(attacker)) ||
			   attacker.Item == 0 || opponent.Item != 0)
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			if (this.battle.IsUnlosableItem(attacker, attacker.Item) ||
			   this.battle.IsUnlosableItem(opponent, attacker.Item))
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));

			string itemname = Kernal.ItemData[attacker.Item].Name;
			opponent.Item = attacker.Item;
			attacker.Item = 0;

			attacker.effects.ChoiceBand = Moves.NONE;//-1;

			attacker.effects.Unburden = true;
			if (this.battle.opponent.Length == 0 && // In a wild battle
			   opponent.pokemon.itemInitial == 0 &&
			   attacker.pokemon.itemInitial == opponent.Item)
			{
				opponent.pokemon.itemInitial = opponent.Item;
				attacker.pokemon.itemInitial = 0;
			}
			_host.StartCoroutine(battle.Display(Game._INTL("{1} received {2} from {3}!", opponent.ToString(), itemname, attacker.ToString(true))));
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// User consumes target's berry and gains its effect. (Bug Bite, Pluck)
	/// <summary>
	public partial class PokeBattle_Move_0F4 : PokeBattle_Move
	{
		public PokeBattle_Move_0F4() : base() { }
		//public PokeBattle_Move_0F4(Battle battle, Attack.Move move) : base(battle, move) { }
		public override void EffectAfterHit(IBattler attacker, IBattler opponent, IEffectsMove turneffects) { this.EffectAfterHit((IBattlerIE)attacker, (IBattlerIE)opponent, turneffects); }
		public override IEnumerator EffectAfterHit(IBattlerIE attacker, IBattlerIE opponent, IEffectsMove turneffects)
		{
			if (!attacker.isFainted() && !opponent.isFainted() && Game.GameData is IItemCheck i && i.IsBerry(opponent.Item) &&
			   opponent.damagestate.CalcDamage > 0 && !opponent.damagestate.Substitute)
			{
				if (attacker.hasMoldBreaker() || !opponent.hasWorkingAbility(Abilities.STICKY_HOLD))
				{
					Items item = opponent.Item;
					string itemname = Kernal.ItemData[item].Name;

					_host.StartCoroutine(opponent.ConsumeItem(false, false));
					_host.StartCoroutine(battle.Display(Game._INTL("{1} stole and ate its target's {2}!", attacker.ToString(), itemname)));
					if (!attacker.hasWorkingAbility(Abilities.KLUTZ) &&
					   attacker.effects.Embargo == 0)
					{
						attacker.ActivateBerryEffect(item, false);
					}
					// Symbiosis
					if (attacker.Item == 0 &&
					   attacker.Partner.IsNotNullOrNone() && attacker.Partner.hasWorkingAbility(Abilities.SYMBIOSIS))
					{
						IBattler partner = attacker.Partner;
						if (partner.Item > 0 &&
						   !this.battle.IsUnlosableItem(partner, partner.Item) &&
						   !this.battle.IsUnlosableItem(attacker, partner.Item))
						{
							_host.StartCoroutine(battle.Display(Game._INTL("{1}'s {2} let it share its {3} with {4}!",
							   partner.ToString(), Game._INTL(partner.Ability.ToString(TextScripts.Name)),
							   Kernal.ItemData[partner.Item].Name, attacker.ToString(true))));
							attacker.Item = partner.Item;
							partner.Item = 0;
							partner.effects.Unburden = true;

							attacker.BerryCureCheck();
						}

					}
				}
			}
			yield break;
		}
	}

	/// <summary>
	/// Target's berry is destroyed. (Incinerate)
	/// <summary>
	public partial class PokeBattle_Move_0F5 : PokeBattle_Move
	{
		public PokeBattle_Move_0F5() : base() { }
		//public PokeBattle_Move_0F5(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			int ret = -1; _host.StartCoroutine(base.GetEffect(attacker, opponent, hitnum, alltargets, showanimation, result:value=>ret=value)); result(ret);
			if (!attacker.isFainted() && opponent.damagestate.CalcDamage > 0 &&
			   !opponent.damagestate.Substitute &&
			   (Game.GameData is IItemCheck i && i.IsBerry(opponent.Item) || (Core.USENEWBATTLEMECHANICS && i.IsGem(opponent.Item))))
			{
				string itemname = Kernal.ItemData[opponent.Item].Name;
				_host.StartCoroutine(opponent.ConsumeItem(false, false));

				_host.StartCoroutine(battle.Display(Game._INTL("{1}'s {2} was incinerated!", opponent.ToString(), itemname)));
			}
			result(ret);
			yield break;
		}
	}

	/// <summary>
	/// User recovers the last item it held and consumed. (Recycle)
	/// <summary>
	public partial class PokeBattle_Move_0F6 : PokeBattle_Move
	{
		public PokeBattle_Move_0F6() : base() { }
		//public PokeBattle_Move_0F6(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (attacker.Species == Pokemons.NONE || attacker.pokemon.itemRecycle == 0)
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			_host.StartCoroutine(ShowAnimation(this.id, attacker, null, hitnum, alltargets, showanimation));

			Items item = attacker.pokemon.itemRecycle;
			string itemname = Kernal.ItemData[item].Name;

			attacker.Item = item;
			if (this.battle.opponent.Length == 0)	// In a wild battle
			{
				if (attacker.pokemon.itemInitial == 0) attacker.pokemon.itemInitial = item;
			}
			attacker.pokemon.itemRecycle = 0;

			attacker.effects.PickupItem = 0;

			attacker.effects.PickupUse = 0;

			_host.StartCoroutine(battle.Display(Game._INTL("{1} found one {2}!", attacker.ToString(), itemname)));
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// User flings its item at the target. Power and effect depend on the item. (Fling)
	/// <summary>
	public partial class PokeBattle_Move_0F7 : PokeBattle_Move
	{
		public PokeBattle_Move_0F7() : base() { }
		//public PokeBattle_Move_0F7(Battle battle, Attack.Move move) : base(battle, move) { }
		public Dictionary<Items, byte> flingarray
		{
			get
			{
				return new Dictionary<Items, byte> {
		   //130 =>
					{ Items.IRON_BALL, 130 },
		   //100 =>
					{ Items.ARMOR_FOSSIL, 100 },    { Items.CLAW_FOSSIL, 100 }, { Items.COVER_FOSSIL, 100 },    { Items.DOME_FOSSIL, 100 }, { Items.HARD_STONE, 100 },
					{ Items.HELIX_FOSSIL, 100 },    { Items.JAW_FOSSIL, 100 },  { Items.OLD_AMBER, 100 },   { Items.PLUME_FOSSIL, 100 },    { Items.RARE_BONE, 100 },
					{ Items.ROOT_FOSSIL, 100 }, { Items.SAIL_FOSSIL, 100 }, { Items.SKULL_FOSSIL, 100 },
			//90 =>
					{ Items.DEEP_SEA_TOOTH, 90 },   { Items.DRACO_PLATE, 90 },  { Items.DREAD_PLATE, 90 },  { Items.EARTH_PLATE, 90 },  { Items.FIST_PLATE, 90 },
					{ Items.FLAME_PLATE, 90 },  { Items.GRIP_CLAW, 90 },        { Items.ICICLE_PLATE, 90 }, { Items.INSECT_PLATE, 90 }, { Items.IRON_PLATE, 90 },
					{ Items.MEADOW_PLATE, 90 }, { Items.MIND_PLATE, 90 },   { Items.PIXIE_PLATE, 90 },  { Items.SKY_PLATE, 90 },        { Items.SPLASH_PLATE, 90 },
					{ Items.SPOOKY_PLATE, 90 }, { Items.STONE_PLATE, 90 },  { Items.THICK_CLUB, 90 },   { Items.TOXIC_PLATE, 90 },  { Items.ZAP_PLATE, 90 },
			//80 =>
					{ Items.ASSAULT_VEST, 80 }, { Items.DAWN_STONE, 80 },   { Items.DUSK_STONE, 80 },   { Items.ELECTIRIZER, 80 },  { Items.MAGMARIZER, 80 },
					{ Items.ODD_KEYSTONE, 80 }, { Items.OVAL_STONE, 80 },   { Items.PROTECTOR, 80 },    { Items.QUICK_CLAW, 80 },   { Items.RAZOR_CLAW, 80 },
					{ Items.SAFETY_GOGGLES, 80 },   { Items.SHINY_STONE, 80 },  { Items.STICKY_BARB, 80 },  { Items.WEAKNESS_POLICY, 80 },
			//70 =>
					{ Items.BURN_DRIVE, 70 },       { Items.CHILL_DRIVE, 70 },  { Items.DOUSE_DRIVE, 70 },  { Items.DRAGON_FANG, 70 },  { Items.POISON_BARB, 70 },
					{ Items.POWER_ANKLET, 70 }, { Items.POWER_BAND, 70 },   { Items.POWER_BELT, 70 },   { Items.POWER_BRACER, 70 }, { Items.POWER_LENS, 70 },
					{ Items.POWER_WEIGHT, 70 }, { Items.SHOCK_DRIVE, 70 },
			//60 =>
					{ Items.ADAMANT_ORB, 60 },  { Items.DAMP_ROCK, 60 },    { Items.GRISEOUS_ORB, 60 }, { Items.HEAT_ROCK, 60 },    { Items.LUSTROUS_ORB, 60 },
					{ Items.MACHO_BRACE, 60 },  { Items.ROCKY_HELMET, 60 }, { Items.STICK, 60 },
			//50 =>
					{ Items.DUBIOUS_DISC, 50 }, { Items.SHARP_BEAK, 50 },
			//40 =>
					{ Items.EVIOLITE, 40 }, { Items.ICY_ROCK, 40 }, { Items.LUCKY_PUNCH, 40 },
			//30 =>
					{ Items.ABILITY_CAPSULE, 30 },  { Items.ABILITY_URGE, 30 }, { Items.ABSORB_BULB, 30 },  { Items.AMAZE_MULCH, 30 },  { Items.AMULET_COIN, 30 },
					{ Items.ANTIDOTE, 30 }, { Items.AWAKENING, 30 },    { Items.BALM_MUSHROOM, 30 },    { Items.BERRY_JUICE, 30 },  { Items.BIG_MUSHROOM, 30 },
					{ Items.BIG_NUGGET, 30 },   { Items.BIG_PEARL, 30 },    { Items.BINDING_BAND, 30 }, { Items.BLACK_BELT, 30 },   { Items.BLACK_FLUTE, 30 },
					{ Items.BLACK_GLASSES, 30 },    { Items.BLACK_SLUDGE, 30 }, { Items.BLUE_FLUTE, 30 },   { Items.BLUE_SHARD, 30 },   { Items.BOOST_MULCH, 30 },
					{ Items.BURN_HEAL, 30 },    { Items.CALCIUM, 30 },  { Items.CARBOS, 30 },   { Items.CASTELIACONE, 30 }, { Items.CELL_BATTERY, 30 },
					{ Items.CHARCOAL, 30 }, { Items.CLEANSE_TAG, 30 },  { Items.COMET_SHARD, 30 },  { Items.DAMP_MULCH, 30 },   { Items.DEEP_SEA_SCALE, 30 },
					{ Items.DIRE_HIT, 30 }, { Items.DIRE_HIT_2, 30 },   { Items.DIRE_HIT_3, 30 },   { Items.DRAGON_SCALE, 30 }, { Items.EJECT_BUTTON, 30 },
					{ Items.ELIXIR, 30 },   { Items.ENERGY_POWDER, 30 },    { Items.ENERGY_ROOT, 30 },  { Items.ESCAPE_ROPE, 30 },  { Items.ETHER, 30 },
					{ Items.EVERSTONE, 30 },    { Items.EXP_SHARE, 30 },    { Items.FIRE_STONE, 30 },   { Items.FLAME_ORB, 30 },    { Items.FLOAT_STONE, 30 },
					{ Items.FLUFFY_TAIL, 30 },  { Items.FRESH_WATER, 30 },  { Items.FULL_HEAL, 30 },    { Items.FULL_RESTORE, 30 }, { Items.GOOEY_MULCH, 30 },
					{ Items.GREEN_SHARD, 30 },  { Items.GROWTH_MULCH, 30 }, { Items.GUARD_SPEC, 30 },   { Items.HEAL_POWDER, 30 },  { Items.HEART_SCALE, 30 },
					{ Items.HONEY, 30 },    { Items.HP_UP, 30 },    { Items.HYPER_POTION, 30 }, { Items.ICE_HEAL, 30 }, { Items.IRON, 30 },
					{ Items.ITEM_DROP, 30 },    { Items.ITEM_URGE, 30 },    { Items.KINGS_ROCK, 30 },   { Items.LAVA_COOKIE, 30 },  { Items.LEAF_STONE, 30 },
					{ Items.LEMONADE, 30 }, { Items.LIFE_ORB, 30 }, { Items.LIGHT_BALL, 30 },   { Items.LIGHT_CLAY, 30 },   { Items.LUCKY_EGG, 30 },
					{ Items.LUMINOUS_MOSS, 30 },    { Items.LUMIOSE_GALETTE, 30 },  { Items.MAGNET, 30 },   { Items.MAX_ELIXIR, 30 },   { Items.MAX_ETHER, 30 },
					{ Items.MAX_POTION, 30 },   { Items.MAX_REPEL, 30 },    { Items.MAX_REVIVE, 30 },   { Items.METAL_COAT, 30 },   { Items.METRONOME, 30 },
					{ Items.MIRACLE_SEED, 30 }, { Items.MOOMOO_MILK, 30 },  { Items.MOON_STONE, 30 },   { Items.MYSTIC_WATER, 30 }, { Items.NEVER_MELT_ICE, 30 },
					{ Items.NUGGET, 30 },   { Items.OLD_GATEAU, 30 },   { Items.PARALYZE_HEAL, 30 },    { Items.PARALYZE_HEAL, 30 },    { Items.PASS_ORB, 30 },
					{ Items.PEARL, 30 },    { Items.PEARL_STRING, 30 }, { Items.POKE_DOLL, 30 },    { Items.POKE_TOY, 30 }, { Items.POTION, 30 },
					{ Items.PP_MAX, 30 },   { Items.PP_UP, 30 },    { Items.PRISM_SCALE, 30 },  { Items.PROTEIN, 30 },  { Items.RAGE_CANDY_BAR, 30 },
					{ Items.RARE_CANDY, 30 },   { Items.RAZOR_FANG, 30 },   { Items.RED_FLUTE, 30 },    { Items.RED_SHARD, 30 },    { Items.RELIC_BAND, 30 },
					{ Items.RELIC_COPPER, 30 }, { Items.RELIC_CROWN, 30 },  { Items.RELIC_GOLD, 30 },   { Items.RELIC_SILVER, 30 }, { Items.RELIC_STATUE, 30 },
					{ Items.RELIC_VASE, 30 },   { Items.REPEL, 30 },    { Items.RESET_URGE, 30 },   { Items.REVIVAL_HERB, 30 }, { Items.REVIVE, 30 },
					{ Items.RICH_MULCH, 30 },   { Items.SACHET, 30 },   { Items.SACRED_ASH, 30 },   { Items.SCOPE_LENS, 30 },   { Items.SHALOUR_SABLE, 30 },
					{ Items.SHELL_BELL, 30 },   { Items.SHOAL_SALT, 30 },   { Items.SHOAL_SHELL, 30 },  { Items.SMOKE_BALL, 30 },   { Items.SNOWBALL, 30 },
					{ Items.SODA_POP, 30 }, { Items.SOUL_DEW, 30 }, { Items.SPELL_TAG, 30 },    { Items.STABLE_MULCH, 30 }, { Items.STARDUST, 30 },
					{ Items.STAR_PIECE, 30 },   { Items.SUN_STONE, 30 },    { Items.SUPER_POTION, 30 }, { Items.SUPER_REPEL, 30 },  { Items.SURPRISE_MULCH, 30 },
					{ Items.SWEET_HEART, 30 },  { Items.THUNDER_STONE, 30 },    { Items.TINY_MUSHROOM, 30 },    { Items.TOXIC_ORB, 30 },    { Items.TWISTED_SPOON, 30 },
					{ Items.UP_GRADE, 30 }, { Items.WATER_STONE, 30 },  { Items.WHIPPED_DREAM, 30 },    { Items.WHITE_FLUTE, 30 },  { Items.X_ACCURACY, 30 },
					{ Items.X_ACCURACY_2, 30 }, { Items.X_ACCURACY_3, 30 }, { Items.X_ACCURACY_6, 30 }, { Items.X_ATTACK, 30 }, { Items.X_ATTACK_2, 30 },
					{ Items.X_ATTACK_3, 30 },   { Items.X_ATTACK_6, 30 },   { Items.X_DEFENSE, 30 },    { Items.X_DEFENSE_2, 30 },  { Items.X_DEFENSE_3, 30 },
					{ Items.X_DEFENSE_6, 30 },  { Items.X_SP_DEF, 30 }, { Items.X_SP_DEF_2, 30 },   { Items.X_SP_DEF_3, 30 },   { Items.X_SP_DEF_6, 30 },
					{ Items.X_SP_ATK, 30 },     { Items.X_SP_ATK_2, 30 },   { Items.X_SP_ATK_3, 30 },   { Items.X_SP_ATK_6, 30 },   { Items.X_SPEED, 30 },
					{ Items.X_SPEED_2, 30 },    { Items.X_SPEED_3, 30 },    { Items.X_SPEED_6, 30 },    { Items.YELLOW_FLUTE, 30 }, { Items.YELLOW_SHARD, 30 }, { Items.ZINC, 30 },
					//{ Items.X_SPECIAL, 30 },	{ Items.X_SPECIAL2, 30 },	{ Items.X_SPECIAL_3, 30 },	{ Items.X_SPECIAL_6, 30 },	//ToDo: Is X-Special a thing?
			//20 =>
					{ Items.CLEVER_WING, 20 },  { Items.GENIUS_WING, 20 },  { Items.HEALTH_WING, 20 },  { Items.MUSCLE_WING, 20 },  { Items.PRETTY_WING, 20 },
					{ Items.RESIST_WING, 20 },  { Items.SWIFT_WING, 20 },
			//10 =>
					{ Items.AIR_BALLOON, 10 },  { Items.BIG_ROOT, 10 }, { Items.BLUE_SCARF, 10 },   { Items.BRIGHT_POWDER, 10 },    { Items.CHOICE_BAND, 10 },
					{ Items.CHOICE_SCARF, 10 }, { Items.CHOICE_SPECS, 10 }, { Items.DESTINY_KNOT, 10 }, { Items.EXPERT_BELT, 10 },  { Items.FOCUS_BAND, 10 },
					{ Items.FOCUS_SASH, 10 },   { Items.FULL_INCENSE, 10 }, { Items.GREEN_SCARF, 10 },  { Items.LAGGING_TAIL, 10 }, { Items.LAX_INCENSE, 10 },
					{ Items.LEFTOVERS, 10 },    { Items.LUCK_INCENSE, 10 }, { Items.MENTAL_HERB, 10 },  { Items.METAL_POWDER, 10 }, { Items.MUSCLE_BAND, 10 },
					{ Items.ODD_INCENSE, 10 },  { Items.PINK_SCARF, 10 },   { Items.POWER_HERB, 10 },   { Items.PURE_INCENSE, 10 }, { Items.QUICK_POWDER, 10 },
					{ Items.REAPER_CLOTH, 10 }, { Items.RED_CARD, 10 }, { Items.RED_SCARF, 10 },    { Items.RING_TARGET, 10 },  { Items.ROCK_INCENSE, 10 },
					{ Items.ROSE_INCENSE, 10 }, { Items.SEA_INCENSE, 10 },  { Items.SHED_SHELL, 10 },   { Items.SILK_SCARF, 10 },   { Items.SILVER_POWDER, 10 },
					{ Items.SMOOTH_ROCK, 10 },  { Items.SOFT_SAND, 10 },    { Items.SOOTHE_BELL, 10 },  { Items.WAVE_INCENSE, 10 }, { Items.WHITE_HERB, 10 },
					{ Items.WIDE_LENS, 10 },    { Items.WISE_GLASSES, 10 }, { Items.YELLOW_SCARF, 10 }, { Items.ZOOM_LENS, 10 }
				};
			}
		}

		public override bool MoveFailed(IBattler attacker, IBattler opponent)
		{
			if (attacker.Item == 0 ||
				this.battle.IsUnlosableItem(attacker, attacker.Item) ||
				Game.GameData is IItemCheck i0 && i0.IsPokeBall(attacker.Item) ||
				this.battle.field.MagicRoom > 0 ||
				attacker.hasWorkingAbility(Abilities.KLUTZ) ||
				attacker.effects.Embargo > 0) return true;
			foreach (Items i in flingarray.Keys)
			{
				//if (flingarray[i] != null){
				//	foreach (var j in flingarray[i]){
						if (attacker.Item == i) return false;
				//	}
				//}
			}
			if (Game.GameData is IItemCheck i1 && i1.IsBerry(attacker.Item) &&
				!attacker.Opposing1.hasWorkingAbility(Abilities.UNNERVE) &&
				!attacker.Opposing2.hasWorkingAbility(Abilities.UNNERVE)) return false;
			return true;
		}

		public override int BaseDamage(int basedmg, IBattler attacker, IBattler opponent)
		{
			if (Game.GameData is IItemCheck i0 && i0.IsBerry(attacker.Item)) return 10;
			if (Game.GameData is IItemCheck i1 && i1.IsMegaStone(attacker.Item)) return 80;
			foreach (Items i in flingarray.Keys)
			{
				//if (flingarray[i] != null){
				//	foreach (var j in flingarray[i]){
						if (attacker.Item == i) return flingarray[i]; //Kernal.ItemData[i].FlingPower.Value;
				//	}
				//}
			}
			return 1;
		}

		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (attacker.Item == 0)
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(0);
				yield break;
			}
			attacker.effects.Unburden = true;

			_host.StartCoroutine(battle.Display(Game._INTL("{1} flung its {2}!", attacker.ToString(), Kernal.ItemData[attacker.Item].Name)));
			int ret = -1; _host.StartCoroutine(base.GetEffect(attacker, opponent, hitnum, alltargets, showanimation, result:value=>ret=value)); result(ret);
			if (opponent.damagestate.CalcDamage > 0 && !opponent.damagestate.Substitute &&
			   (attacker.hasMoldBreaker() || !opponent.hasWorkingAbility(Abilities.SHIELD_DUST)))
			{
				if ((attacker as Combat.Pokemon).hasWorkingBerry())
				{
					opponent.ActivateBerryEffect(attacker.Item, false);

				}
				else if (attacker.hasWorkingItem(Items.FLAME_ORB))
				{
					if (opponent is IBattlerEffect b && b.CanBurn(attacker, false, this))
					{
						b.Burn(attacker);
					}
				}
				else if (attacker.hasWorkingItem(Items.KINGS_ROCK) ||
					 attacker.hasWorkingItem(Items.RAZOR_FANG))
				{
					if (opponent is IBattlerEffectIE o) o.Flinch(attacker);
				}
				else if (attacker.hasWorkingItem(Items.LIGHT_BALL))
				{
					if (opponent is IBattlerEffect b && b.CanParalyze(attacker, false, this))
					{
						b.Paralyze(attacker);
					}
				}
				else if (attacker.hasWorkingItem(Items.MENTAL_HERB))
				{
					if (opponent.effects.Attract >= 0)
					{
						if (opponent is IBattlerEffectIE o) o.CureAttract();
						_host.StartCoroutine(battle.Display(Game._INTL("{1} got over its infatuation.", opponent.ToString())));
					}
					if (opponent.effects.Taunt > 0)
					{
						opponent.effects.Taunt = 0;
						_host.StartCoroutine(battle.Display(Game._INTL("{1}'s taunt wore off!", opponent.ToString())));
					}
					if (opponent.effects.Encore > 0)
					{
						opponent.effects.Encore = 0;
						opponent.effects.EncoreMove = 0;
						opponent.effects.EncoreIndex = 0;
						_host.StartCoroutine(battle.Display(Game._INTL("{1}'s encore ended!", opponent.ToString())));
					}
					if (opponent.effects.Torment)
					{
						opponent.effects.Torment = false;

						_host.StartCoroutine(battle.Display(Game._INTL("{1}'s torment wore off!", opponent.ToString())));
					}
					if (opponent.effects.Disable > 0)
					{
						opponent.effects.Disable = 0;
						_host.StartCoroutine(battle.Display(Game._INTL("{1} is no longer disabled!", opponent.ToString())));
					}
					if (opponent.effects.HealBlock > 0)
					{
						opponent.effects.HealBlock = 0;
						_host.StartCoroutine(battle.Display(Game._INTL("{1}'s Heal Block wore off!", opponent.ToString())));
					}
				}
				else if (attacker.hasWorkingItem(Items.POISON_BARB))
				{
					if (opponent is IBattlerEffect b && b.CanPoison(attacker, false, this))
					{
						b.Poison(attacker);
					}
				}
				else if (attacker.hasWorkingItem(Items.TOXIC_ORB))
				{
					if (opponent is IBattlerEffect b && b.CanPoison(attacker, false, this))
					{
						b.Poison(attacker, null, true);
					}
				}
				else if (attacker.hasWorkingItem(Items.WHITE_HERB))
				{
					while (true)
					{
						bool reducedstats = false;
						foreach (var i in new[] { Stats.ATTACK, Stats.DEFENSE,
						Stats.SPEED, Stats.SPATK, Stats.SPDEF,
						Stats.EVASION, Stats.ACCURACY })
						{
							if (opponent.stages[(byte)i] < 0)
							{
								opponent.stages[(byte)i] = 0; reducedstats = true;
							}
						}
						if (!reducedstats) break;
						_host.StartCoroutine(battle.Display(Game._INTL("{1}'s status is returned to normal!",
							opponent.ToString(true))));
					}
				}
			}
			_host.StartCoroutine(attacker.ConsumeItem());
			result(ret);
			yield break;
		}
	}

	/// <summary>
	/// For 5 rounds, the target cannnot use its held item, its held item has no
	/// effect, and no items can be used on it. (Embargo)
	/// <summary>
	public partial class PokeBattle_Move_0F8 : PokeBattle_Move
	{
		public PokeBattle_Move_0F8() : base() { }
		//public PokeBattle_Move_0F8(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (opponent.effects.Embargo > 0)
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));

			opponent.effects.Embargo = 5;
			_host.StartCoroutine(battle.Display(Game._INTL("{1} can't use items anymore!", opponent.ToString())));
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// For 5 rounds, all held items cannot be used in any way and have no effect.
	/// Held items can still change hands, but can't be thrown. (Magic Room)
	/// <summary>
	public partial class PokeBattle_Move_0F9 : PokeBattle_Move
	{
		public PokeBattle_Move_0F9() : base() { }
		//public PokeBattle_Move_0F9(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (this.battle.field.MagicRoom > 0)
			{
				this.battle.field.MagicRoom = 0;
				_host.StartCoroutine(battle.Display(Game._INTL("The area returned to normal!")));
			}
			else
			{
				_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));

				this.battle.field.MagicRoom = 5;
				_host.StartCoroutine(battle.Display(Game._INTL("It created a bizarre area in which Pokémon's held items lose their effects!")));
			}
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// User takes recoil damage equal to 1/4 of the damage this move dealt.
	/// <summary>
	public partial class PokeBattle_Move_0FA : PokeBattle_Move
	{
		public PokeBattle_Move_0FA() : base() { }
		//public PokeBattle_Move_0FA(Battle battle, Attack.Move move) : base(battle, move) { }
		public override bool isRecoilMove()
		{
			return true;
		}

		public override void EffectAfterHit(IBattler attacker, IBattler opponent, IEffectsMove turneffects) { this.EffectAfterHit((IBattlerIE)attacker, (IBattlerIE)opponent, turneffects); }
		public override IEnumerator EffectAfterHit(IBattlerIE attacker, IBattlerIE opponent, IEffectsMove turneffects)
		{
			if (!attacker.isFainted() && turneffects.TotalDamage > 0)
			{
				if (!attacker.hasWorkingAbility(Abilities.ROCK_HEAD) &&
				   !attacker.hasWorkingAbility(Abilities.MAGIC_GUARD))
				{
					attacker.ReduceHP((int)Math.Round(turneffects.TotalDamage / 4.0f));
					_host.StartCoroutine(battle.Display(Game._INTL("{1} is damaged by recoil!", attacker.ToString())));
				}
			}
			yield break;
		}
	}

	/// <summary>
	/// User takes recoil damage equal to 1/3 of the damage this move dealt.
	/// <summary>
	public partial class PokeBattle_Move_0FB : PokeBattle_Move
	{
		public PokeBattle_Move_0FB() : base() { }
		//public PokeBattle_Move_0FB(Battle battle, Attack.Move move) : base(battle, move) { }
		public override bool isRecoilMove()
		{
			return true;
		}

		public override void EffectAfterHit(IBattler attacker, IBattler opponent, IEffectsMove turneffects) { this.EffectAfterHit((IBattlerIE)attacker, (IBattlerIE)opponent, turneffects); }
		public override IEnumerator EffectAfterHit(IBattlerIE attacker, IBattlerIE opponent, IEffectsMove turneffects)
		{
			if (!attacker.isFainted() && turneffects.TotalDamage > 0)
			{
				if (!attacker.hasWorkingAbility(Abilities.ROCK_HEAD) &&
				   !attacker.hasWorkingAbility(Abilities.MAGIC_GUARD))
				{
					attacker.ReduceHP((int)Math.Round(turneffects.TotalDamage / 3.0f));
					_host.StartCoroutine(battle.Display(Game._INTL("{1} is damaged by recoil!", attacker.ToString())));
				}
			}
			yield break;
		}
	}

	/// <summary>
	/// User takes recoil damage equal to 1/2 of the damage this move dealt.
	/// (Head Smash)
	/// <summary>
	public partial class PokeBattle_Move_0FC : PokeBattle_Move
	{
		public PokeBattle_Move_0FC() : base() { }
		//public PokeBattle_Move_0FC(Battle battle, Attack.Move move) : base(battle, move) { }
		public override bool isRecoilMove()
		{
			return true;
		}

		public override void EffectAfterHit(IBattler attacker, IBattler opponent, IEffectsMove turneffects) { this.EffectAfterHit((IBattlerIE)attacker, (IBattlerIE)opponent, turneffects); }
		public override IEnumerator EffectAfterHit(IBattlerIE attacker, IBattlerIE opponent, IEffectsMove turneffects)
		{
			if (!attacker.isFainted() && turneffects.TotalDamage > 0)
			{
				if (!attacker.hasWorkingAbility(Abilities.ROCK_HEAD) &&
				   !attacker.hasWorkingAbility(Abilities.MAGIC_GUARD))
				{
					attacker.ReduceHP((int)Math.Round(turneffects.TotalDamage / 2.0f));
					_host.StartCoroutine(battle.Display(Game._INTL("{1} is damaged by recoil!", attacker.ToString())));
				}
			}
			yield break;
		}
	}

	/// <summary>
	/// User takes recoil damage equal to 1/3 of the damage this move dealt.
	/// May paralyze the target. (Volt Tackle)
	/// <summary>
	public partial class PokeBattle_Move_0FD : PokeBattle_Move
	{
		public PokeBattle_Move_0FD() : base() { }
		//public PokeBattle_Move_0FD(Battle battle, Attack.Move move) : base(battle, move) { }
		public override bool isRecoilMove()
		{
			return true;
		}

		public override void EffectAfterHit(IBattler attacker, IBattler opponent, IEffectsMove turneffects) { this.EffectAfterHit((IBattlerIE)attacker, (IBattlerIE)opponent, turneffects); }
		public override IEnumerator EffectAfterHit(IBattlerIE attacker, IBattlerIE opponent, IEffectsMove turneffects)
		{
			if (!attacker.isFainted() && turneffects.TotalDamage > 0)
			{
				if (!attacker.hasWorkingAbility(Abilities.ROCK_HEAD) &&
				   !attacker.hasWorkingAbility(Abilities.MAGIC_GUARD))
				{
					attacker.ReduceHP((int)Math.Round(turneffects.TotalDamage / 3.0f));
					_host.StartCoroutine(battle.Display(Game._INTL("{1} is damaged by recoil!", attacker.ToString())));
				}
			}
			yield break;
		}

		public override void AdditionalEffect(IBattler attacker, IBattler opponent)
		{
			if (opponent.damagestate.Substitute) return;
			if (opponent is IBattlerEffect b && b.CanParalyze(attacker, false, this))
			{
				b.Paralyze(attacker);
			}
		}
	}

	/// <summary>
	/// User takes recoil damage equal to 1/3 of the damage this move dealt.
	/// May burn the target. (Flare Blitz)
	/// <summary>
	public partial class PokeBattle_Move_0FE : PokeBattle_Move
	{
		public PokeBattle_Move_0FE() : base() { }
		//public PokeBattle_Move_0FE(Battle battle, Attack.Move move) : base(battle, move) { }
		public override bool isRecoilMove()
		{
			return true;
		}

		public override void EffectAfterHit(IBattler attacker, IBattler opponent, IEffectsMove turneffects) { this.EffectAfterHit((IBattlerIE)attacker, (IBattlerIE)opponent, turneffects); }
		public override IEnumerator EffectAfterHit(IBattlerIE attacker, IBattlerIE opponent, IEffectsMove turneffects)
		{
			if (!attacker.isFainted() && turneffects.TotalDamage > 0)
			{
				if (!attacker.hasWorkingAbility(Abilities.ROCK_HEAD) &&
				   !attacker.hasWorkingAbility(Abilities.MAGIC_GUARD))
				{
					attacker.ReduceHP((int)Math.Round(turneffects.TotalDamage / 3.0f));
					_host.StartCoroutine(battle.Display(Game._INTL("{1} is damaged by recoil!", attacker.ToString())));
				}
			}
			yield break;
		}

		public override void AdditionalEffect(IBattler attacker, IBattler opponent)
		{
			if (opponent.damagestate.Substitute) return;
			if (opponent is IBattlerEffect b && b.CanBurn(attacker, false, this))
			{
				b.Burn(attacker);
			}
		}
	}

	/// <summary>
	/// Starts sunny weather. (Sunny Day)
	/// <summary>
	public partial class PokeBattle_Move_0FF : PokeBattle_Move
	{
		public PokeBattle_Move_0FF() : base() { }
		//public PokeBattle_Move_0FF(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			switch (this.battle.Weather)
			{
				case Weather.HEAVYRAIN:
					_host.StartCoroutine(battle.Display(Game._INTL("There is no relief from this heavy rain!")));
					result(-1);
					yield break;
				case Weather.HARSHSUN:

					_host.StartCoroutine(battle.Display(Game._INTL("The extremely harsh sunlight was not lessened at all!")));
					result(-1);
					yield break;
				case Weather.STRONGWINDS:

					_host.StartCoroutine(battle.Display(Game._INTL("The mysterious air current blows on regardless!")));
					result(-1);
					yield break;
				case Weather.SUNNYDAY:

					_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
					result(-1);
					yield break;
			}
			_host.StartCoroutine(ShowAnimation(this.id, attacker, null, hitnum, alltargets, showanimation));

			this.battle.weather = Weather.SUNNYDAY;
			this.battle.weatherduration = 5;
			if (attacker.hasWorkingItem(Items.HEAT_ROCK)) this.battle.weatherduration = 8;

			_host.StartCoroutine(this.battle.CommonAnimation("Sunny", null, null));
			_host.StartCoroutine(battle.Display(Game._INTL("The sunlight turned harsh!")));
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// Starts rainy weather. (Rain Dance)
	/// <summary>
	public partial class PokeBattle_Move_100 : PokeBattle_Move
	{
		public PokeBattle_Move_100() : base() { }
		//public PokeBattle_Move_100(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			switch (this.battle.weather)
			{
				case Weather.HEAVYRAIN:
					_host.StartCoroutine(battle.Display(Game._INTL("There is no relief from this heavy rain!")));
					result(-1);
					yield break;
				case Weather.HARSHSUN:

					_host.StartCoroutine(battle.Display(Game._INTL("The extremely harsh sunlight was not lessened at all!")));
					result(-1);
					yield break;
				case Weather.STRONGWINDS:

					_host.StartCoroutine(battle.Display(Game._INTL("The mysterious air current blows on regardless!")));
					result(-1);
					yield break;
				case Weather.RAINDANCE:

					_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
					result(-1);
					yield break;
				default: break;
			}
			_host.StartCoroutine(ShowAnimation(this.id, attacker, null, hitnum, alltargets, showanimation));

			this.battle.weather = Weather.RAINDANCE;
			this.battle.weatherduration = 5;
			if (attacker.hasWorkingItem(Items.DAMP_ROCK)) this.battle.weatherduration = 8;

			_host.StartCoroutine(this.battle.CommonAnimation("Rain", null, null));
			_host.StartCoroutine(battle.Display(Game._INTL("It started to rain!")));
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// Starts sandstorm weather. (Sandstorm)
	/// <summary>
	public partial class PokeBattle_Move_101 : PokeBattle_Move
	{
		public PokeBattle_Move_101() : base() { }
		//public PokeBattle_Move_101(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			switch (this.battle.Weather)
			{
				case Weather.HEAVYRAIN:
					_host.StartCoroutine(battle.Display(Game._INTL("There is no relief from this heavy rain!")));
					result(-1);
					yield break;
				case Weather.HARSHSUN:

					_host.StartCoroutine(battle.Display(Game._INTL("The extremely harsh sunlight was not lessened at all!")));
					result(-1);
					yield break;
				case Weather.STRONGWINDS:

					_host.StartCoroutine(battle.Display(Game._INTL("The mysterious air current blows on regardless!")));
					result(-1);
					yield break;
				case Weather.SANDSTORM:

					_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
					result(-1);
					yield break;
				default: break;
			}
			_host.StartCoroutine(ShowAnimation(this.id, attacker, null, hitnum, alltargets, showanimation));

			this.battle.weather = Weather.SANDSTORM;
			this.battle.weatherduration = 5;
			if (attacker.hasWorkingItem(Items.SMOOTH_ROCK)) this.battle.weatherduration = 8;

			_host.StartCoroutine(this.battle.CommonAnimation("Sandstorm", null, null));
			_host.StartCoroutine(battle.Display(Game._INTL("A sandstorm brewed!")));
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// Starts hail weather. (Hail)
	/// <summary>
	public partial class PokeBattle_Move_102 : PokeBattle_Move
	{
		public PokeBattle_Move_102() : base() { }
		//public PokeBattle_Move_102(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			switch (this.battle.weather)
			{
				case Weather.HEAVYRAIN:
					_host.StartCoroutine(battle.Display(Game._INTL("There is no relief from this heavy rain!")));
					result(-1);
					yield break;
				case Weather.HARSHSUN:

					_host.StartCoroutine(battle.Display(Game._INTL("The extremely harsh sunlight was not lessened at all!")));
					result(-1);
					yield break;
				case Weather.STRONGWINDS:

					_host.StartCoroutine(battle.Display(Game._INTL("The mysterious air current blows on regardless!")));
					result(-1);
					yield break;
				case Weather.HAIL:

					_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
					result(-1);
					yield break;
				default: break;
			}
			_host.StartCoroutine(ShowAnimation(this.id, attacker, null, hitnum, alltargets, showanimation));

			this.battle.weather = Weather.HAIL;
			this.battle.weatherduration = 5;
			if (attacker.hasWorkingItem(Items.ICY_ROCK)) this.battle.weatherduration = 8;

			_host.StartCoroutine(this.battle.CommonAnimation("Hail", null, null));
			_host.StartCoroutine(battle.Display(Game._INTL("It started to hail!")));
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// Entry hazard. Lays spikes on the opposing side (max. 3 layers). (Spikes)
	/// <summary>
	public partial class PokeBattle_Move_103 : PokeBattle_Move
	{
		public PokeBattle_Move_103() : base() { }
		//public PokeBattle_Move_103(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (attacker.OpposingSide.Spikes >= 3)
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			_host.StartCoroutine(ShowAnimation(this.id, attacker, null, hitnum, alltargets, showanimation));

			attacker.OpposingSide.Spikes += 1;
			if (!this.battle.IsOpposing(attacker.Index))
			{
				_host.StartCoroutine(battle.Display(Game._INTL("Spikes were scattered all around the opposing team's feet!")));
			}
			else
			{
				_host.StartCoroutine(battle.Display(Game._INTL("Spikes were scattered all around your team's feet!")));
			}
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// Entry hazard. Lays poison spikes on the opposing side (max. 2 layers).
	/// (Toxic Spikes)
	/// <summary>
	public partial class PokeBattle_Move_104 : PokeBattle_Move
	{
		public PokeBattle_Move_104() : base() { }
		//public PokeBattle_Move_104(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (attacker.OpposingSide.ToxicSpikes >= 2)
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			_host.StartCoroutine(ShowAnimation(this.id, attacker, null, hitnum, alltargets, showanimation));

			attacker.OpposingSide.ToxicSpikes += 1;
			if (!this.battle.IsOpposing(attacker.Index))
			{
				_host.StartCoroutine(battle.Display(Game._INTL("Poison spikes were scattered all around the opposing team's feet!")));
			}
			else
			{
				_host.StartCoroutine(battle.Display(Game._INTL("Poison spikes were scattered all around your team's feet!")));
			}
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// Entry hazard. Lays stealth rocks on the opposing side. (Stealth Rock)
	/// <summary>
	public partial class PokeBattle_Move_105 : PokeBattle_Move
	{
		public PokeBattle_Move_105() : base() { }
		//public PokeBattle_Move_105(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (attacker.OpposingSide.StealthRock)
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			_host.StartCoroutine(ShowAnimation(this.id, attacker, null, hitnum, alltargets, showanimation));

			attacker.OpposingSide.StealthRock = true;
			if (!this.battle.IsOpposing(attacker.Index))
			{
				_host.StartCoroutine(battle.Display(Game._INTL("Pointed stones float in the air around the opposing team!")));
			}
			else
			{
				_host.StartCoroutine(battle.Display(Game._INTL("Pointed stones float in the air around your team!")));
			}
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// Forces ally's Pledge move to be used next, if it hasn't already. (Grass Pledge)
	/// Combo's with ally's Pledge move if it was just used. Power is doubled, and
	/// causes either a sea of fire or a swamp on the opposing side.
	/// <summary>
	public partial class PokeBattle_Move_106 : PokeBattle_Move
	{
		public PokeBattle_Move_106() : base() { }
		//public PokeBattle_Move_106(Battle battle, Attack.Move move) : base(battle, move) { }
		public override bool OnStartUse(IBattler attacker)
		{
			this.doubledamage = false; this.overridetype = false;
			if (attacker.effects.FirstPledge == Attack.Effects.x146 ||		// Fire Pledge
				attacker.effects.FirstPledge == Attack.Effects.x145)		// Water Pledge
			{
				_host.StartCoroutine(battle.Display(Game._INTL("The two moves have become one! It's a combined move!")));
				this.doubledamage = true;
				if (attacker.effects.FirstPledge == Attack.Effects.x146)	// Fire Pledge
				{
					this.overridetype = true;
				}
			}
			return true;
		}

		public override int BaseDamage(int basedmg, IBattler attacker, IBattler opponent)
		{
			if (this.doubledamage)
			{
				return basedmg * 2;
			}
			return basedmg;
		}

		public override Types ModifyType(Types type, IBattler attacker, IBattler opponent)
		{
			if (this.overridetype)
			{
				type = Types.FIRE;
			}
			return base.ModifyType(type, attacker, opponent);
		}

		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (!this.battle.doublebattle || attacker.Partner.Species == Pokemons.NONE || attacker.Partner.isFainted())
			{
				attacker.effects.FirstPledge = 0;
				int ret = -1; _host.StartCoroutine(base.GetEffect(attacker, opponent, hitnum, alltargets, showanimation, result:value=>ret=value)); result(ret);
				yield break;
			}
			// Combined move's effect
			if (attacker.effects.FirstPledge == Attack.Effects.x146)	// Fire Pledge
			{
				int ret = -1; _host.StartCoroutine(base.GetEffect(attacker, opponent, hitnum, alltargets, showanimation, result:value=>ret=value)); result(ret);
				if (opponent.damagestate.CalcDamage > 0)
				{
					attacker.OpposingSide.SeaOfFire = 4;
					if (!this.battle.IsOpposing(attacker.Index))
					{
						_host.StartCoroutine(battle.Display(Game._INTL("A sea of fire enveloped the opposing team!")));
						_host.StartCoroutine(this.battle.CommonAnimation("SeaOfFireOpp", null, null));
					}
					else
					{
						_host.StartCoroutine(battle.Display(Game._INTL("A sea of fire enveloped your team!")));
						_host.StartCoroutine(this.battle.CommonAnimation("SeaOfFire", null, null));
					}
				}

				attacker.effects.FirstPledge = 0;
				result(ret);
				yield break;
			}
			else if (attacker.effects.FirstPledge == Attack.Effects.x145)// Water Pledge
			{
				int ret = -1; _host.StartCoroutine(base.GetEffect(attacker, opponent, hitnum, alltargets, showanimation, result:value=>ret=value)); result(ret);
				if (opponent.damagestate.CalcDamage > 0)
				{
					attacker.OpposingSide.Swamp = 4;
					if (!this.battle.IsOpposing(attacker.Index))
					{
						_host.StartCoroutine(battle.Display(Game._INTL("A swamp enveloped the opposing team!")));
						_host.StartCoroutine(this.battle.CommonAnimation("SwampOpp", null, null));
					}
					else
					{
						_host.StartCoroutine(battle.Display(Game._INTL("A swamp enveloped your team!")));
						_host.StartCoroutine(this.battle.CommonAnimation("Swamp", null, null));
					}
				}

				attacker.effects.FirstPledge = 0;
				result(ret);
				yield break;
			}
			// Set up partner for a combined move
			attacker.effects.FirstPledge = 0;
			Attack.Effects partnermove = Attack.Effects.NONE; //-1;
			if ((int)this.battle.choices[attacker.Partner.Index].Action == 1)	// Chose a move
			{
				if (!attacker.Partner.hasMovedThisRound())
				{
					Moves move = this.battle.choices[attacker.Partner.Index].Move.id;
					if (move > 0)
					{
						partnermove = this.battle.choices[attacker.Partner.Index].Move.Effect;
					}

				}
			}
			if (partnermove == Attack.Effects.x146 ||		// Fire Pledge
				partnermove == Attack.Effects.x145)		// Water Pledge
			{
				_host.StartCoroutine(battle.Display(Game._INTL("{1} is waiting for {2}'s move...", attacker.ToString(), attacker.Partner.ToString(true))));
				attacker.Partner.effects.FirstPledge = this.Effect;//(Attack.Effect)
				attacker.Partner.effects.MoveNext = true;
				result(0);
				yield break;

			}
			// Use the move on its own
			int reti = -1; _host.StartCoroutine(base.GetEffect(attacker, opponent, hitnum, alltargets, showanimation, result:value=>reti=value)); result(reti);
			yield break;
		}

		public override void ShowAnimation(Moves id, IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true)
		{
			if (this.overridetype)
			{
				base.ShowAnimation(Moves.FIRE_PLEDGE, attacker, opponent, hitnum, alltargets, showanimation);
			}
			base.ShowAnimation(id, attacker, opponent, hitnum, alltargets, showanimation);
		}
	}

	/// <summary>
	/// Forces ally's Pledge move to be used next, if it hasn't already. (Fire Pledge)
	/// Combo's with ally's Pledge move if it was just used. Power is doubled, and
	/// causes either a sea of fire on the opposing side or a rainbow on the user's side.
	/// <summary>
	public partial class PokeBattle_Move_107 : PokeBattle_Move
	{
		public PokeBattle_Move_107() : base() { }
		//public PokeBattle_Move_107(Battle battle, Attack.Move move) : base(battle, move) { }
		public override bool OnStartUse(IBattler attacker)
		{
			this.doubledamage = false; this.overridetype = false;
			if (attacker.effects.FirstPledge == Attack.Effects.x147 ||		// Grass Pledge
				attacker.effects.FirstPledge == Attack.Effects.x145)		// Water Pledge
			{
				_host.StartCoroutine(battle.Display(Game._INTL("The two moves have become one! It's a combined move!")));
				this.doubledamage = true;
				if (attacker.effects.FirstPledge == Attack.Effects.x145)	// Water Pledge
				{
					this.overridetype = true;
				}
			}
			return true;
		}

		public override int BaseDamage(int basedmg, IBattler attacker, IBattler opponent)
		{
			if (this.doubledamage)
			{
				return basedmg * 2;
			}
			return basedmg;
		}

		public override Types ModifyType(Types type, IBattler attacker, IBattler opponent)
		{
			if (this.overridetype)
			{
				type = Types.WATER;

			}
			return base.ModifyType(type, attacker, opponent);
		}

		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (!this.battle.doublebattle || attacker.Partner.Species == Pokemons.NONE || attacker.Partner.isFainted())
			{
				attacker.effects.FirstPledge = 0;
				int ret = -1; _host.StartCoroutine(base.GetEffect(attacker, opponent, hitnum, alltargets, showanimation, result:value=>ret=value)); result(ret);
				yield break;
			}
			// Combined move's effect
			if (attacker.effects.FirstPledge == Attack.Effects.x147)	// Grass Pledge
			{
				int ret = -1; _host.StartCoroutine(base.GetEffect(attacker, opponent, hitnum, alltargets, showanimation, result:value=>ret=value)); result(ret);
				if (opponent.damagestate.CalcDamage > 0)
				{

					attacker.OpposingSide.SeaOfFire = 4;
					if (!this.battle.IsOpposing(attacker.Index))
					{
						_host.StartCoroutine(battle.Display(Game._INTL("A sea of fire enveloped the opposing team!")));
						_host.StartCoroutine(this.battle.CommonAnimation("SeaOfFireOpp", null, null));
					}
					else
					{
						_host.StartCoroutine(battle.Display(Game._INTL("A sea of fire enveloped your team!")));
						_host.StartCoroutine(this.battle.CommonAnimation("SeaOfFire", null, null));
					}
				}

				attacker.effects.FirstPledge = 0;
				result(ret);
				yield break;
			}
			else if (attacker.effects.FirstPledge == Attack.Effects.x145)	// Water Pledge
			{
				int ret = -1; _host.StartCoroutine(base.GetEffect(attacker, opponent, hitnum, alltargets, showanimation, result:value=>ret=value)); result(ret);
				if (opponent.damagestate.CalcDamage > 0)
				{
					attacker.OwnSide.Rainbow = 4;
					if (!this.battle.IsOpposing(attacker.Index))
					{
						_host.StartCoroutine(battle.Display(Game._INTL("A rainbow appeared in the sky on your team's side!")));
						_host.StartCoroutine(this.battle.CommonAnimation("Rainbow", null, null));
					}
					else
					{
						_host.StartCoroutine(battle.Display(Game._INTL("A rainbow appeared in the sky on the opposing team's side!")));
						_host.StartCoroutine(this.battle.CommonAnimation("RainbowOpp", null, null));
					}
				}

				attacker.effects.FirstPledge = 0;
				result(ret);
				yield break;
			}
			// Set up partner for a combined move
			attacker.effects.FirstPledge = 0;
			Attack.Effects partnermove = Attack.Effects.NONE; //-1;
			if ((int)this.battle.choices[attacker.Partner.Index].Action == 1)	// Chose a move
			{
				if (!attacker.Partner.hasMovedThisRound())
				{
					Moves move = this.battle.choices[attacker.Partner.Index].Move.id;
					if (move > 0)	//move &&
					{
						partnermove = this.battle.choices[attacker.Partner.Index].Move.Effect;
					}

				}
			}
			if (partnermove == Attack.Effects.x147 ||		// Grass Pledge
				partnermove == Attack.Effects.x145)		// Water Pledge
			{
				_host.StartCoroutine(battle.Display(Game._INTL("{1} is waiting for {2}'s move...", attacker.ToString(), attacker.Partner.ToString(true))));
				attacker.Partner.effects.FirstPledge = this.Effect;//(Attack.Effect)
				attacker.Partner.effects.MoveNext = true;
				result(0);
				yield break;

			}
			// Use the move on its own
			int reti = -1; _host.StartCoroutine(base.GetEffect(attacker, opponent, hitnum, alltargets, showanimation, result:value=>reti=value)); result(reti);
			yield break;
		}

		public override void ShowAnimation(Moves id, IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true)
		{
			if (this.overridetype)
			{
				base.ShowAnimation(Moves.WATER_PLEDGE, attacker, opponent, hitnum, alltargets, showanimation);
			}
			base.ShowAnimation(id, attacker, opponent, hitnum, alltargets, showanimation);
		}
	}

	/// <summary>
	/// Forces ally's Pledge move to be used next, if it hasn't already. (Water Pledge)
	/// Combo's with ally's Pledge move if it was just used. Power is doubled, and
	/// causes either a swamp on the opposing side or a rainbow on the user's side.
	/// <summary>
	public partial class PokeBattle_Move_108 : PokeBattle_Move
	{
		public PokeBattle_Move_108() : base() { }
		//public PokeBattle_Move_108(Battle battle, Attack.Move move) : base(battle, move) { }
		public override bool OnStartUse(IBattler attacker)
		{
			this.doubledamage = false; this.overridetype = false;
			if (attacker.effects.FirstPledge == Attack.Effects.x147 ||		// Grass Pledge
				attacker.effects.FirstPledge == Attack.Effects.x146)		// Fire Pledge
			{
				_host.StartCoroutine(battle.Display(Game._INTL("The two moves have become one! It's a combined move!")));
				this.doubledamage = true;
				if (attacker.effects.FirstPledge == Attack.Effects.x147)	// Grass Pledge
				{
					this.overridetype = true;
				}
			}
			return true;
		}

		public override int BaseDamage(int basedmg, IBattler attacker, IBattler opponent)
		{
			if (this.doubledamage)
			{
				return basedmg * 2;
			}
			return basedmg;
		}

		public override Types ModifyType(Types type, IBattler attacker, IBattler opponent)
		{
			if (this.overridetype)
			{
				type = Types.GRASS;
			}
			return base.ModifyType(type, attacker, opponent);
		}

		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (!this.battle.doublebattle || attacker.Partner.Species == Pokemons.NONE || attacker.Partner.isFainted())
			{
				attacker.effects.FirstPledge = 0;
				int ret = -1; _host.StartCoroutine(base.GetEffect(attacker, opponent, hitnum, alltargets, showanimation, result:value=>ret=value)); result(ret);
				yield break;
			}
			// Combined move's effect
			if (attacker.effects.FirstPledge == Attack.Effects.x147)	// Grass Pledge
			{
				int ret = -1; _host.StartCoroutine(base.GetEffect(attacker, opponent, hitnum, alltargets, showanimation, result:value=>ret=value)); result(ret);
				if (opponent.damagestate.CalcDamage > 0)
				{

					attacker.OpposingSide.Swamp = 4;
					if (!this.battle.IsOpposing(attacker.Index))
					{
						_host.StartCoroutine(battle.Display(Game._INTL("A swamp enveloped the opposing team!")));
						_host.StartCoroutine(this.battle.CommonAnimation("SwampOpp", null, null));
					}
					else
					{
						_host.StartCoroutine(battle.Display(Game._INTL("A swamp enveloped your team!")));
						_host.StartCoroutine(this.battle.CommonAnimation("Swamp", null, null));
					}
				}

				attacker.effects.FirstPledge = 0;
				result(ret);
				yield break;
			}
			else if (attacker.effects.FirstPledge == Attack.Effects.x146)	// Fire Pledge
			{
				int ret = -1; _host.StartCoroutine(base.GetEffect(attacker, opponent, hitnum, alltargets, showanimation, result:value=>ret=value)); result(ret);
				if (opponent.damagestate.CalcDamage > 0)
				{
					attacker.OwnSide.Rainbow = 4;
					if (!this.battle.IsOpposing(attacker.Index))
					{
						_host.StartCoroutine(battle.Display(Game._INTL("A rainbow appeared in the sky on your team's side!")));
						_host.StartCoroutine(this.battle.CommonAnimation("Rainbow", null, null));
					}
					else
					{
						_host.StartCoroutine(battle.Display(Game._INTL("A rainbow appeared in the sky on the opposing team's side!")));
						_host.StartCoroutine(this.battle.CommonAnimation("RainbowOpp", null, null));
					}
				}

				attacker.effects.FirstPledge = 0;
				result(ret);
				yield break;
			}
			// Set up partner for a combined move
			attacker.effects.FirstPledge = 0;
			Attack.Effects partnermove = Attack.Effects.NONE; //-1;
			if ((int)this.battle.choices[attacker.Partner.Index].Action == 1)	// Chose a move
			{
				if (!attacker.Partner.hasMovedThisRound())
				{
					Moves move = this.battle.choices[attacker.Partner.Index].Move.id;
					if (move > 0)	//move != null &&
					{
						partnermove = this.battle.choices[attacker.Partner.Index].Move.Effect;
					}
				}
			}
			if (partnermove == Attack.Effects.x147 ||		// Grass Pledge
				partnermove == Attack.Effects.x146)			// Fire Pledge
			{
				_host.StartCoroutine(battle.Display(Game._INTL("{1} is waiting for {2}'s move...", attacker.ToString(), attacker.Partner.ToString(true))));
				attacker.Partner.effects.FirstPledge = this.Effect;//(Attack.Effect)
				attacker.Partner.effects.MoveNext = true;
				result(0);
				yield break;
			}
			// Use the move on its own
			int reti = -1; _host.StartCoroutine(base.GetEffect(attacker, opponent, hitnum, alltargets, showanimation, result:value=>reti=value)); result(reti);
			yield break;
		}

		public override void ShowAnimation(Moves id, IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true)
		{
			if (this.overridetype)
			{
				base.ShowAnimation(Moves.GRASS_PLEDGE, attacker, opponent, hitnum, alltargets, showanimation);
			}
			base.ShowAnimation(id, attacker, opponent, hitnum, alltargets, showanimation);
		}
	}

	/// <summary>
	/// Scatters coins that the player picks up after winning the battle. (Pay Day)
	/// <summary>
	public partial class PokeBattle_Move_109 : PokeBattle_Move
	{
		public PokeBattle_Move_109() : base() { }
		//public PokeBattle_Move_109(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			int ret = -1; _host.StartCoroutine(base.GetEffect(attacker, opponent, hitnum, alltargets, showanimation, result:value=>ret=value)); result(ret);
			if (opponent.damagestate.CalcDamage > 0)
			{
				if (this.battle.OwnedByPlayer(attacker.Index))
				{
					this.battle.extramoney += 5 * attacker.Level;
					if (this.battle.extramoney > Core.MAXMONEY) this.battle.extramoney = Core.MAXMONEY;
				}

				_host.StartCoroutine(battle.Display(Game._INTL("Coins were scattered everywhere!")));
			}
			result(ret);
			yield break;
		}
	}

	/// <summary>
	/// Ends the opposing side's Light Screen and Reflect. (Brick Break)
	/// <summary>
	public partial class PokeBattle_Move_10A : PokeBattle_Move
	{
		public PokeBattle_Move_10A() : base() { }
		//public PokeBattle_Move_10A(Battle battle, Attack.Move move) : base(battle, move) { }
		public int CalcDamage(IBattler attacker, IBattler opponent)
		{
			return base.CalcDamage(attacker, opponent, Core.NOREFLECT);
		}

		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{

			int ret = -1; _host.StartCoroutine(base.GetEffect(attacker, opponent, hitnum, alltargets, showanimation, result:value=>ret=value)); result(ret);
			if (attacker.OpposingSide.Reflect > 0)
			{
				attacker.OpposingSide.Reflect = 0;
				if (!this.battle.IsOpposing(attacker.Index))
				{
					_host.StartCoroutine(battle.Display(Game._INTL("The opposing team's Reflect wore off!")));
				}
				else
				{
					_host.StartCoroutine(battle.DisplayPaused(Game._INTL("Your team's Reflect wore off!")));
				}
			}
			if (attacker.OpposingSide.LightScreen > 0)
			{
				attacker.OpposingSide.LightScreen = 0;
				if (!this.battle.IsOpposing(attacker.Index))
				{
					_host.StartCoroutine(battle.Display(Game._INTL("The opposing team's Light Screen wore off!")));
				}
				else
				{
					_host.StartCoroutine(battle.Display(Game._INTL("Your team's Light Screen wore off!")));
				}
			}
			result(ret);
			yield break;
		}

		public override void ShowAnimation(Moves id, IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true)
		{
			if (attacker.OpposingSide.Reflect > 0 ||
			   attacker.OpposingSide.LightScreen > 0)
			{
				base.ShowAnimation(id, attacker, opponent, 1, alltargets, showanimation); // Wall-breaking anim;
			}
			base.ShowAnimation(id, attacker, opponent, hitnum, alltargets, showanimation);
		}
	}

	/// <summary>
	/// If attack misses, user takes crash damage of 1/2 of max HP.
	/// (Hi Jump Kick, Jump Kick)
	/// <summary>
	public partial class PokeBattle_Move_10B : PokeBattle_Move
	{
		public PokeBattle_Move_10B() : base() { }
		//public PokeBattle_Move_10B(Battle battle, Attack.Move move) : base(battle, move) { }
		public override bool isRecoilMove()
		{
			return true;
		}

		public override bool UnusableInGravity()
		{
			return true;
		}
	}

	/// <summary>
	/// User turns 1/4 of max HP into a substitute. (Substitute)
	/// <summary>
	public partial class PokeBattle_Move_10C : PokeBattle_Move
	{
		public PokeBattle_Move_10C() : base() { }
		//public PokeBattle_Move_10C(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (attacker.effects.Substitute > 0)
			{
				_host.StartCoroutine(battle.Display(Game._INTL("{1} already has a substitute!", attacker.ToString())));
				result(-1);
				yield break;
			}
			int sublife = (int)Math.Max(Math.Floor(attacker.TotalHP / 4f), 1);
			if (attacker.HP <= sublife)
			{
				_host.StartCoroutine(battle.Display(Game._INTL("It was too weak to make a substitute!")));
				result(-1);
				yield break;
			}
			attacker.ReduceHP(sublife, false, false);

			_host.StartCoroutine(ShowAnimation(this.id, attacker, null, hitnum, alltargets, showanimation));

			attacker.effects.MultiTurn = 0;
			attacker.effects.MultiTurnAttack = 0;
			attacker.effects.Substitute = sublife;
			_host.StartCoroutine(battle.Display(Game._INTL("{1} put in a substitute!", attacker.ToString())));
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// User is not Ghost: Decreases the user's Speed, increases the user's Attack &
	/// Defense by 1 stage each.
	/// User is Ghost: User loses 1/2 of max HP, and curses the target.
	/// Cursed Pokémon lose 1/4 of their max HP at the end of each round.
	/// (Curse)
	/// <summary>
	public partial class PokeBattle_Move_10D : PokeBattle_Move
	{
		public PokeBattle_Move_10D() : base() { }
		//public PokeBattle_Move_10D(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			bool failed = false;
			if (attacker.HasType(Types.GHOST))
			{
				if (opponent.effects.Curse ||
				   opponent.OwnSide.CraftyShield)
				{
					failed = true;
				}
				else
				{
					_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));

					_host.StartCoroutine(battle.Display(Game._INTL("{1} cut its own HP and laid a curse on {2}!", attacker.ToString(), opponent.ToString(true))));
					opponent.effects.Curse = true;
					attacker.ReduceHP((int)Math.Floor(attacker.TotalHP / 2f));
				}
			}
			else
			{
				bool lowerspeed = attacker is IBattlerEffect b0 && b0.CanReduceStatStage(Stats.SPEED, attacker, false, this);
				bool raiseatk = attacker is IBattlerEffect b1 && b1.CanIncreaseStatStage(Stats.ATTACK, attacker, false, this);
				bool raisedef = attacker is IBattlerEffect b2 && b2.CanIncreaseStatStage(Stats.DEFENSE, attacker, false, this);
				if (!lowerspeed && !raiseatk && !raisedef)
				{
					failed = true;
				}
				else
				{
					_host.StartCoroutine(ShowAnimation(this.id, attacker, null, 1, alltargets, showanimation)); // Non-Ghost move animation
					if (lowerspeed)
					{
						(attacker as IBattlerEffect).ReduceStat(Stats.SPEED, 1, attacker, false, this);
					}
					bool showanim = true;
					if (raiseatk)
					{
						(attacker as IBattlerEffect).IncreaseStat(Stats.ATTACK, 1, attacker, false, this, showanim);

						showanim = false;
					}
					if (raisedef)
					{
						(attacker as IBattlerEffect).IncreaseStat(Stats.DEFENSE, 1, attacker, false, this, showanim);

						showanim = false;
					}
				}
			}
			if (failed)
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
			}
			result(failed ? -1 : 0);
			yield break;
		}
	}

	/// <summary>
	/// Target's last move used loses 4 PP. (Spite)
	/// <summary>
	public partial class PokeBattle_Move_10E : PokeBattle_Move
	{
		public PokeBattle_Move_10E() : base() { }
		//public PokeBattle_Move_10E(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			foreach (var i in opponent.moves)
			{
				if (i.id == opponent.lastMoveUsed && i.id > 0 && i.PP > 0)
				{
					_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));

					int reduction = Math.Min(4, i.PP);
					opponent.SetPP(i, (byte)(i.PP - reduction));

					_host.StartCoroutine(battle.Display(Game._INTL("It reduced the PP of {1}'s {2} by {3}!", opponent.ToString(true), Kernal.MoveData[i.id].Name, ((int)reduction).ToString())));
					result(0);
					yield break;
				}
			}

			_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
			result(-1);
			yield break;
		}
	}

	/// <summary>
	/// Target will lose 1/4 of max HP at end of each round, while asleep. (Nightmare)
	/// <summary>
	public partial class PokeBattle_Move_10F : PokeBattle_Move
	{
		public PokeBattle_Move_10F() : base() { }
		//public PokeBattle_Move_10F(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (opponent.Status != Status.SLEEP || opponent.effects.Nightmare ||
			   (opponent.effects.Substitute > 0 && !ignoresSubstitute(attacker)))
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));

			opponent.effects.Nightmare = true;
			_host.StartCoroutine(battle.Display(Game._INTL("{1} began having a nightmare!", opponent.ToString())));
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// Removes trapping moves, entry hazards and Leech Seed on user/user's side.
	/// (Rapid Spin)
	/// <summary>
	public partial class PokeBattle_Move_110 : PokeBattle_Move
	{
		public PokeBattle_Move_110() : base() { }
		//public PokeBattle_Move_110(Battle battle, Attack.Move move) : base(battle, move) { }
		public override void EffectAfterHit(IBattler attacker, IBattler opponent, IEffectsMove turneffects) { this.EffectAfterHit((IBattlerIE)attacker, (IBattlerIE)opponent, turneffects); }
		public override IEnumerator EffectAfterHit(IBattlerIE attacker, IBattlerIE opponent, IEffectsMove turneffects)
		{
			if (!attacker.isFainted() && turneffects.TotalDamage > 0)
			{
				if (attacker.effects.MultiTurn > 0)
				{
					string mtattack = Game._INTL(attacker.effects.MultiTurnAttack.ToString(TextScripts.Name));
					IBattler mtuser = this.battle.battlers[attacker.effects.MultiTurnUser];

					_host.StartCoroutine(battle.Display(Game._INTL("{1} got free of {2}'s {3}!", attacker.ToString(), mtuser.ToString(true), mtattack)));
					attacker.effects.MultiTurn = 0;
					attacker.effects.MultiTurnAttack = 0;
					attacker.effects.MultiTurnUser = -1;
				}
				if (attacker.effects.LeechSeed >= 0)
				{
					attacker.effects.LeechSeed = -1;
					_host.StartCoroutine(battle.Display(Game._INTL("{1} shed Leech Seed!", attacker.ToString())));
				}
				if (attacker.OwnSide.StealthRock)
				{
					attacker.OwnSide.StealthRock = false;

					_host.StartCoroutine(battle.Display(Game._INTL("{1} blew away stealth rocks!", attacker.ToString())));
				}
				if (attacker.OwnSide.Spikes > 0)
				{
					attacker.OwnSide.Spikes = 0;
					_host.StartCoroutine(battle.Display(Game._INTL("{1} blew away Spikes!", attacker.ToString())));
				}
				if (attacker.OwnSide.ToxicSpikes > 0)
				{
					attacker.OwnSide.ToxicSpikes = 0;
					_host.StartCoroutine(battle.Display(Game._INTL("{1} blew away poison spikes!", attacker.ToString())));
				}
				if (attacker.OwnSide.StickyWeb)
				{
					attacker.OwnSide.StickyWeb = false;

					_host.StartCoroutine(battle.Display(Game._INTL("{1} blew away sticky webs!", attacker.ToString())));
				}
			}
			yield break;
		}
	}

	/// <summary>
	/// Attacks 2 rounds in the future. (Doom Desire, Future Sight)
	/// <summary>
	public partial class PokeBattle_Move_111 : PokeBattle_Move
	{
		public PokeBattle_Move_111() : base() { }
		//public PokeBattle_Move_111(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int DisplayUseMessage(IBattler attacker)
		{
			if (this.battle.futuresight) return 0;
			return base.DisplayUseMessage(attacker);
		}

		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (opponent.effects.FutureSight > 0)
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			if (this.battle.futuresight)
			{
				// Attack hits
				int reti = -1; _host.StartCoroutine(base.GetEffect(attacker, opponent, hitnum, alltargets, showanimation, result:value=>reti=value)); result(reti);
				yield break;

			}
			/// Attack is launched
			_host.StartCoroutine(ShowAnimation(this.id, attacker, null, hitnum, alltargets, showanimation));

			opponent.effects.FutureSight = 3;
			opponent.effects.FutureSightMove = this.id;
			opponent.effects.FutureSightUser = attacker.pokemonIndex;

			opponent.effects.FutureSightUserPos = attacker.Index;
			if (id == Moves.FUTURE_SIGHT)
			{

				_host.StartCoroutine(battle.Display(Game._INTL("{1} foresaw an attack!", attacker.ToString())));
			}
			else
			{
				_host.StartCoroutine(battle.Display(Game._INTL("{1} chose Doom Desire as its destiny!", attacker.ToString())));
			}
			result(0);
			yield break;
		}

		public override void ShowAnimation(Moves id, IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true)
		{
			if (this.battle.futuresight)
			{
				base.ShowAnimation(id, attacker, opponent, 1, alltargets, showanimation); // Hit opponent anim;
			}
			base.ShowAnimation(id, attacker, opponent, hitnum, alltargets, showanimation);
		}
	}

	/// <summary>
	/// Increases the user's Defense and Special Defense by 1 stage each. Ups the
	/// user's stockpile by 1 (max. 3). (Stockpile)
	/// <summary>
	public partial class PokeBattle_Move_112 : PokeBattle_Move
	{
		public PokeBattle_Move_112() : base() { }
		//public PokeBattle_Move_112(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (attacker.effects.Stockpile >= 3)
			{
				_host.StartCoroutine(battle.Display(Game._INTL("{1} can't stockpile any more!", attacker.ToString())));
				result(-1);
				yield break;
			}
			_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));

			attacker.effects.Stockpile += 1;
			_host.StartCoroutine(battle.Display(Game._INTL("{1} stockpiled {2}!",attacker.ToString(),
				attacker.effects.Stockpile)));
			bool showanim = true;
			if (attacker is IBattlerEffect b0 && b0.CanIncreaseStatStage(Stats.DEFENSE, attacker, false, this))
			{
				b0.IncreaseStat(Stats.DEFENSE, 1, attacker, false, this, showanim);
				attacker.effects.StockpileDef += 1;
				showanim = false;
			}
			if (attacker is IBattlerEffect b1 && b1.CanIncreaseStatStage(Stats.SPDEF, attacker, false, this))
			{
				b1.IncreaseStat(Stats.SPDEF, 1, attacker, false, this, showanim);
				attacker.effects.StockpileSpDef += 1;
				showanim = false;
			}
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// Power is 100 multiplied by the user's stockpile (X). Resets the stockpile to
	/// 0. Decreases the user's Defense and Special Defense by X stages each. (Spit Up)
	/// <summary>
	public partial class PokeBattle_Move_113 : PokeBattle_Move
	{
		public PokeBattle_Move_113() : base() { }
		//public PokeBattle_Move_113(Battle battle, Attack.Move move) : base(battle, move) { }
		public override bool MoveFailed(IBattler attacker, IBattler opponent)
		{
			return attacker.effects.Stockpile == 0;
		}

		public override int BaseDamage(int basedmg, IBattler attacker, IBattler opponent)
		{
			return 100 * attacker.effects.Stockpile;
		}

		public override void EffectAfterHit(IBattler attacker, IBattler opponent, IEffectsMove turneffects) { this.EffectAfterHit((IBattlerIE)attacker, (IBattlerIE)opponent, turneffects); }
		public override IEnumerator EffectAfterHit(IBattlerIE attacker, IBattlerIE opponent, IEffectsMove turneffects)
		{
			if (!attacker.isFainted() && turneffects.TotalDamage > 0)
			{
				bool showanim = true;
				if (attacker.effects.StockpileDef > 0)
				{
					if (attacker is IBattlerEffect b && b.CanReduceStatStage(Stats.DEFENSE, attacker, false, this))
					{
						b.ReduceStat(Stats.DEFENSE, attacker.effects.StockpileDef,
						   attacker, false, this, showanim);
						showanim = false;
					}
				}
				if (attacker.effects.StockpileSpDef > 0)
				{
					if (attacker is IBattlerEffect b && b.CanReduceStatStage(Stats.SPDEF, attacker, false, this))
					{
						b.ReduceStat(Stats.SPDEF, attacker.effects.StockpileSpDef,
						   attacker, false, this, showanim);
						showanim = false;
					}
				}

				attacker.effects.Stockpile = 0;
				attacker.effects.StockpileDef = 0;
				attacker.effects.StockpileSpDef = 0;
				_host.StartCoroutine(battle.Display(Game._INTL("{1}'s stockpiled effect wore off!", attacker.ToString())));
			}
			yield break;
		}
	}

	/// <summary>
	/// Heals user depending on the user's stockpile (X). Resets the stockpile to 0.
	/// Decreases the user's Defense and Special Defense by X stages each. (Swallow)
	/// <summary>
	public partial class PokeBattle_Move_114 : PokeBattle_Move
	{
		public PokeBattle_Move_114() : base() { }
		//public PokeBattle_Move_114(Battle battle, Attack.Move move) : base(battle, move) { }
		public override bool isHealingMove()
		{
			return true;
		}

		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			int hpgain = 0;
			switch (attacker.effects.Stockpile)
			{
				case 0:
					_host.StartCoroutine(battle.Display(Game._INTL("But it failed to swallow a thing!")));
					result(-1);
					yield break;
				case 1:
					hpgain = (int)Math.Floor(attacker.TotalHP / 4f); break;
				case 2:
					hpgain = (int)Math.Floor(attacker.TotalHP / 2f); break;
				case 3:
					hpgain = attacker.TotalHP; break;
				default: break;
			}
			if (attacker.HP == attacker.TotalHP &&
			   attacker.effects.StockpileDef == 0 &&
			   attacker.effects.StockpileSpDef == 0)
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			_host.StartCoroutine(ShowAnimation(this.id, attacker, null, hitnum, alltargets, showanimation));
			int ret = -1; attacker.RecoverHP(hpgain, true, result:value=>ret=value); if (ret > 0)
			{
				_host.StartCoroutine(battle.Display(Game._INTL("{1}'s HP was restored.", attacker.ToString())));
			}
			bool showanim = true;
			if (attacker.effects.StockpileDef > 0)
			{
				if (attacker is IBattlerEffect b && b.CanReduceStatStage(Stats.DEFENSE, attacker, false, this))
				{
					b.ReduceStat(Stats.DEFENSE, attacker.effects.StockpileDef,
					   attacker, false, this, showanim);
					showanim = false;
				}
			}
			if (attacker.effects.StockpileSpDef > 0)
			{
				if (attacker is IBattlerEffect b && b.CanReduceStatStage(Stats.SPDEF, attacker, false, this))
				{
					b.ReduceStat(Stats.SPDEF, attacker.effects.StockpileSpDef,
					   attacker, false, this, showanim);
					showanim = false;
				}
			}

			attacker.effects.Stockpile = 0;
			attacker.effects.StockpileDef = 0;
			attacker.effects.StockpileSpDef = 0;
			_host.StartCoroutine(battle.Display(Game._INTL("{1}'s stockpiled effect wore off!", attacker.ToString())));
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// Fails if user was hit by a damaging move this round. (Focus Punch)
	/// <summary>
	public partial class PokeBattle_Move_115 : PokeBattle_Move
	{
		public PokeBattle_Move_115() : base() { }
		//public PokeBattle_Move_115(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int DisplayUseMessage(IBattler attacker)
		{
			if (attacker.lastHPLost > 0)
			{
				_host.StartCoroutine(battle.DisplayBrief(Game._INTL("{1} lost its focus and couldn't move!", attacker.ToString())));
				return -1;
			}
			return base.DisplayUseMessage(attacker);
		}
	}

	/// <summary>
	/// Fails if the target didn't chose a damaging move to use this round, or has
	/// already moved. (Sucker Punch)
	/// <summary>
	public partial class PokeBattle_Move_116 : PokeBattle_Move
	{
		public PokeBattle_Move_116() : base() { }
		//public PokeBattle_Move_116(Battle battle, Attack.Move move) : base(battle, move) { }
		public override bool MoveFailed(IBattler attacker, IBattler opponent)
		{
			if ((int)this.battle.choices[opponent.Index].Action != 1) return true; // Didn't choose a move
			IBattleMove oppmove = this.battle.choices[opponent.Index].Move;
			if (oppmove.id <= 0 || oppmove.IsStatus) return true;
			if (opponent.hasMovedThisRound() && oppmove.Effect != Attack.Effects.x073) return true; // Me First
			return false;
		}
	}

	/// <summary>
	/// This round, user becomes the target of attacks that have single targets.
	/// (Follow Me, Rage Powder)
	/// <summary>
	public partial class PokeBattle_Move_117 : PokeBattle_Move
	{
		public PokeBattle_Move_117() : base() { }
		//public PokeBattle_Move_117(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (!this.battle.doublebattle)
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			_host.StartCoroutine(ShowAnimation(this.id, attacker, null, hitnum, alltargets, showanimation));

			attacker.effects.FollowMe = 1;
			if (!attacker.Partner.isFainted() && attacker.Partner.effects.FollowMe > 0)
			{
				attacker.effects.FollowMe = attacker.Partner.effects.FollowMe + 1;
			}
			_host.StartCoroutine(battle.Display(Game._INTL("{1} became the center of attention!", attacker.ToString())));
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// For 5 rounds, increases gravity on the field. Pokémon cannot become airborne.
	/// (Gravity)
	/// <summary>
	public partial class PokeBattle_Move_118 : PokeBattle_Move
	{
		public PokeBattle_Move_118() : base() { }
		//public PokeBattle_Move_118(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (this.battle.field.Gravity > 0)
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));

			this.battle.field.Gravity = 5;
			for (int i = 0; i < 4; i++)
			{
				IBattler poke = this.battle.battlers[i];
				if (poke.Species == Pokemons.NONE) continue; //next
				if (Kernal.MoveData[(Moves)poke.effects.TwoTurnAttack].Effect == Attack.Effects.x09C ||	// Fly
					Kernal.MoveData[(Moves)poke.effects.TwoTurnAttack].Effect == Attack.Effects.x108 ||	// Bounce
					Kernal.MoveData[(Moves)poke.effects.TwoTurnAttack].Effect == Attack.Effects.x138)	// Sky Drop
				{
					poke.effects.TwoTurnAttack = 0;
				}
				if (poke.effects.SkyDrop)
				{
					poke.effects.SkyDrop = false;
				}
				if (poke.effects.MagnetRise > 0)
				{
					poke.effects.MagnetRise = 0;
				}
				if (poke.effects.Telekinesis > 0)
				{
					poke.effects.Telekinesis = 0;
				}
			}

			_host.StartCoroutine(battle.Display(Game._INTL("Gravity intensified!")));
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// For 5 rounds, user becomes airborne. (Magnet Rise)
	/// <summary>
	public partial class PokeBattle_Move_119 : PokeBattle_Move
	{
		public PokeBattle_Move_119() : base() { }
		//public PokeBattle_Move_119(Battle battle, Attack.Move move) : base(battle, move) { }
		public override bool UnusableInGravity()
		{
			return true;
		}

		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (attacker.effects.Ingrain ||
			   attacker.effects.SmackDown ||
			   attacker.effects.MagnetRise > 0)
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			_host.StartCoroutine(ShowAnimation(this.id, attacker, null, hitnum, alltargets, showanimation));

			attacker.effects.MagnetRise = 5;
			_host.StartCoroutine(battle.Display(Game._INTL("{1} levitated with electromagnetism!", attacker.ToString())));
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// For 3 rounds, target becomes airborne and can always be hit. (Telekinesis)
	/// <summary>
	public partial class PokeBattle_Move_11A : PokeBattle_Move
	{
		public PokeBattle_Move_11A() : base() { }
		//public PokeBattle_Move_11A(Battle battle, Attack.Move move) : base(battle, move) { }
		public override bool UnusableInGravity()
		{
			return true;
		}

		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (opponent.effects.Ingrain ||
			   opponent.effects.SmackDown ||
			   opponent.effects.Telekinesis > 0)
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));

			opponent.effects.Telekinesis = 3;
			_host.StartCoroutine(battle.Display(Game._INTL("{1} was hurled into the air!", opponent.ToString())));
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// Hits airborne semi-invulnerable targets. (Sky Uppercut)
	/// <summary>
	public partial class PokeBattle_Move_11B : PokeBattle_Move
	{
		public PokeBattle_Move_11B() : base() { }
		//public PokeBattle_Move_11B(Battle battle, Attack.Move move) : base(battle, move) { }
		// Handled in Pokemon's SuccessCheck, do not edit!
	}

	/// <summary>
	/// Grounds the target while it remains active. (Smack Down, Thousand Arrows)
	/// (Handled in Pokemon's SuccessCheck): Hits some semi-invulnerable targets.
	/// <summary>
	public partial class PokeBattle_Move_11C : PokeBattle_Move
	{
		public PokeBattle_Move_11C() : base() { }
		//public PokeBattle_Move_11C(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int BaseDamage(int basedmg, IBattler attacker, IBattler opponent)
		{
			if (Kernal.MoveData[(Moves)opponent.effects.TwoTurnAttack].Effect == Attack.Effects.x09C ||// Fly
				Kernal.MoveData[(Moves)opponent.effects.TwoTurnAttack].Effect == Attack.Effects.x108 || // Bounce
				Kernal.MoveData[(Moves)opponent.effects.TwoTurnAttack].Effect == Attack.Effects.x138 || // Sky Drop
			   opponent.effects.SkyDrop)
			{
				return basedmg * 2;
			}
			return basedmg;
		}
		//ToDo: Double check this one
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			int ret = -1; _host.StartCoroutine(base.GetEffect(attacker, opponent, hitnum, alltargets, showanimation, result:value=>ret=value)); result(ret);
			if (opponent.damagestate.CalcDamage > 0 &&
				!opponent.damagestate.Substitute &&
				!opponent.effects.Roost)
			{
				opponent.effects.SmackDown = true;

				bool showmsg = opponent.HasType(Types.FLYING) ||
						 opponent.hasWorkingAbility(Abilities.LEVITATE);
				if (Kernal.MoveData[(Moves)opponent.effects.TwoTurnAttack].Effect == Attack.Effects.x09C ||// Fly
					Kernal.MoveData[(Moves)opponent.effects.TwoTurnAttack].Effect == Attack.Effects.x108)	// Bounce
				{
					opponent.effects.TwoTurnAttack = 0; showmsg = true;
				}
				if (opponent.effects.MagnetRise > 0)
				{
					opponent.effects.MagnetRise = 0; showmsg = true;
				}
				if (opponent.effects.Telekinesis > 0)
				{
					opponent.effects.Telekinesis = 0; showmsg = true;
				}
				if (showmsg) battle.Display(Game._INTL("{1} fell straight down!", opponent.ToString()));
			}
			result(ret);
			yield break;
		}
	}

	/// <summary>
	/// Target moves immediately after the user, ignoring priority/speed. (After You)
	/// <summary>
	public partial class PokeBattle_Move_11D : PokeBattle_Move
	{
		public PokeBattle_Move_11D() : base() { }
		//public PokeBattle_Move_11D(Battle battle, Attack.Move move) : base(battle, move) { }
		public override bool MoveFailed(IBattler attacker, IBattler opponent)
		{
			if (opponent.effects.MoveNext) return true;
			if ((int)this.battle.choices[opponent.Index].Action != 1) return true; // Didn't choose a move
			Moves oppmove = this.battle.choices[opponent.Index].Move.id;
			if (oppmove <= 0) return true;
			if (opponent.hasMovedThisRound()) return true;
			return false;
		}

		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));

			opponent.effects.MoveNext = true;
			opponent.effects.Quash = false;
			_host.StartCoroutine(battle.Display(Game._INTL("{1} took the kind offer!", opponent.ToString())));
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// Target moves last this round, ignoring priority/speed. (Quash)
	/// <summary>
	public partial class PokeBattle_Move_11E : PokeBattle_Move
	{
		public PokeBattle_Move_11E() : base() { }
		//public PokeBattle_Move_11E(Battle battle, Attack.Move move) : base(battle, move) { }
		public override bool MoveFailed(IBattler attacker, IBattler opponent)
		{
			if (opponent.effects.Quash) return true;
			if ((int)this.battle.choices[opponent.Index].Action != 1) return true; // Didn't choose a move
			Moves oppmove = this.battle.choices[opponent.Index].Move.id;
			if (oppmove <= 0) return true;
			if (opponent.hasMovedThisRound()) return true;
			return false;
		}

		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));

			opponent.effects.Quash = true;
			opponent.effects.MoveNext = false;
			_host.StartCoroutine(battle.Display(Game._INTL("{1}'s move was postponed!", opponent.ToString())));
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// For 5 rounds, for each priority bracket, slow Pokémon move before fast ones.
	/// (Trick Room)
	/// <summary>
	public partial class PokeBattle_Move_11F : PokeBattle_Move
	{
		public PokeBattle_Move_11F() : base() { }
		//public PokeBattle_Move_11F(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (this.battle.field.TrickRoom > 0)
			{
				this.battle.field.TrickRoom = 0;
				_host.StartCoroutine(battle.Display(Game._INTL("{1} reverted the dimensions!", attacker.ToString())));
			}
			else
			{
				_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));

				this.battle.field.TrickRoom = 5;
				_host.StartCoroutine(battle.Display(Game._INTL("{1} twisted the dimensions!", attacker.ToString())));
			}
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// User switches places with its ally. (Ally Switch)
	/// <summary>
	/// <remarks>
	/// Code below might not need to be complicated since Battle.Pokemon rewrite
	/// stores values in Battle.Battler (position) instead of in Pokemon variable
	/// </remarks>
	public partial class PokeBattle_Move_120 : PokeBattle_Move
	{
		public PokeBattle_Move_120() : base() { }
		//public PokeBattle_Move_120(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (!this.battle.doublebattle ||
			   attacker.Partner.Species == Pokemons.NONE ||
			   attacker.Partner.isFainted())
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			_host.StartCoroutine(ShowAnimation(this.id, attacker, null, hitnum, alltargets, showanimation));

			IBattler a = this.battle.battlers[attacker.Index];
			IBattler b = this.battle.battlers[attacker.Partner.Index];

			IBattler temp = a; a = b; b = temp;
			// Swap effects that point at the position rather than the Pokémon
			// NOT PerishSongUser (no need to swap), Attract, MultiTurnUser
			//List<BattlerEffects> effectstoswap = new List<BattlerEffects>{
			//	BattlerEffects.BideTarget,
			//	BattlerEffects.CounterTarget,
			//	BattlerEffects.LeechSeed,
			//	BattlerEffects.LockOnPos,
			//	BattlerEffects.MeanLook,
			//	BattlerEffects.MirrorCoatTarget
			//};
			//foreach (BattlerEffects i in effectstoswap)
			{
				//a.effects[i], b.effects[i]= b.effects[i], a.effects[i];
				IEffectsBattler atemp = a.effects;
				IEffectsBattler btemp = b.effects;
				//a.effects.Attract				= btemp.Attract			;
				//a.effects.BatonPass			= btemp.BatonPass		;
				//a.effects.Bide				= btemp.Bide			;
				//a.effects.BideDamage			= btemp.BideDamage		;
				a.effects.BideTarget			= btemp.BideTarget		;
				//a.effects.Charge				= btemp.Charge			;
				//a.effects.ChoiceBand			= btemp.ChoiceBand		;
				//a.effects.Counter				= btemp.Counter			;
				a.effects.CounterTarget			= btemp.CounterTarget	;
				//a.effects.DefenseCurl			= btemp.DefenseCurl		;
				//a.effects.DestinyBond			= btemp.DestinyBond		;
				//a.effects.Disable				= btemp.Disable			;
				//a.effects.DisableMove			= btemp.DisableMove		;
				//a.effects.Electrify			= btemp.Electrify		;
				//a.effects.Encore				= btemp.Encore			;
				//a.effects.EncoreIndex			= btemp.EncoreIndex		;
				//a.effects.EncoreMove			= btemp.EncoreMove		;
				//a.effects.Endure				= btemp.Endure			;
				//a.effects.FirstPledge			= btemp.FirstPledge		;
				//a.effects.FlashFire			= btemp.FlashFire		;
				//a.effects.Flinch				= btemp.Flinch			;
				//a.effects.FollowMe			= btemp.FollowMe		;
				//a.effects.Foresight			= btemp.Foresight		;
				//a.effects.FuryCutter			= btemp.FuryCutter		;
				//a.effects.Grudge				= btemp.Grudge			;
				//a.effects.HelpingHand			= btemp.HelpingHand		;
				//a.effects.HyperBeam			= btemp.HyperBeam		;
				//a.effects.Illusion			= btemp.Illusion		;
				//a.effects.Imprison			= btemp.Imprison		;
				//a.effects.KingsShield			= btemp.KingsShield		;
				a.effects.LeechSeed				= btemp.LeechSeed		;
				//a.effects.LifeOrb				= btemp.LifeOrb			;
				//a.effects.LockOn				= btemp.LockOn			;
				a.effects.LockOnPos				= btemp.LockOnPos		;
				//a.effects.MagicCoat			= btemp.MagicCoat		;
				a.effects.MeanLook				= btemp.MeanLook		;
				//a.effects.MeFirst				= btemp.MeFirst			;
				//a.effects.Metronome			= btemp.Metronome		;
				//a.effects.MicleBerry			= btemp.MicleBerry		;
				//a.effects.Minimize			= btemp.Minimize		;
				//a.effects.MiracleEye			= btemp.MiracleEye		;
				//a.effects.MirrorCoat			= btemp.MirrorCoat		;
				a.effects.MirrorCoatTarget		= btemp.MirrorCoatTarget;
				//a.effects.MoveNext			= btemp.MoveNext		;
				//a.effects.MudSport			= btemp.MudSport		;
				//a.effects.MultiTurn			= btemp.MultiTurn		;
				//a.effects.MultiTurnAttack		= btemp.MultiTurnAttack	;
				//a.effects.MultiTurnUser		= btemp.MultiTurnUser	;
				//a.effects.Nightmare			= btemp.Nightmare		;
				//a.effects.Outrage				= btemp.Outrage			;
				//a.effects.ParentalBond		= btemp.ParentalBond	;
				//a.effects.PickupItem			= btemp.PickupItem		;
				//a.effects.PickupUse			= btemp.PickupUse		;
				//a.effects.Pinch				= btemp.Pinch			;
				//a.effects.Powder				= btemp.Powder			;
				//a.effects.Protect				= btemp.Protect			;
				//a.effects.ProtectNegation		= btemp.ProtectNegation	;
				//a.effects.ProtectRate			= btemp.ProtectRate		;
				//a.effects.Pursuit				= btemp.Pursuit			;
				//a.effects.Quash				= btemp.Quash			;
				//a.effects.Rage				= btemp.Rage			;
				//a.effects.Revenge				= btemp.Revenge			;
				//a.effects.Roar				= btemp.Roar			;
				//a.effects.Rollout				= btemp.Rollout			;
				//a.effects.Roost				= btemp.Roost			;
				//a.effects.SkipTurn			= btemp.SkipTurn		;
				//a.effects.SkyDrop				= btemp.SkyDrop			;
				//a.effects.SmackDown			= btemp.SmackDown		;
				//a.effects.Snatch				= btemp.Snatch			;
				//a.effects.SpikyShield			= btemp.SpikyShield		;
				//a.effects.Stockpile			= btemp.Stockpile		;
				//a.effects.StockpileDef		= btemp.StockpileDef	;
				//a.effects.StockpileSpDef		= btemp.StockpileSpDef	;
				//a.effects.Taunt				= btemp.Taunt			;
				//a.effects.Torment				= btemp.Torment			;
				//a.effects.Toxic				= btemp.Toxic			;
				//a.effects.Transform			= btemp.Transform		;
				//a.effects.Truant				= btemp.Truant			;
				//a.effects.TwoTurnAttack		= btemp.TwoTurnAttack	;
				//a.effects.Type3				= btemp.Type3			;
				//a.effects.Unburden			= btemp.Unburden		;
				//a.effects.Uproar				= btemp.Uproar			;
				//a.effects.Uturn				= btemp.Uturn			;
				//a.effects.WaterSport			= btemp.WaterSport		;
				//a.effects.WeightChange		= btemp.WeightChange	;
				//a.effects.Yawn				= btemp.Yawn			;
				//b.effects.Attract				= atemp.Attract			;
				//b.effects.BatonPass			= atemp.BatonPass		;
				//b.effects.Bide				= atemp.Bide			;
				//b.effects.BideDamage			= atemp.BideDamage		;
				b.effects.BideTarget			= atemp.BideTarget		;
				//b.effects.Charge				= atemp.Charge			;
				//b.effects.ChoiceBand			= atemp.ChoiceBand		;
				//b.effects.Counter				= atemp.Counter			;
				b.effects.CounterTarget			= atemp.CounterTarget	;
				//b.effects.DefenseCurl			= atemp.DefenseCurl		;
				//b.effects.DestinyBond			= atemp.DestinyBond		;
				//b.effects.Disable				= atemp.Disable			;
				//b.effects.DisableMove			= atemp.DisableMove		;
				//b.effects.Electrify			= atemp.Electrify		;
				//b.effects.Encore				= atemp.Encore			;
				//b.effects.EncoreIndex			= atemp.EncoreIndex		;
				//b.effects.EncoreMove			= atemp.EncoreMove		;
				//b.effects.Endure				= atemp.Endure			;
				//b.effects.FirstPledge			= atemp.FirstPledge		;
				//b.effects.FlashFire			= atemp.FlashFire		;
				//b.effects.Flinch				= atemp.Flinch			;
				//b.effects.FollowMe			= atemp.FollowMe		;
				//b.effects.Foresight			= atemp.Foresight		;
				//b.effects.FuryCutter			= atemp.FuryCutter		;
				//b.effects.Grudge				= atemp.Grudge			;
				//b.effects.HelpingHand			= atemp.HelpingHand		;
				//b.effects.HyperBeam			= atemp.HyperBeam		;
				//b.effects.Illusion			= atemp.Illusion		;
				//b.effects.Imprison			= atemp.Imprison		;
				//b.effects.KingsShield			= atemp.KingsShield		;
				b.effects.LeechSeed				= atemp.LeechSeed		;
				//b.effects.LifeOrb				= atemp.LifeOrb			;
				//b.effects.LockOn				= atemp.LockOn			;
				b.effects.LockOnPos				= atemp.LockOnPos		;
				//b.effects.MagicCoat			= atemp.MagicCoat		;
				b.effects.MeanLook				= atemp.MeanLook		;
				//b.effects.MeFirst				= atemp.MeFirst			;
				//b.effects.Metronome			= atemp.Metronome		;
				//b.effects.MicleBerry			= atemp.MicleBerry		;
				//b.effects.Minimize			= atemp.Minimize		;
				//b.effects.MiracleEye			= atemp.MiracleEye		;
				//b.effects.MirrorCoat			= atemp.MirrorCoat		;
				b.effects.MirrorCoatTarget		= atemp.MirrorCoatTarget;
				//b.effects.MoveNext			= atemp.MoveNext		;
				//b.effects.MudSport			= atemp.MudSport		;
				//b.effects.MultiTurn			= atemp.MultiTurn		;
				//b.effects.MultiTurnAttack		= atemp.MultiTurnAttack	;
				//b.effects.MultiTurnUser		= atemp.MultiTurnUser	;
				//b.effects.Nightmare			= atemp.Nightmare		;
				//b.effects.Outrage				= atemp.Outrage			;
				//b.effects.ParentalBond		= atemp.ParentalBond	;
				//b.effects.PickupItem			= atemp.PickupItem		;
				//b.effects.PickupUse			= atemp.PickupUse		;
				//b.effects.Pinch				= atemp.Pinch			;
				//b.effects.Powder				= atemp.Powder			;
				//b.effects.Protect				= atemp.Protect			;
				//b.effects.ProtectNegation		= atemp.ProtectNegation	;
				//b.effects.ProtectRate			= atemp.ProtectRate		;
				//b.effects.Pursuit				= atemp.Pursuit			;
				//b.effects.Quash				= atemp.Quash			;
				//b.effects.Rage				= atemp.Rage			;
				//b.effects.Revenge				= atemp.Revenge			;
				//b.effects.Roar				= atemp.Roar			;
				//b.effects.Rollout				= atemp.Rollout			;
				//b.effects.Roost				= atemp.Roost			;
				//b.effects.SkipTurn			= atemp.SkipTurn		;
				//b.effects.SkyDrop				= atemp.SkyDrop			;
				//b.effects.SmackDown			= atemp.SmackDown		;
				//b.effects.Snatch				= atemp.Snatch			;
				//b.effects.SpikyShield			= atemp.SpikyShield		;
				//b.effects.Stockpile			= atemp.Stockpile		;
				//b.effects.StockpileDef		= atemp.StockpileDef	;
				//b.effects.StockpileSpDef		= atemp.StockpileSpDef	;
				//b.effects.Taunt				= atemp.Taunt			;
				//b.effects.Torment				= atemp.Torment			;
				//b.effects.Toxic				= atemp.Toxic			;
				//b.effects.Transform			= atemp.Transform		;
				//b.effects.Truant				= atemp.Truant			;
				//b.effects.TwoTurnAttack		= atemp.TwoTurnAttack	;
				//b.effects.Type3				= atemp.Type3			;
				//b.effects.Unburden			= atemp.Unburden		;
				//b.effects.Uproar				= atemp.Uproar			;
				//b.effects.Uturn				= atemp.Uturn			;
				//b.effects.WaterSport			= atemp.WaterSport		;
				//b.effects.WeightChange		= atemp.WeightChange	;
				//b.effects.Yawn				= atemp.Yawn			;
			}

			attacker.Update(true);

			opponent.Update(true);
			_host.StartCoroutine(battle.Display(Game._INTL("{1} and {2} switched places!", opponent.ToString(), attacker.ToString(true))));
			result(0);
			yield break;//ToDo: Not sure what to return here, so i added null/0
		}
	}

	/// <summary>
	/// Target's Attack is used instead of user's Attack for this move's calculations.
	/// (Foul Play)
	/// <summary>
	public partial class PokeBattle_Move_121 : PokeBattle_Move
	{
		public PokeBattle_Move_121() : base() { }
		//public PokeBattle_Move_121(Battle battle, Attack.Move move) : base(battle, move) { }
		// Handled in superclass public object CalcDamage, do not edit!
	}

	/// <summary>
	/// Target's Defense is used instead of its Special Defense for this move's
	/// calculations. (Psyshock, Psystrike, Secret Sword)
	/// <summary>
	public partial class PokeBattle_Move_122 : PokeBattle_Move
	{
		public PokeBattle_Move_122() : base() { }
		//public PokeBattle_Move_122(Battle battle, Attack.Move move) : base(battle, move) { }
		// Handled in superclass public object CalcDamage, do not edit!
	}

	/// <summary>
	/// Only damages Pokémon that share a type with the user. (Synchronoise)
	/// <summary>
	public partial class PokeBattle_Move_123 : PokeBattle_Move
	{
		public PokeBattle_Move_123() : base() { }
		//public PokeBattle_Move_123(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (!opponent.HasType(attacker.Type1) &&
			   !opponent.HasType(attacker.Type2) &&
			   !opponent.HasType(attacker.effects.Type3))
			{
				_host.StartCoroutine(battle.Display(Game._INTL("{1} was unaffected!", opponent.ToString())));
				result(-1);
				yield break;
			}
			int reti = -1; _host.StartCoroutine(base.GetEffect(attacker, opponent, hitnum, alltargets, showanimation, result:value=>reti=value)); result(reti);
			yield break;
		}
	}

	/// <summary>
	/// For 5 rounds, swaps all battlers' base Defense with base Special Defense.
	/// (Wonder Room)
	/// <summary>
	public partial class PokeBattle_Move_124 : PokeBattle_Move
	{
		public PokeBattle_Move_124() : base() { }
		//public PokeBattle_Move_124(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (this.battle.field.WonderRoom > 0)
			{
				this.battle.field.WonderRoom = 0;
				_host.StartCoroutine(battle.Display(Game._INTL("Wonder Room wore off, and the Defense and Sp. Def stats returned to normal!")));
			}
			else
			{
				_host.StartCoroutine(ShowAnimation(this.id, attacker, null, hitnum, alltargets, showanimation));

				this.battle.field.WonderRoom = 5;
				_host.StartCoroutine(battle.Display(Game._INTL("It created a bizarre area in which the Defense and Sp. Def stats are swapped!")));
			}
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// Fails unless user has already used all other moves it knows. (Last Resort)
	/// <summary>
	public partial class PokeBattle_Move_125 : PokeBattle_Move
	{
		public PokeBattle_Move_125() : base() { }
		//public PokeBattle_Move_125(Battle battle, Attack.Move move) : base(battle, move) { }
		public override bool MoveFailed(IBattler attacker, IBattler opponent)
		{
			byte counter = 0; byte nummoves = 0;
			foreach (var move in attacker.moves)
			{
				if (move.id <= 0) continue; //next
				if (move.id != this.id && !attacker.movesUsed.Contains(move.id)) counter += 1;
				nummoves += 1;
			}
			return counter != 0 || nummoves == 1;
		}
	}

	#region Shadow Moves
	//===============================================================================
	// NOTE: Shadow moves use function codes 126-132 inclusive.
	//===============================================================================
	#endregion

	/// <summary>
	/// Does absolutely nothing. (Hold Hands)
	/// <summary>
	public partial class PokeBattle_Move_133 : PokeBattle_Move
	{
		public PokeBattle_Move_133() : base() { }
		//public PokeBattle_Move_133(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (!this.battle.doublebattle ||
			   attacker.Partner.Species == Pokemons.NONE || attacker.Partner.isFainted())
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// Does absolutely nothing. Shows a special message. (Celebrate)
	/// <summary>
	public partial class PokeBattle_Move_134 : PokeBattle_Move
	{
		public PokeBattle_Move_134() : base() { }
		//public PokeBattle_Move_134(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			_host.StartCoroutine(ShowAnimation(this.id, attacker, null, hitnum, alltargets, showanimation));

			_host.StartCoroutine(battle.Display(Game._INTL("Congratulations, {1}!", this.battle.GetOwner(attacker.Index).name)));
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// Freezes the target. (Freeze-Dry)
	/// (Superclass's TypeModifier): Effectiveness against Water-type is 2x.
	/// <summary>
	public partial class PokeBattle_Move_135 : PokeBattle_Move
	{
		public PokeBattle_Move_135() : base() { }
		//public PokeBattle_Move_135(Battle battle, Attack.Move move) : base(battle, move) { }
		public override void AdditionalEffect(IBattler attacker, IBattler opponent)
		{
			if (opponent.damagestate.Substitute) return;
			if (opponent is IBattlerClause b && b.CanFreeze(attacker, false, this))
			{
				if (opponent is IBattlerEffectIE o) _host.StartCoroutine(o.Freeze());
			}
		}
	}

	/// <summary>
	/// Increases the user's Defense by 1 stage for each target hit. (Diamond Storm)
	/// <summary>
	public partial class PokeBattle_Move_136 : PokeBattle_Move_01D
	{
		public PokeBattle_Move_136() : base() { }
		//public PokeBattle_Move_136(Battle battle, Attack.Move move) : base(battle, move) { }
		// No difference to function code 01D. It may need to be separate in future.
	}

	/// <summary>
	/// Increases the user's and its ally's Defense and Special Defense by 1 stage
	/// each, if they have Plus or Minus. (Magnetic Flux)
	/// <summary>
	public partial class PokeBattle_Move_137 : PokeBattle_Move
	{
		public PokeBattle_Move_137() : base() { }
		//public PokeBattle_Move_137(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			bool didsomething = false;
			foreach (IBattler i in new IBattler[] { attacker, attacker.Partner })
			{
				if (i.Species == Pokemons.NONE || i.isFainted()) continue; //next
				if (!i.hasWorkingAbility(Abilities.PLUS) && !i.hasWorkingAbility(Abilities.MINUS)) continue; //next
				if (i is IBattlerEffect b &&
					!b.CanIncreaseStatStage(Stats.DEFENSE, attacker, false, this) &&
					!b.CanIncreaseStatStage(Stats.SPDEF, attacker, false, this)) continue; //next
				if (!didsomething) ShowAnimation(this.id, attacker, null, hitnum, alltargets, showanimation);
				didsomething = true;

				bool showanim = true;
				if (i is IBattlerEffect b0 && b0.CanIncreaseStatStage(Stats.DEFENSE, attacker, false, this))
				{
					b0.IncreaseStat(Stats.DEFENSE, 1, attacker, false, this, showanim);
					showanim = false;
				}
				if (i is IBattlerEffect b1 && b1.CanIncreaseStatStage(Stats.SPDEF, attacker, false, this))
				{
					b1.IncreaseStat(Stats.SPDEF, 1, attacker, false, this, showanim);
					showanim = false;
				}
			}
			if (!didsomething)
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// Increases ally's Special Defense by 1 stage. (Aromatic Mist)
	/// <summary>
	public partial class PokeBattle_Move_138 : PokeBattle_Move
	{
		public PokeBattle_Move_138() : base() { }
		//public PokeBattle_Move_138(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (!this.battle.doublebattle || opponent.Species == Pokemons.NONE ||
			   opponent is IBattlerEffect b && !b.CanIncreaseStatStage(Stats.SPDEF, attacker, false, this))
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));

			bool ret = attacker is IBattlerEffect a && a.IncreaseStat(Stats.SPDEF, 1, attacker, false, this);
			result(ret ? 0 : -1);
			yield break;
		}
	}

	/// <summary>
	/// Decreases the target's Attack by 1 stage. Always hits. (Play Nice)
	/// <summary>
	public partial class PokeBattle_Move_139 : PokeBattle_Move
	{
		public PokeBattle_Move_139() : base() { }
		//public PokeBattle_Move_139(Battle battle, Attack.Move move) : base(battle, move) { }
		public override bool AccuracyCheck(IBattler attacker, IBattler opponent) { return this.AccuracyCheck((IBattlerIE)attacker, (IBattlerIE)opponent); }
		public bool AccuracyCheck(IBattlerIE attacker, IBattlerIE opponent)
		{
			return true;
		}

		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (opponent is IBattlerEffectIE b) { bool retb = false; _host.StartCoroutine(b.CanReduceStatStage(Stats.ATTACK, attacker, true, this, result:value=>retb=value)); if (!retb) { result(-1); yield break; } }
			_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));

			bool ret = opponent is IBattlerEffect o && o.ReduceStat(Stats.ATTACK, 1, attacker, false, this);
			result(ret ? 0 : -1);
			yield break;
		}
	}

	/// <summary>
	/// Decreases the target's Attack and Special Attack by 1 stage each. (Noble Roar)
	/// <summary>
	public partial class PokeBattle_Move_13A : PokeBattle_Move
	{
		public PokeBattle_Move_13A() : base() { }
		//public PokeBattle_Move_13A(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			// Replicates CanReduceStatStage? so that certain messages aren't shown
			// multiple times
			if (opponent.effects.Substitute > 0 && !ignoresSubstitute(attacker))
			{
				_host.StartCoroutine(battle.Display(Game._INTL("{1}'s attack missed!", attacker.ToString())));
				result(-1);
				yield break;
			}
			if (opponent is IBattlerEffect b &&
				b.TooLow(Stats.ATTACK) &&
				b.TooLow(Stats.SPATK))
			{
				_host.StartCoroutine(battle.Display(Game._INTL("{1}'s stats won't go any lower!", opponent.ToString())));
				result(-1);
				yield break;
			}
			if (opponent.OwnSide.Mist > 0)
			{
				_host.StartCoroutine(battle.Display(Game._INTL("{1} is protected by Mist!", opponent.ToString())));
				result(-1);
				yield break;
			}
			if (!attacker.hasMoldBreaker())
			{
				if (opponent.hasWorkingAbility(Abilities.CLEAR_BODY) ||
				   opponent.hasWorkingAbility(Abilities.WHITE_SMOKE))
				{
					_host.StartCoroutine(battle.Display(Game._INTL("{1}'s {2} prevents stat loss!", opponent.ToString(),
					   Game._INTL(opponent.Ability.ToString(TextScripts.Name)))));
					result(-1);
					yield break;
				}
			}

			_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));

			int ret = -1; bool showanim = true;
			if (!attacker.hasMoldBreaker() && opponent.hasWorkingAbility(Abilities.HYPER_CUTTER))
			{
				string abilityname = Game._INTL(opponent.Ability.ToString(TextScripts.Name));
				_host.StartCoroutine(battle.Display(Game._INTL("{1}'s {2} prevents Attack loss!", opponent.ToString(), abilityname)));
			}
			else if (opponent is IBattlerEffect b0 && b0.ReduceStat(Stats.ATTACK, 1, attacker, false, this, showanim))
			{
				ret = 0; showanim = false;
			}
			if (opponent is IBattlerEffect b1 && b1.ReduceStat(Stats.SPATK, 1, attacker, false, this, showanim))
			{
				ret = 0; showanim = false;
			}
			result(ret);
			yield break;
		}
	}

	/// <summary>
	/// Decreases the target's Defense by 1 stage. Always hits. (Hyperspace Fury)
	/// <summary>
	public partial class PokeBattle_Move_13B : PokeBattle_Move
	{
		public PokeBattle_Move_13B() : base() { }
		//public PokeBattle_Move_13B(Battle battle, Attack.Move move) : base(battle, move) { }
		public override bool MoveFailed(IBattler attacker, IBattler opponent)
		{
			if (attacker.Species == Pokemons.HOOPA) return true;
			if (attacker.form != 1) return true;
			return false;
		}

		public override bool AccuracyCheck(IBattler attacker, IBattler opponent) { return this.AccuracyCheck((IBattlerIE)attacker, (IBattlerIE)opponent); }
		public bool AccuracyCheck(IBattlerIE attacker, IBattlerIE opponent)
		{
			return true;
		}

		public override void AdditionalEffect(IBattler attacker, IBattler opponent)
		{
			if (opponent.damagestate.Substitute) return;
			if (opponent is IBattlerEffect b && b.CanReduceStatStage(Stats.DEFENSE, attacker, false, this))
			{
				b.ReduceStat(Stats.DEFENSE, 1, attacker, false, this);
			}
		}
	}

	/// <summary>
	/// Decreases the target's Special Attack by 1 stage. Always hits. (Confide)
	/// <summary>
	public partial class PokeBattle_Move_13C : PokeBattle_Move
	{
		public PokeBattle_Move_13C() : base() { }
		//public PokeBattle_Move_13C(Battle battle, Attack.Move move) : base(battle, move) { }
		public override bool AccuracyCheck(IBattler attacker, IBattler opponent) { return this.AccuracyCheck((IBattlerIE)attacker, (IBattlerIE)opponent); }
		public bool AccuracyCheck(IBattlerIE attacker, IBattlerIE opponent)
		{
			return true;
		}

		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (opponent is IBattlerEffectIE b) { bool retb = false; _host.StartCoroutine(b.CanReduceStatStage(Stats.SPATK, attacker, true, this, result:value=>retb=value)); if (!retb) { result(-1); yield break; } }
			_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));

			bool ret = opponent is IBattlerEffect o && o.ReduceStat(Stats.SPATK, 1, attacker, false, this);
			result(ret ? 0 : -1);
			yield break;
		}
	}

	/// <summary>
	/// Decreases the target's Special Attack by 2 stages. (Eerie Impulse)
	/// <summary>
	public partial class PokeBattle_Move_13D : PokeBattle_Move
	{
		public PokeBattle_Move_13D() : base() { }
		//public PokeBattle_Move_13D(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (IsDamaging()) { int reti = -1; _host.StartCoroutine(base.GetEffect(attacker, opponent, hitnum, alltargets, showanimation, result:value=>reti=value)); result(reti); yield break; }
			if (TypeImmunityByAbility(GetType(this.type, attacker, opponent), attacker, opponent)) { result(-1); yield break; }
			if (opponent is IBattlerEffectIE b) { bool retb = false; _host.StartCoroutine(b.CanReduceStatStage(Stats.SPATK, attacker, true, this, result:value=>retb=value)); if (!retb) { result(-1); yield break; } }
			_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));

			bool ret = opponent is IBattlerEffect o && o.ReduceStat(Stats.SPATK, 2, attacker, false, this);
			result(ret ? 0 : -1);
			yield break;
		}

		public override void AdditionalEffect(IBattler attacker, IBattler opponent)
		{
			if (opponent.damagestate.Substitute) return;
			if (opponent is IBattlerEffect b && b.CanReduceStatStage(Stats.SPATK, attacker, false, this))
			{
				b.ReduceStat(Stats.SPATK, 2, attacker, false, this);
			}
		}
	}

	/// <summary>
	/// Increases the Attack and Special Attack of all Grass-type Pokémon on the field
	/// by 1 stage each. Doesn't affect airborne Pokémon. (Rototiller)
	/// <summary>
	public partial class PokeBattle_Move_13E : PokeBattle_Move
	{
		public PokeBattle_Move_13E() : base() { }
		//public PokeBattle_Move_13E(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			bool didsomething = false; //ToDo: If double battle?
			foreach (IBattler i in new IBattler[] { attacker, attacker.Partner, attacker.Opposing1, attacker.Opposing2 })
			{
				if (i.Species == Pokemons.NONE || i.isFainted()) continue; //next
				if (!i.HasType(Types.GRASS)) continue; //next
				if (i.isAirborne(attacker.hasMoldBreaker())) continue; //next
				if (i is IBattlerEffect b &&
					!b.CanIncreaseStatStage(Stats.ATTACK, attacker, false, this) &&
						!b.CanIncreaseStatStage(Stats.SPATK, attacker, false, this)) continue;//next
				if (!didsomething) ShowAnimation(this.id, attacker, null, hitnum, alltargets, showanimation);
				didsomething = true;

				bool showanim = true;
				if (i is IBattlerEffect b0 && b0.CanIncreaseStatStage(Stats.ATTACK, attacker, false, this))
				{
					b0.IncreaseStat(Stats.ATTACK, 1, attacker, false, this, showanim);
					showanim = false;
				}
				if (i is IBattlerEffect b1 && b1.CanIncreaseStatStage(Stats.SPATK, attacker, false, this))
				{
					b1.IncreaseStat(Stats.SPATK, 1, attacker, false, this, showanim);
					showanim = false;
				}
			}
			if (!didsomething)
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// Increases the Defense of all Grass-type Pokémon on the field by 1 stage each.
	/// (Flower Shield)
	/// <summary>
	public partial class PokeBattle_Move_13F : PokeBattle_Move
	{
		public PokeBattle_Move_13F() : base() { }
		//public PokeBattle_Move_13F(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			bool didsomething = false; //ToDo: If double battle?
			foreach (IBattler i in new IBattler[] { attacker, attacker.Partner, attacker.Opposing1, attacker.Opposing2 })
			{
				if (i.Species == Pokemons.NONE || i.isFainted()) continue; //next
				if (!i.HasType(Types.GRASS)) continue; //next
				if (i is IBattlerEffect b && !b.CanIncreaseStatStage(Stats.ATTACK, attacker, false, this)) continue; //next
				if (!didsomething) ShowAnimation(this.id, attacker, null, hitnum, alltargets, showanimation);
				didsomething = true;

				bool showanim = true;
				if (i is IBattlerEffect b0 && b0.CanIncreaseStatStage(Stats.DEFENSE, attacker, false, this))
				{
					b0.IncreaseStat(Stats.DEFENSE, 1, attacker, false, this, showanim);
					showanim = false;
				}
			}
			if (!didsomething)
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// Decreases the Attack, Special Attack and Speed of all poisoned opponents by 1
	/// stage each. (Venom Drench)
	/// <summary>
	public partial class PokeBattle_Move_140 : PokeBattle_Move
	{
		public PokeBattle_Move_140() : base() { }
		//public PokeBattle_Move_140(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			bool didsomething = false;
			foreach (IBattler i in new IBattler[] { attacker.Opposing1, attacker.Opposing2 })
			{
				if (i.Species == Pokemons.NONE || i.isFainted()) continue; //next
				if (i.Status != Status.POISON) continue; //next
				if (i is IBattlerEffect b &&
					!b.CanReduceStatStage(Stats.ATTACK, attacker, false, this) &&
					!b.CanReduceStatStage(Stats.SPATK, attacker, false, this) &&
					!b.CanReduceStatStage(Stats.SPEED, attacker, false, this)) continue; //next
				if (!didsomething) ShowAnimation(this.id, attacker, null, hitnum, alltargets, showanimation);
				didsomething = true;

				bool showanim = true;
				if (i is IBattlerEffect b0 && b0.CanReduceStatStage(Stats.ATTACK, attacker, false, this))
				{
					b0.ReduceStat(Stats.ATTACK, 1, attacker, false, this, showanim);
					showanim = false;
				}
				if (i is IBattlerEffect b1 && b1.CanReduceStatStage(Stats.SPATK, attacker, false, this))
				{
					b1.ReduceStat(Stats.SPATK, 1, attacker, false, this, showanim);
					showanim = false;
				}
				if (i is IBattlerEffect b2 && b2.CanReduceStatStage(Stats.SPEED, attacker, false, this))
				{
					b2.ReduceStat(Stats.SPEED, 1, attacker, false, this, showanim);
					showanim = false;
				}
			}
			if (!didsomething)
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// Reverses all stat changes of the target. (Topsy-Turvy)
	/// <summary>
	public partial class PokeBattle_Move_141 : PokeBattle_Move
	{
		public PokeBattle_Move_141() : base() { }
		//public PokeBattle_Move_141(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			bool nonzero = false;
			foreach (var i in new[] { Stats.ATTACK, Stats.DEFENSE, Stats.SPEED,
				  Stats.SPATK, Stats.SPDEF, Stats.ACCURACY, Stats.EVASION })
			{
				if (opponent.stages[(byte)i] != 0)
				{
					nonzero = true; break;
				}
			}
			if (!nonzero)
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));
			foreach (var i in new[] { Stats.ATTACK, Stats.DEFENSE, Stats.SPEED,
				  Stats.SPATK, Stats.SPDEF, Stats.ACCURACY, Stats.EVASION })
			{
				opponent.stages[(byte)i] *= -1;
			}
			_host.StartCoroutine(battle.Display(Game._INTL("{1}'s stats were reversed!", opponent.ToString())));
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// Gives target the Ghost type. (Trick-or-Treat)
	/// <summary>
	public partial class PokeBattle_Move_142 : PokeBattle_Move
	{
		public PokeBattle_Move_142() : base() { }
		//public PokeBattle_Move_142(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if ((opponent.effects.Substitute > 0 && !ignoresSubstitute(attacker)) ||
			   opponent.HasType(Types.GHOST) ||
			   opponent.Ability == Abilities.MULTITYPE)
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));

			opponent.effects.Type3 = Types.GHOST;

			string typename = Game._INTL(Types.GHOST.ToString(TextScripts.Name));
			_host.StartCoroutine(battle.Display(Game._INTL("{1} transformed into the {2} type!", opponent.ToString(), typename)));
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// Gives target the Grass type. (Forest's Curse)
	/// <summary>
	public partial class PokeBattle_Move_143 : PokeBattle_Move
	{
		public PokeBattle_Move_143() : base() { }
		//public PokeBattle_Move_143(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (opponent.effects.Substitute > 0 && !ignoresSubstitute(attacker))
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			if (TypeImmunityByAbility(GetType(this.type, attacker, opponent), attacker, opponent)) { result(-1); yield break; }
			if (opponent.effects.LeechSeed >= 0)
			{
				_host.StartCoroutine(battle.Display(Game._INTL("{1} evaded the attack!", opponent.ToString())));
				result(-1);
				yield break;
			}
			if (opponent.HasType(Types.GRASS) ||
			   opponent.Ability == Abilities.MULTITYPE)
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));

			opponent.effects.Type3 = Types.GRASS;

			string typename = Game._INTL(Types.GRASS.ToString(TextScripts.Name));
			_host.StartCoroutine(battle.Display(Game._INTL("{1} transformed into the {2} type!", opponent.ToString(), typename)));
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// Damage is multiplied by Flying's effectiveness against the target. Does double
	/// damage and has perfect accuracy if the target is Minimized. (Flying Press)
	/// <summary>
	public partial class PokeBattle_Move_144 : PokeBattle_Move
	{
		public PokeBattle_Move_144() : base() { }
		//public PokeBattle_Move_144(Battle battle, Attack.Move move) : base(battle, move) { }
		public int ModifyDamage(int damagemult, IBattler attacker, IBattler opponent)
		{
			type = Types.FLYING;// || -1
			if (type >= 0)
			{
				float mult = type.GetCombinedEffectivenessModifier(
				   opponent.Type1, opponent.Type2, opponent.effects.Type3);
				return (int)Math.Round((damagemult * mult) / 8f);
			}
			return damagemult;
		}

		public bool tramplesMinimize(byte param = 1)
		{
			if (param == 1 && Core.USENEWBATTLEMECHANICS) return true; // Perfect accuracy
			if (param == 2) return true; // Double damage
			return false;
		}
	}

	/// <summary>
	/// Target's moves become Electric-type for the rest of the round. (Electrify)
	/// <summary>
	public partial class PokeBattle_Move_145 : PokeBattle_Move
	{
		public PokeBattle_Move_145() : base() { }
		//public PokeBattle_Move_145(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (TypeImmunityByAbility(GetType(this.type, attacker, opponent), attacker, opponent)) { result(-1); yield break; }
			if (opponent.effects.Electrify)
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			if ((int)this.battle.choices[opponent.Index].Action != 1 || // Didn't choose a move
				//!this.battle.choices[opponent.Index].Move ||
				this.battle.choices[opponent.Index].Move.id <= 0 ||
				opponent.hasMovedThisRound())
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));

			opponent.effects.Electrify = true;
			_host.StartCoroutine(battle.Display(Game._INTL("{1} was electrified!", opponent.ToString())));
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// All Normal-type moves become Electric-type for the rest of the round.
	/// (Ion Deluge)
	/// <summary>
	public partial class PokeBattle_Move_146 : PokeBattle_Move
	{
		public PokeBattle_Move_146() : base() { }
		//public PokeBattle_Move_146(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			bool unmoved = false;
			foreach (IBattler poke in this.battle.battlers)
			{
				if (poke.Index == attacker.Index) continue; //next
				if ((int)this.battle.choices[poke.Index].Action == 1 && // Chose a move
				   !poke.hasMovedThisRound())
				{
					unmoved = true; break;
				}
			}
			if (!unmoved || this.battle.field.IonDeluge)
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			_host.StartCoroutine(ShowAnimation(this.id, attacker, null, hitnum, alltargets, showanimation));

			this.battle.field.IonDeluge = true;
			_host.StartCoroutine(battle.Display(Game._INTL("The Ion Deluge started!")));
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// Always hits. (Hyperspace Hole)
	/// TODO: Hits through various shields.
	/// <summary>
	public partial class PokeBattle_Move_147 : PokeBattle_Move
	{
		public PokeBattle_Move_147() : base() { }
		//public PokeBattle_Move_147(Battle battle, Attack.Move move) : base(battle, move) { }
		public override bool AccuracyCheck(IBattler attacker, IBattler opponent) { return this.AccuracyCheck((IBattlerIE)attacker, (IBattlerIE)opponent); }
		public bool AccuracyCheck(IBattlerIE attacker, IBattlerIE opponent)
		{
			return true;
		}
	}

	/// <summary>
	/// Powders the foe. This round, if it uses a Fire move, it loses 1/4 of its max
	/// HP instead. (Powder)
	/// <summary>
	public partial class PokeBattle_Move_148 : PokeBattle_Move
	{
		public PokeBattle_Move_148() : base() { }
		//public PokeBattle_Move_148(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (opponent.effects.Powder)
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			opponent.effects.Powder = true;

			_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));
			_host.StartCoroutine(battle.Display(Game._INTL("{1} is covered in powder!", attacker.ToString())));
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// This round, the user's side is unaffected by damaging moves. (Mat Block)
	/// <summary>
	public partial class PokeBattle_Move_149 : PokeBattle_Move
	{
		public PokeBattle_Move_149() : base() { }
		//public PokeBattle_Move_149(Battle battle, Attack.Move move) : base(battle, move) { }
		public override bool MoveFailed(IBattler attacker, IBattler opponent)
		{
			return (attacker.turncount > 1);
		}

		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			attacker.OwnSide.MatBlock = true;
			_host.StartCoroutine(ShowAnimation(this.id, attacker, null, hitnum, alltargets, showanimation));

			_host.StartCoroutine(battle.Display(Game._INTL("{1} intends to flip up a mat and block incoming attacks!", attacker.ToString())));
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// User's side is protected against status moves this round. (Crafty Shield)
	/// <summary>
	public partial class PokeBattle_Move_14A : PokeBattle_Move
	{
		public PokeBattle_Move_14A() : base() { }
		//public PokeBattle_Move_14A(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (attacker.OwnSide.CraftyShield)
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			bool unmoved = false;
			foreach (IBattler poke in this.battle.battlers)
			{
				if (poke.Index == attacker.Index) continue; //next
				if ((int)this.battle.choices[poke.Index].Action == 1 && // Chose a move
				   !poke.hasMovedThisRound())
				{
					unmoved = true; break;
				}
			}
			if (!unmoved)
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			_host.StartCoroutine(ShowAnimation(this.id, attacker, null, hitnum, alltargets, showanimation));

			attacker.OwnSide.CraftyShield = true;
			if (!this.battle.IsOpposing(attacker.Index))
			{
				_host.StartCoroutine(battle.Display(Game._INTL("Crafty Shield protected your team!")));
			}
			else
			{
				_host.StartCoroutine(battle.Display(Game._INTL("Crafty Shield protected the opposing team!")));
			}
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// User is protected against damaging moves this round. Decreases the Attack of
	/// the user of a stopped contact move by 2 stages. (King's Shield)
	/// <summary>
	public partial class PokeBattle_Move_14B : PokeBattle_Move
	{
		public PokeBattle_Move_14B() : base() { }
		//public PokeBattle_Move_14B(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (attacker.effects.KingsShield)
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			List<Attack.Effects> ratesharers = new List<Attack.Effects> {
				Attack.Effects.x070,   // Detect, Protect
				Attack.Effects.x133,   // Quick Guard
				Attack.Effects.x117,   // Wide Guard
				Attack.Effects.x075,   // Endure
				Attack.Effects.x164,   // King's Shield
				Attack.Effects.x16A    // Spiky Shield
			};
			if (!ratesharers.Contains(new Attack.Move((Moves)attacker.lastMoveUsed).Effect))
			{
				attacker.effects.ProtectRate = 1;
			}
			bool unmoved = false;
			foreach (IBattler poke in this.battle.battlers)
			{
				if (poke.Index == attacker.Index) continue; //next
				if ((int)this.battle.choices[poke.Index].Action == 1 && // Chose a move
				   !poke.hasMovedThisRound())
				{
					unmoved = true; break;
				}
			}
			if (!unmoved ||
			   (!Core.USENEWBATTLEMECHANICS &&
			   this.battle.Random(65536) >= Math.Floor(65536f / attacker.effects.ProtectRate)))
			{
				attacker.effects.ProtectRate = 1;
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			_host.StartCoroutine(ShowAnimation(this.id, attacker, null, hitnum, alltargets, showanimation));

			attacker.effects.KingsShield = true;
			attacker.effects.ProtectRate *= 2;
			_host.StartCoroutine(battle.Display(Game._INTL("{1} protected itself!", attacker.ToString())));
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// User is protected against moves that target it this round. Damages the user of
	/// a stopped contact move by 1/8 of its max HP. (Spiky Shield)
	/// <summary>
	public partial class PokeBattle_Move_14C : PokeBattle_Move
	{
		public PokeBattle_Move_14C() : base() { }
		//public PokeBattle_Move_14C(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (attacker.effects.SpikyShield)
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			List<Attack.Effects> ratesharers = new List<Attack.Effects> {
				Attack.Effects.x070,   // Detect, Protect
				Attack.Effects.x133,   // Quick Guard
				Attack.Effects.x117,   // Wide Guard
				Attack.Effects.x075,   // Endure
				Attack.Effects.x164,   // King's Shield
				Attack.Effects.x16A    // Spiky Shield
			};
			if (!ratesharers.Contains(new Attack.Move((Moves)attacker.lastMoveUsed).Effect))
			{
				attacker.effects.ProtectRate = 1;
			}
			bool unmoved = false;
			foreach (IBattler poke in this.battle.battlers)
			{
				if (poke.Index == attacker.Index) continue; //next
				if (this.battle.choices[poke.Index].Action == ChoiceAction.UseMove && // Chose a move
				   !poke.hasMovedThisRound())
				{
					unmoved = true; break;
				}
			}
			if (!unmoved ||
			   this.battle.Random(65536) >= Math.Floor(65536f / attacker.effects.ProtectRate))
			{
				attacker.effects.ProtectRate = 1;

				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			_host.StartCoroutine(ShowAnimation(this.id, attacker, null, hitnum, alltargets, showanimation));

			attacker.effects.SpikyShield = true;
			attacker.effects.ProtectRate *= 2;
			_host.StartCoroutine(battle.Display(Game._INTL("{1} protected itself!", attacker.ToString())));
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// Two turn attack. Skips first turn, attacks second turn. (Phantom Force)
	/// Is invulnerable during use.
	/// Ignores target's Detect, King's Shield, Mat Block, Protect and Spiky Shield
	/// this round. If successful, negates them this round.
	/// Does double damage and has perfect accuracy if the target is Minimized.
	/// <summary>
	public partial class PokeBattle_Move_14D : PokeBattle_Move
	{
		public PokeBattle_Move_14D() : base() { }
		//public PokeBattle_Move_14D(Battle battle, Attack.Move move) : base(battle, move) { }
		public override bool TwoTurnAttack(IBattler attacker)
		{
			this.immediate = false;
			if (!this.immediate && attacker.hasWorkingItem(Items.POWER_HERB))
			{
				this.immediate = true;
			}
			if (this.immediate) return false;
			return attacker.effects.TwoTurnAttack == 0;
		}

		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (this.immediate || attacker.effects.TwoTurnAttack > 0)
			{
				_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, 1, alltargets, showanimation)); // Charging anim
				_host.StartCoroutine(battle.Display(Game._INTL("{1} vanished instantly!", attacker.ToString())));
			}
			if (this.immediate)
			{
				_host.StartCoroutine(this.battle.CommonAnimation("UseItem", attacker, null));

				_host.StartCoroutine(battle.Display(Game._INTL("{1} became fully charged due to its Power Herb!", attacker.ToString())));
				_host.StartCoroutine(attacker.ConsumeItem());
			}
			if (attacker.effects.TwoTurnAttack > 0) { result(0); yield break; }
			int ret = -1; _host.StartCoroutine(base.GetEffect(attacker, opponent, hitnum, alltargets, showanimation, result:value=>ret=value)); result(ret);
			if (ret > 0)
			{
				opponent.effects.ProtectNegation = true;
				opponent.OwnSide.CraftyShield = false;
			}
			result(ret);
			yield break;
		}

		public bool tramplesMinimize(byte param = 1)
		{
			if (param == 1 && Core.USENEWBATTLEMECHANICS) return true; // Perfect accuracy
			if (param == 2) return true; // Double damage
			return false;
		}
	}

	/// <summary>
	/// Two turn attack. Skips first turn, increases the user's Special Attack,
	/// Special Defense and Speed by 2 stages each second turn. (Geomancy)
	/// <summary>
	public partial class PokeBattle_Move_14E : PokeBattle_Move
	{
		public PokeBattle_Move_14E() : base() { }
		//public PokeBattle_Move_14E(Battle battle, Attack.Move move) : base(battle, move) { }
		public override bool TwoTurnAttack(IBattler attacker)
		{
			this.immediate = false;
			if (!this.immediate && attacker.hasWorkingItem(Items.POWER_HERB))
			{
				this.immediate = true;
			}
			if (this.immediate) return false;
			return attacker.effects.TwoTurnAttack == 0;
		}

		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (this.immediate || attacker.effects.TwoTurnAttack > 0)
			{
				_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, 1, alltargets, showanimation)); // Charging anim
				_host.StartCoroutine(battle.Display(Game._INTL("{1} is absorbing power!", attacker.ToString())));
			}
			if (this.immediate)
			{
				_host.StartCoroutine(this.battle.CommonAnimation("UseItem", attacker, null));

				_host.StartCoroutine(battle.Display(Game._INTL("{1} became fully charged due to its Power Herb!", attacker.ToString())));
				_host.StartCoroutine(attacker.ConsumeItem());
			}
			if (attacker.effects.TwoTurnAttack > 0) { result(0); yield break; }
			if (attacker is IBattlerEffect b &&
				!b.CanIncreaseStatStage(Stats.SPATK, attacker, false, this) &&
				!b.CanIncreaseStatStage(Stats.SPDEF, attacker, false, this) &&
				!b.CanIncreaseStatStage(Stats.SPEED, attacker, false, this))
			{
				_host.StartCoroutine(battle.Display(Game._INTL("{1}'s stats won't go any higher!", attacker.ToString())));
				result(-1);
				yield break;
			}
			_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));

			bool showanim = true;
			if (attacker is IBattlerEffect b0 && b0.CanIncreaseStatStage(Stats.SPATK, attacker, false, this))
			{
				b0.IncreaseStat(Stats.SPATK, 2, attacker, false, this, showanim);
				showanim = false;
			}
			if (attacker is IBattlerEffect b1 && b1.CanIncreaseStatStage(Stats.SPDEF, attacker, false, this))
			{
				b1.IncreaseStat(Stats.SPDEF, 2, attacker, false, this, showanim);
				showanim = false;
			}
			if (attacker is IBattlerEffect b2 && b2.CanIncreaseStatStage(Stats.SPEED, attacker, false, this))
			{
				b2.IncreaseStat(Stats.SPEED, 2, attacker, false, this, showanim);
				showanim = false;
			}
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// User gains 3/4 the HP it inflicts as damage. (Draining Kiss, Oblivion Wing)
	/// <summary>
	public partial class PokeBattle_Move_14F : PokeBattle_Move
	{
		public PokeBattle_Move_14F() : base() { }
		//public PokeBattle_Move_14F(Battle battle, Attack.Move move) : base(battle, move) { }
		public override bool isHealingMove()
		{
			return Core.USENEWBATTLEMECHANICS;
		}

		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			int ret = -1; _host.StartCoroutine(base.GetEffect(attacker, opponent, hitnum, alltargets, showanimation, result:value=>ret=value)); result(ret);
			if (opponent.damagestate.CalcDamage > 0)
			{
				int hpgain = (int)Math.Round(opponent.damagestate.HPLost * 3 / 4f);
				if (opponent.hasWorkingAbility(Abilities.LIQUID_OOZE))
				{
					attacker.ReduceHP(hpgain, true);
					_host.StartCoroutine(battle.Display(Game._INTL("{1} sucked up the liquid ooze!", attacker.ToString())));
				}
				else if (attacker.effects.HealBlock == 0)
				{
					if (attacker.hasWorkingItem(Items.BIG_ROOT)) hpgain = (int)Math.Floor(hpgain * 1.3f);

					attacker.RecoverHP(hpgain, true);
					_host.StartCoroutine(battle.Display(Game._INTL("{1} had its energy drained!", opponent.ToString())));
				}
			}
			result(ret);
			yield break;
		}
	}

	/// <summary>
	/// If this move KO's the target, increases the user's Attack by 2 stages.
	/// (Fell Stinger)
	/// <summary>
	public partial class PokeBattle_Move_150 : PokeBattle_Move
	{
		public PokeBattle_Move_150() : base() { }
		//public PokeBattle_Move_150(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			int ret = -1; _host.StartCoroutine(base.GetEffect(attacker, opponent, hitnum, alltargets, showanimation, result:value=>ret=value)); result(ret);
			if (opponent.damagestate.CalcDamage > 0 && opponent.isFainted())
			{
				if (attacker is IBattlerEffect b && b.CanIncreaseStatStage(Stats.ATTACK, attacker, false, this))
				{
					b.IncreaseStat(Stats.ATTACK, 2, attacker, false, this);
				}
			}
			result(ret);
			yield break;
		}
	}

	/// <summary>
	/// Decreases the target's Attack and Special Attack by 1 stage each. Then, user
	/// switches out. Ignores trapping moves. (Parting Shot)
	/// TODO: Pursuit should interrupt this move.
	/// <summary>
	public partial class PokeBattle_Move_151 : PokeBattle_Move
	{
		public PokeBattle_Move_151() : base() { }
		//public PokeBattle_Move_151(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			int ret = -1;
			_host.StartCoroutine(ShowAnimation(this.id, attacker, opponent, hitnum, alltargets, showanimation));
			if (!this.Flags.SoundBased ||
			   attacker.hasMoldBreaker() || !opponent.hasWorkingAbility(Abilities.SOUNDPROOF))
			{
				bool showanim = true;
				if (opponent is IBattlerEffect b0 && b0.ReduceStat(Stats.ATTACK, 1, attacker, false, this, showanim))
				{
					showanim = false; ret = 0;
				}
				if (opponent is IBattlerEffect b1 && b1.ReduceStat(Stats.SPATK, 1, attacker, false, this, showanim))
				{
					showanim = false; ret = 0;
				}
			}
			if (!attacker.isFainted() &&
			   this.battle.CanChooseNonActive(attacker.Index) &&
			   !this.battle.AllFainted(this.battle.Party(opponent.Index)))
			{
				attacker.effects.Uturn = true; ret = 0;
			}
			result(ret);
			yield break;
		}
	}

	/// <summary>
	/// No Pokémon can switch out or flee until the end of the next round, as long as
	/// the user remains active. (Fairy Lock)
	/// <summary>
	public partial class PokeBattle_Move_152 : PokeBattle_Move
	{
		public PokeBattle_Move_152() : base() { }
		//public PokeBattle_Move_152(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (this.battle.field.FairyLock > 0)
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			_host.StartCoroutine(ShowAnimation(this.id, attacker, null, hitnum, alltargets, showanimation));

			this.battle.field.FairyLock = 2;
			_host.StartCoroutine(battle.Display(Game._INTL("No one will be able to run away during the next turn!")));
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// Entry hazard. Lays stealth rocks on the opposing side. (Sticky Web)
	/// <summary>
	public partial class PokeBattle_Move_153 : PokeBattle_Move
	{
		public PokeBattle_Move_153() : base() { }
		//public PokeBattle_Move_153(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (attacker.OpposingSide.StickyWeb)
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			_host.StartCoroutine(ShowAnimation(this.id, attacker, null, hitnum, alltargets, showanimation));

			attacker.OpposingSide.StickyWeb = true;
			if (!this.battle.IsOpposing(attacker.Index))
			{
				_host.StartCoroutine(battle.Display(Game._INTL("A sticky web has been laid out beneath the opposing team's feet!")));
			}
			else
			{
				_host.StartCoroutine(battle.Display(Game._INTL("A sticky web has been laid out beneath your team's feet!")));
			}
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// For 5 rounds, creates an electric terrain which boosts Electric-type moves and
	/// prevents Pokémon from falling asleep. Affects non-airborne Pokémon only.
	/// (Electric Terrain)
	/// <summary>
	public partial class PokeBattle_Move_154 : PokeBattle_Move
	{
		public PokeBattle_Move_154() : base() { }
		//public PokeBattle_Move_154(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (this.battle.field.ElectricTerrain > 0)
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			_host.StartCoroutine(ShowAnimation(this.id, attacker, null, hitnum, alltargets, showanimation));

			this.battle.field.GrassyTerrain = 0;
			this.battle.field.MistyTerrain = 0;
			this.battle.field.ElectricTerrain = 5;
			_host.StartCoroutine(battle.Display(Game._INTL("An electric current runs across the battlefield!")));
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// For 5 rounds, creates a grassy terrain which boosts Grass-type moves and heals
	/// Pokémon at the end of each round. Affects non-airborne Pokémon only.
	/// (Grassy Terrain)
	/// <summary>
	public partial class PokeBattle_Move_155 : PokeBattle_Move
	{
		public PokeBattle_Move_155() : base() { }
		//public PokeBattle_Move_155(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (this.battle.field.GrassyTerrain > 0)
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			_host.StartCoroutine(ShowAnimation(this.id, attacker, null, hitnum, alltargets, showanimation));

			this.battle.field.ElectricTerrain = 0;
			this.battle.field.MistyTerrain = 0;
			this.battle.field.GrassyTerrain = 5;
			_host.StartCoroutine(battle.Display(Game._INTL("Grass grew to cover the battlefield!")));
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// For 5 rounds, creates a misty terrain which weakens Dragon-type moves and
	/// protects Pokémon from status problems. Affects non-airborne Pokémon only.
	/// (Misty Terrain)
	/// <summary>
	public partial class PokeBattle_Move_156 : PokeBattle_Move
	{
		public PokeBattle_Move_156() : base() { }
		//public PokeBattle_Move_156(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (this.battle.field.MistyTerrain > 0)
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			_host.StartCoroutine(ShowAnimation(this.id, attacker, null, hitnum, alltargets, showanimation));

			this.battle.field.ElectricTerrain = 0;
			this.battle.field.GrassyTerrain = 0;
			this.battle.field.MistyTerrain = 5;
			_host.StartCoroutine(battle.Display(Game._INTL("Mist swirled about the battlefield!")));
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// Doubles the prize money the player gets after winning the battle. (Happy Hour)
	/// </summary>
	public partial class PokeBattle_Move_157 : PokeBattle_Move
	{
		public PokeBattle_Move_157() : base() { }
		//public PokeBattle_Move_157(Battle battle, Attack.Move move) : base(battle, move) { }
		public override int GetEffect(IBattler attacker, IBattler opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true) { int r = -1; this.GetEffect(attacker, opponent, hitnum, alltargets, showanimation); return r; }
		public override IEnumerator GetEffect(IBattlerIE attacker, IBattlerIE opponent, int hitnum = 0, int[] alltargets = null, bool showanimation = true, System.Action<int> result=null)
		{
			if (this.battle.IsOpposing(attacker.Index) || this.battle.doublemoney)
			{
				_host.StartCoroutine(battle.Display(Game._INTL("But it failed!")));
				result(-1);
				yield break;
			}
			_host.StartCoroutine(ShowAnimation(this.id, attacker, null, hitnum, alltargets, showanimation));

			this.battle.doublemoney = true;
			_host.StartCoroutine(battle.Display(Game._INTL("Everyone is caught up in the happy atmosphere!")));
			result(0);
			yield break;
		}
	}

	/// <summary>
	/// Fails unless user has consumed a berry at some point. (Belch)
	/// </summary>
	public partial class PokeBattle_Move_158 : PokeBattle_Move
	{
		public PokeBattle_Move_158() : base() { }
		//public PokeBattle_Move_158(Battle battle, Attack.Move move) : base(battle, move) { }
		public override bool MoveFailed(IBattler attacker, IBattler opponent)
		{
			return attacker.Species == Pokemons.NONE || !attacker.pokemon.belch;
		}
	}
	#endregion
#pragma warning restore 0162 //Warning CS0162  Unreachable code detected
	//===============================================================================
	// NOTE: If you're inventing new move effects, use function code 159 and onwards.
	//===============================================================================
}