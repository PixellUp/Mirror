(module
  (type (;0;) (func (param i32 i64 i32 i32)))
  (type (;1;) (func (param i32 i64 i64 i32 i32)))
  (type (;2;) (func))
  (type (;3;) (func (param i32 i32)))
  (type (;4;) (func (param i64 i64 i64 i64) (result i32)))
  (type (;5;) (func (param i64)))
  (type (;6;) (func (result i64)))
  (type (;7;) (func (param i32 i32 i32) (result i32)))
  (type (;8;) (func (param i64 i64 i64 i64 i32 i32) (result i32)))
  (type (;9;) (func (param i64) (result i32)))
  (type (;10;) (func (param i32)))
  (type (;11;) (func (result i32)))
  (type (;12;) (func (param i32 i32) (result i32)))
  (type (;13;) (func (param i32 i64 i64 i64 i64)))
  (type (;14;) (func (param i64 i64) (result i32)))
  (type (;15;) (func (param i32 f64)))
  (type (;16;) (func (param i32 f32)))
  (type (;17;) (func (param i64 i64) (result f64)))
  (type (;18;) (func (param i64 i64) (result f32)))
  (type (;19;) (func (param i32 i64 i32 i64)))
  (type (;20;) (func (param i64 i64 i32 i32)))
  (type (;21;) (func (param i32 i32 i32 i32)))
  (type (;22;) (func (param i32 i64 i32) (result i32)))
  (type (;23;) (func (param i32 i64 i32)))
  (type (;24;) (func (param i64 i64 i64)))
  (type (;25;) (func (param i32) (result i32)))
  (type (;26;) (func (param i32 i32 i32 i32 i32 i32 i32 i32)))
  (import "env" "eosio_assert" (func (;0;) (type 3)))
  (import "env" "db_find_i64" (func (;1;) (type 4)))
  (import "env" "require_auth" (func (;2;) (type 5)))
  (import "env" "current_receiver" (func (;3;) (type 6)))
  (import "env" "db_update_i64" (func (;4;) (type 0)))
  (import "env" "memcpy" (func (;5;) (type 7)))
  (import "env" "db_store_i64" (func (;6;) (type 8)))
  (import "env" "is_account" (func (;7;) (type 9)))
  (import "env" "require_recipient" (func (;8;) (type 5)))
  (import "env" "db_remove_i64" (func (;9;) (type 10)))
  (import "env" "action_data_size" (func (;10;) (type 11)))
  (import "env" "read_action_data" (func (;11;) (type 12)))
  (import "env" "db_get_i64" (func (;12;) (type 7)))
  (import "env" "send_inline" (func (;13;) (type 3)))
  (import "env" "abort" (func (;14;) (type 2)))
  (import "env" "memset" (func (;15;) (type 7)))
  (import "env" "memmove" (func (;16;) (type 7)))
  (import "env" "__unordtf2" (func (;17;) (type 4)))
  (import "env" "__eqtf2" (func (;18;) (type 4)))
  (import "env" "__multf3" (func (;19;) (type 13)))
  (import "env" "__addtf3" (func (;20;) (type 13)))
  (import "env" "__subtf3" (func (;21;) (type 13)))
  (import "env" "__netf2" (func (;22;) (type 4)))
  (import "env" "__fixunstfsi" (func (;23;) (type 14)))
  (import "env" "__floatunsitf" (func (;24;) (type 3)))
  (import "env" "__fixtfsi" (func (;25;) (type 14)))
  (import "env" "__floatsitf" (func (;26;) (type 3)))
  (import "env" "__extenddftf2" (func (;27;) (type 15)))
  (import "env" "__extendsftf2" (func (;28;) (type 16)))
  (import "env" "__divtf3" (func (;29;) (type 13)))
  (import "env" "__letf2" (func (;30;) (type 4)))
  (import "env" "__trunctfdf2" (func (;31;) (type 17)))
  (import "env" "__getf2" (func (;32;) (type 4)))
  (import "env" "__trunctfsf2" (func (;33;) (type 18)))
  (import "env" "set_blockchain_parameters_packed" (func (;34;) (type 3)))
  (import "env" "get_blockchain_parameters_packed" (func (;35;) (type 12)))
  (func (;36;) (type 2))
  (func (;37;) (type 0) (param i32 i64 i32 i32)
    (local i32 i32 i64 i64 i64 i64 i32 i32 i32 i32)
    get_global 0
    i32.const 224
    i32.sub
    tee_local 4
    set_global 0
    i32.const 0
    set_local 5
    get_local 2
    i64.load offset=8
    tee_local 6
    i64.const 8
    i64.shr_u
    tee_local 7
    set_local 8
    block  ;; label = @1
      block  ;; label = @2
        loop  ;; label = @3
          get_local 8
          i32.wrap/i64
          i32.const 24
          i32.shl
          i32.const -1073741825
          i32.add
          i32.const 452984830
          i32.gt_u
          br_if 1 (;@2;)
          get_local 8
          i64.const 8
          i64.shr_u
          set_local 9
          block  ;; label = @4
            get_local 8
            i64.const 65280
            i64.and
            i64.const 0
            i64.eq
            br_if 0 (;@4;)
            get_local 9
            set_local 8
            i32.const 1
            set_local 10
            get_local 5
            tee_local 11
            i32.const 1
            i32.add
            set_local 5
            get_local 11
            i32.const 6
            i32.lt_s
            br_if 1 (;@3;)
            br 3 (;@1;)
          end
          get_local 9
          set_local 8
          loop  ;; label = @4
            get_local 8
            i64.const 65280
            i64.and
            i64.const 0
            i64.ne
            br_if 2 (;@2;)
            get_local 8
            i64.const 8
            i64.shr_u
            set_local 8
            get_local 5
            i32.const 6
            i32.lt_s
            set_local 10
            get_local 5
            i32.const 1
            i32.add
            tee_local 11
            set_local 5
            get_local 10
            br_if 0 (;@4;)
          end
          i32.const 1
          set_local 10
          get_local 11
          i32.const 1
          i32.add
          set_local 5
          get_local 11
          i32.const 6
          i32.lt_s
          br_if 0 (;@3;)
          br 2 (;@1;)
        end
      end
      i32.const 0
      set_local 10
    end
    get_local 10
    i32.const 8192
    call 0
    block  ;; label = @1
      block  ;; label = @2
        get_local 3
        i32.load8_u
        tee_local 5
        i32.const 1
        i32.and
        br_if 0 (;@2;)
        get_local 5
        i32.const 1
        i32.shr_u
        set_local 5
        br 1 (;@1;)
      end
      get_local 3
      i32.load offset=4
      set_local 5
    end
    get_local 5
    i32.const 257
    i32.lt_u
    i32.const 8212
    call 0
    i32.const 0
    set_local 10
    get_local 4
    i32.const 88
    i32.add
    i32.const 32
    i32.add
    i32.const 0
    i32.store
    get_local 4
    i64.const -1
    i64.store offset=104
    get_local 4
    i64.const 0
    i64.store offset=112
    get_local 4
    get_local 0
    i64.load
    tee_local 8
    i64.store offset=88
    get_local 4
    get_local 7
    i64.store offset=96
    i32.const 0
    set_local 11
    block  ;; label = @1
      get_local 8
      get_local 7
      i64.const -4157508551318700032
      get_local 7
      call 1
      tee_local 5
      i32.const 0
      i32.lt_s
      br_if 0 (;@1;)
      get_local 4
      i32.const 88
      i32.add
      get_local 5
      call 38
      tee_local 11
      i32.load offset=40
      get_local 4
      i32.const 88
      i32.add
      i32.eq
      i32.const 8656
      call 0
    end
    get_local 11
    i32.const 0
    i32.ne
    i32.const 8313
    call 0
    get_local 11
    i64.load offset=32
    call 2
    get_local 11
    i32.const 32
    i32.add
    set_local 12
    block  ;; label = @1
      get_local 2
      i64.load
      tee_local 8
      i64.const 4611686018427387903
      i64.add
      i64.const 9223372036854775806
      i64.gt_u
      br_if 0 (;@1;)
      i32.const 0
      set_local 5
      block  ;; label = @2
        loop  ;; label = @3
          get_local 7
          i32.wrap/i64
          i32.const 24
          i32.shl
          i32.const -1073741825
          i32.add
          i32.const 452984830
          i32.gt_u
          br_if 1 (;@2;)
          get_local 7
          i64.const 8
          i64.shr_u
          set_local 9
          block  ;; label = @4
            get_local 7
            i64.const 65280
            i64.and
            i64.const 0
            i64.eq
            br_if 0 (;@4;)
            get_local 9
            set_local 7
            i32.const 1
            set_local 10
            get_local 5
            tee_local 13
            i32.const 1
            i32.add
            set_local 5
            get_local 13
            i32.const 6
            i32.lt_s
            br_if 1 (;@3;)
            br 3 (;@1;)
          end
          get_local 9
          set_local 7
          loop  ;; label = @4
            get_local 7
            i64.const 65280
            i64.and
            i64.const 0
            i64.ne
            br_if 2 (;@2;)
            get_local 7
            i64.const 8
            i64.shr_u
            set_local 7
            get_local 5
            i32.const 6
            i32.lt_s
            set_local 10
            get_local 5
            i32.const 1
            i32.add
            tee_local 13
            set_local 5
            get_local 10
            br_if 0 (;@4;)
          end
          i32.const 1
          set_local 10
          get_local 13
          i32.const 1
          i32.add
          set_local 5
          get_local 13
          i32.const 6
          i32.lt_s
          br_if 0 (;@3;)
          br 2 (;@1;)
        end
      end
      i32.const 0
      set_local 10
    end
    get_local 8
    i64.const 0
    i64.gt_s
    get_local 10
    i32.and
    i32.const 8335
    call 0
    get_local 6
    get_local 11
    i64.load offset=8
    i64.eq
    i32.const 8352
    call 0
    get_local 8
    get_local 11
    i64.load offset=16
    get_local 11
    i64.load
    i64.sub
    i64.le_s
    i32.const 8378
    call 0
    get_local 11
    i32.load offset=40
    get_local 4
    i32.const 88
    i32.add
    i32.eq
    i32.const 8735
    call 0
    get_local 4
    i64.load offset=88
    call 3
    i64.eq
    i32.const 8781
    call 0
    get_local 6
    get_local 11
    i64.load offset=8
    tee_local 7
    i64.eq
    i32.const 8891
    call 0
    get_local 11
    get_local 11
    i64.load
    get_local 8
    i64.add
    tee_local 8
    i64.store
    get_local 8
    i64.const -4611686018427387904
    i64.gt_s
    i32.const 8934
    call 0
    get_local 11
    i64.load
    i64.const 4611686018427387904
    i64.lt_s
    i32.const 8953
    call 0
    get_local 7
    i64.const 8
    i64.shr_u
    tee_local 8
    get_local 11
    i64.load offset=8
    i64.const 8
    i64.shr_u
    i64.eq
    i32.const 8832
    call 0
    get_local 4
    get_local 4
    i32.const 128
    i32.add
    i32.const 40
    i32.add
    i32.store offset=192
    get_local 4
    get_local 4
    i32.const 128
    i32.add
    i32.store offset=188
    get_local 4
    get_local 4
    i32.const 128
    i32.add
    i32.store offset=184
    get_local 4
    get_local 4
    i32.const 184
    i32.add
    i32.store offset=200
    get_local 4
    get_local 11
    i32.const 16
    i32.add
    i32.store offset=212
    get_local 4
    get_local 11
    i32.store offset=208
    get_local 4
    get_local 12
    i32.store offset=216
    get_local 4
    i32.const 208
    i32.add
    get_local 4
    i32.const 200
    i32.add
    call 39
    get_local 11
    i32.load offset=44
    i64.const 0
    get_local 4
    i32.const 128
    i32.add
    i32.const 40
    call 4
    block  ;; label = @1
      get_local 8
      get_local 4
      i32.const 88
      i32.add
      i32.const 16
      i32.add
      tee_local 5
      i64.load
      i64.lt_u
      br_if 0 (;@1;)
      get_local 5
      get_local 8
      i64.const 1
      i64.add
      i64.store
    end
    get_local 4
    i32.const 72
    i32.add
    i32.const 8
    i32.add
    get_local 2
    i32.const 8
    i32.add
    i64.load
    tee_local 9
    i64.store
    get_local 12
    i64.load
    set_local 8
    get_local 2
    i64.load
    set_local 7
    get_local 4
    i32.const 8
    i32.add
    i32.const 8
    i32.add
    get_local 9
    i64.store
    get_local 4
    get_local 7
    i64.store offset=72
    get_local 4
    get_local 7
    i64.store offset=8
    get_local 0
    get_local 8
    get_local 4
    i32.const 8
    i32.add
    get_local 8
    call 40
    block  ;; label = @1
      get_local 12
      i64.load
      tee_local 7
      get_local 1
      i64.eq
      br_if 0 (;@1;)
      get_local 0
      i64.load
      set_local 9
      i64.const 6
      set_local 8
      loop  ;; label = @2
        get_local 8
        i64.const 1
        i64.add
        tee_local 8
        i64.const 13
        i64.ne
        br_if 0 (;@2;)
      end
      get_local 4
      i32.const 24
      i32.add
      i32.const 24
      i32.add
      tee_local 10
      get_local 2
      i32.const 8
      i32.add
      i64.load
      i64.store
      get_local 4
      get_local 1
      i64.store offset=32
      get_local 4
      get_local 7
      i64.store offset=24
      get_local 4
      get_local 2
      i64.load
      i64.store offset=40
      get_local 4
      i32.const 56
      i32.add
      get_local 3
      call 77
      drop
      i32.const 16
      call 72
      tee_local 5
      get_local 7
      i64.store
      get_local 5
      i64.const 3617214756542218240
      i64.store offset=8
      get_local 4
      i32.const 128
      i32.add
      i32.const 24
      i32.add
      get_local 10
      i64.load
      i64.store
      get_local 4
      i32.const 128
      i32.add
      i32.const 40
      i32.add
      tee_local 11
      get_local 4
      i32.const 24
      i32.add
      i32.const 40
      i32.add
      tee_local 10
      i32.load
      i32.store
      get_local 10
      i32.const 0
      i32.store
      get_local 4
      get_local 5
      i32.store offset=208
      get_local 4
      get_local 5
      i32.const 16
      i32.add
      tee_local 5
      i32.store offset=216
      get_local 4
      get_local 5
      i32.store offset=212
      get_local 4
      get_local 4
      i64.load offset=24
      i64.store offset=128
      get_local 4
      get_local 4
      i64.load offset=32
      i64.store offset=136
      get_local 4
      get_local 4
      i64.load offset=40
      i64.store offset=144
      get_local 4
      get_local 4
      i64.load offset=56
      i64.store offset=160
      get_local 4
      i64.const 0
      i64.store offset=56
      get_local 9
      i64.const -3617168760277827584
      get_local 4
      i32.const 208
      i32.add
      get_local 4
      i32.const 128
      i32.add
      call 41
      block  ;; label = @2
        get_local 4
        i32.load8_u offset=160
        i32.const 1
        i32.and
        i32.eqz
        br_if 0 (;@2;)
        get_local 11
        i32.load
        call 74
      end
      block  ;; label = @2
        get_local 4
        i32.load offset=208
        tee_local 5
        i32.eqz
        br_if 0 (;@2;)
        get_local 4
        get_local 5
        i32.store offset=212
        get_local 5
        call 74
      end
      get_local 4
      i32.const 56
      i32.add
      i32.load8_u
      i32.const 1
      i32.and
      i32.eqz
      br_if 0 (;@1;)
      get_local 4
      i32.const 64
      i32.add
      i32.load
      call 74
    end
    block  ;; label = @1
      get_local 4
      i32.load offset=112
      tee_local 11
      i32.eqz
      br_if 0 (;@1;)
      block  ;; label = @2
        block  ;; label = @3
          get_local 4
          i32.const 116
          i32.add
          tee_local 13
          i32.load
          tee_local 5
          get_local 11
          i32.eq
          br_if 0 (;@3;)
          loop  ;; label = @4
            get_local 5
            i32.const -24
            i32.add
            tee_local 5
            i32.load
            set_local 10
            get_local 5
            i32.const 0
            i32.store
            block  ;; label = @5
              get_local 10
              i32.eqz
              br_if 0 (;@5;)
              get_local 10
              call 74
            end
            get_local 11
            get_local 5
            i32.ne
            br_if 0 (;@4;)
          end
          get_local 4
          i32.const 112
          i32.add
          i32.load
          set_local 5
          br 1 (;@2;)
        end
        get_local 11
        set_local 5
      end
      get_local 13
      get_local 11
      i32.store
      get_local 5
      call 74
    end
    get_local 4
    i32.const 224
    i32.add
    set_global 0)
  (func (;38;) (type 12) (param i32 i32) (result i32)
    (local i32 i32 i32 i32 i64 i32 i32)
    get_global 0
    i32.const 48
    i32.sub
    tee_local 2
    set_local 3
    get_local 2
    set_global 0
    block  ;; label = @1
      get_local 0
      i32.load offset=24
      tee_local 4
      get_local 0
      i32.const 28
      i32.add
      i32.load
      tee_local 5
      i32.eq
      br_if 0 (;@1;)
      block  ;; label = @2
        loop  ;; label = @3
          get_local 5
          i32.const -8
          i32.add
          i32.load
          get_local 1
          i32.eq
          br_if 1 (;@2;)
          get_local 4
          get_local 5
          i32.const -24
          i32.add
          tee_local 5
          i32.ne
          br_if 0 (;@3;)
          br 2 (;@1;)
        end
      end
      get_local 4
      get_local 5
      i32.eq
      br_if 0 (;@1;)
      get_local 5
      i32.const -24
      i32.add
      i32.load
      set_local 5
      get_local 3
      i32.const 48
      i32.add
      set_global 0
      get_local 5
      return
    end
    get_local 1
    i32.const 0
    i32.const 0
    call 12
    tee_local 4
    i32.const 31
    i32.shr_u
    i32.const 1
    i32.xor
    i32.const 8707
    call 0
    block  ;; label = @1
      block  ;; label = @2
        get_local 4
        i32.const 513
        i32.lt_u
        br_if 0 (;@2;)
        get_local 4
        call 83
        set_local 2
        br 1 (;@1;)
      end
      get_local 2
      get_local 4
      i32.const 15
      i32.add
      i32.const -16
      i32.and
      i32.sub
      tee_local 2
      set_global 0
    end
    get_local 1
    get_local 2
    get_local 4
    call 12
    drop
    get_local 3
    get_local 2
    i32.store offset=12
    get_local 3
    get_local 2
    i32.store offset=8
    get_local 3
    get_local 2
    get_local 4
    i32.add
    i32.store offset=16
    i32.const 56
    call 72
    tee_local 5
    call 61
    drop
    get_local 5
    get_local 0
    i32.store offset=40
    get_local 3
    get_local 3
    i32.const 8
    i32.add
    i32.store offset=24
    get_local 3
    get_local 5
    i32.const 16
    i32.add
    i32.store offset=36
    get_local 3
    get_local 5
    i32.store offset=32
    get_local 3
    get_local 5
    i32.const 32
    i32.add
    i32.store offset=40
    get_local 3
    i32.const 32
    i32.add
    get_local 3
    i32.const 24
    i32.add
    call 62
    get_local 5
    get_local 1
    i32.store offset=44
    get_local 3
    get_local 5
    i32.store offset=24
    get_local 3
    get_local 5
    i64.load offset=8
    i64.const 8
    i64.shr_u
    tee_local 6
    i64.store offset=32
    get_local 3
    get_local 1
    i32.store offset=4
    block  ;; label = @1
      block  ;; label = @2
        block  ;; label = @3
          get_local 0
          i32.const 28
          i32.add
          tee_local 7
          i32.load
          tee_local 8
          get_local 0
          i32.const 32
          i32.add
          i32.load
          i32.ge_u
          br_if 0 (;@3;)
          get_local 8
          get_local 6
          i64.store offset=8
          get_local 8
          get_local 1
          i32.store offset=16
          get_local 3
          i32.const 0
          i32.store offset=24
          get_local 8
          get_local 5
          i32.store
          get_local 7
          get_local 8
          i32.const 24
          i32.add
          i32.store
          get_local 4
          i32.const 513
          i32.ge_u
          br_if 1 (;@2;)
          br 2 (;@1;)
        end
        get_local 0
        i32.const 24
        i32.add
        get_local 3
        i32.const 24
        i32.add
        get_local 3
        i32.const 32
        i32.add
        get_local 3
        i32.const 4
        i32.add
        call 63
        get_local 4
        i32.const 513
        i32.lt_u
        br_if 1 (;@1;)
      end
      get_local 2
      call 86
    end
    get_local 3
    i32.load offset=24
    set_local 1
    get_local 3
    i32.const 0
    i32.store offset=24
    block  ;; label = @1
      get_local 1
      i32.eqz
      br_if 0 (;@1;)
      get_local 1
      call 74
    end
    get_local 3
    i32.const 48
    i32.add
    set_global 0
    get_local 5)
  (func (;39;) (type 3) (param i32 i32)
    (local i32 i32 i32)
    get_local 0
    i32.load
    set_local 2
    get_local 1
    i32.load
    tee_local 3
    i32.load offset=8
    get_local 3
    i32.load offset=4
    i32.sub
    i32.const 7
    i32.gt_s
    i32.const 8971
    call 0
    get_local 3
    i32.load offset=4
    get_local 2
    i32.const 8
    call 5
    drop
    get_local 3
    get_local 3
    i32.load offset=4
    i32.const 8
    i32.add
    tee_local 4
    i32.store offset=4
    get_local 3
    i32.load offset=8
    get_local 4
    i32.sub
    i32.const 7
    i32.gt_s
    i32.const 8971
    call 0
    get_local 3
    i32.load offset=4
    get_local 2
    i32.const 8
    i32.add
    i32.const 8
    call 5
    drop
    get_local 3
    get_local 3
    i32.load offset=4
    i32.const 8
    i32.add
    i32.store offset=4
    get_local 0
    i32.load offset=4
    set_local 2
    get_local 1
    i32.load
    tee_local 3
    i32.load offset=8
    get_local 3
    i32.load offset=4
    i32.sub
    i32.const 7
    i32.gt_s
    i32.const 8971
    call 0
    get_local 3
    i32.load offset=4
    get_local 2
    i32.const 8
    call 5
    drop
    get_local 3
    get_local 3
    i32.load offset=4
    i32.const 8
    i32.add
    tee_local 4
    i32.store offset=4
    get_local 3
    i32.load offset=8
    get_local 4
    i32.sub
    i32.const 7
    i32.gt_s
    i32.const 8971
    call 0
    get_local 3
    i32.load offset=4
    get_local 2
    i32.const 8
    i32.add
    i32.const 8
    call 5
    drop
    get_local 3
    get_local 3
    i32.load offset=4
    i32.const 8
    i32.add
    i32.store offset=4
    get_local 0
    i32.load offset=8
    set_local 0
    get_local 1
    i32.load
    tee_local 3
    i32.load offset=8
    get_local 3
    i32.load offset=4
    i32.sub
    i32.const 7
    i32.gt_s
    i32.const 8971
    call 0
    get_local 3
    i32.load offset=4
    get_local 0
    i32.const 8
    call 5
    drop
    get_local 3
    get_local 3
    i32.load offset=4
    i32.const 8
    i32.add
    i32.store offset=4)
  (func (;40;) (type 19) (param i32 i64 i32 i64)
    (local i32 i32 i64 i64 i32 i32 i32 i32)
    get_global 0
    i32.const 80
    i32.sub
    tee_local 4
    set_global 0
    i32.const 0
    set_local 5
    get_local 4
    i32.const 8
    i32.add
    i32.const 32
    i32.add
    i32.const 0
    i32.store
    get_local 4
    i64.const -1
    i64.store offset=24
    get_local 4
    i64.const 0
    i64.store offset=32
    get_local 4
    get_local 0
    i64.load
    tee_local 6
    i64.store offset=8
    get_local 2
    i64.load offset=8
    set_local 7
    get_local 4
    get_local 1
    i64.store offset=16
    block  ;; label = @1
      block  ;; label = @2
        block  ;; label = @3
          block  ;; label = @4
            get_local 6
            get_local 1
            i64.const 3607749779137757184
            get_local 7
            i64.const 8
            i64.shr_u
            call 1
            tee_local 0
            i32.const 0
            i32.lt_s
            br_if 0 (;@4;)
            get_local 4
            i32.const 8
            i32.add
            get_local 0
            call 42
            tee_local 5
            i32.load offset=16
            get_local 4
            i32.const 8
            i32.add
            i32.eq
            i32.const 8656
            call 0
            i32.const 1
            i32.const 9267
            call 0
            get_local 5
            i32.load offset=16
            get_local 4
            i32.const 8
            i32.add
            i32.eq
            i32.const 8735
            call 0
            get_local 4
            i64.load offset=8
            call 3
            i64.eq
            i32.const 8781
            call 0
            get_local 7
            get_local 5
            i64.load offset=8
            tee_local 1
            i64.eq
            i32.const 8891
            call 0
            get_local 5
            get_local 5
            i64.load
            get_local 2
            i64.load
            i64.add
            tee_local 7
            i64.store
            get_local 7
            i64.const -4611686018427387904
            i64.gt_s
            i32.const 8934
            call 0
            get_local 5
            i64.load
            i64.const 4611686018427387904
            i64.lt_s
            i32.const 8953
            call 0
            get_local 1
            i64.const 8
            i64.shr_u
            tee_local 1
            get_local 5
            i64.load offset=8
            i64.const 8
            i64.shr_u
            i64.eq
            i32.const 8832
            call 0
            i32.const 1
            i32.const 8971
            call 0
            get_local 4
            i32.const 64
            i32.add
            get_local 5
            i32.const 8
            call 5
            drop
            i32.const 1
            i32.const 8971
            call 0
            get_local 4
            i32.const 64
            i32.add
            i32.const 8
            i32.or
            get_local 5
            i32.const 8
            i32.add
            i32.const 8
            call 5
            drop
            get_local 5
            i32.load offset=20
            i64.const 0
            get_local 4
            i32.const 64
            i32.add
            i32.const 16
            call 4
            get_local 1
            get_local 4
            i32.const 8
            i32.add
            i32.const 16
            i32.add
            tee_local 5
            i64.load
            i64.lt_u
            br_if 1 (;@3;)
            get_local 5
            get_local 1
            i64.const 1
            i64.add
            i64.store
            get_local 4
            i32.load offset=32
            tee_local 8
            br_if 2 (;@2;)
            br 3 (;@1;)
          end
          get_local 6
          call 3
          i64.eq
          i32.const 9216
          call 0
          i32.const 32
          call 72
          tee_local 9
          i64.const 1398362884
          i64.store offset=8
          get_local 9
          i64.const 0
          i64.store
          i32.const 1
          i32.const 8607
          call 0
          get_local 9
          i32.const 8
          i32.add
          set_local 10
          i64.const 5462355
          set_local 1
          block  ;; label = @4
            loop  ;; label = @5
              i32.const 0
              set_local 11
              get_local 1
              i32.wrap/i64
              i32.const 24
              i32.shl
              i32.const -1073741825
              i32.add
              i32.const 452984830
              i32.gt_u
              br_if 1 (;@4;)
              get_local 1
              i64.const 8
              i64.shr_u
              set_local 7
              block  ;; label = @6
                get_local 1
                i64.const 65280
                i64.and
                i64.const 0
                i64.eq
                br_if 0 (;@6;)
                get_local 7
                set_local 1
                i32.const 1
                set_local 11
                get_local 5
                tee_local 0
                i32.const 1
                i32.add
                set_local 5
                get_local 0
                i32.const 6
                i32.lt_s
                br_if 1 (;@5;)
                br 2 (;@4;)
              end
              get_local 7
              set_local 1
              loop  ;; label = @6
                get_local 1
                i64.const 65280
                i64.and
                i64.const 0
                i64.ne
                br_if 2 (;@4;)
                get_local 1
                i64.const 8
                i64.shr_u
                set_local 1
                get_local 5
                i32.const 6
                i32.lt_s
                set_local 0
                get_local 5
                i32.const 1
                i32.add
                tee_local 8
                set_local 5
                get_local 0
                br_if 0 (;@6;)
              end
              i32.const 1
              set_local 11
              get_local 8
              i32.const 1
              i32.add
              set_local 5
              get_local 8
              i32.const 6
              i32.lt_s
              br_if 0 (;@5;)
            end
          end
          get_local 11
          i32.const 8192
          call 0
          get_local 9
          get_local 4
          i32.const 8
          i32.add
          i32.store offset=16
          get_local 9
          i32.const 8
          i32.add
          tee_local 5
          get_local 2
          i32.const 8
          i32.add
          i64.load
          i64.store
          get_local 9
          get_local 2
          i64.load
          i64.store
          i32.const 1
          i32.const 8971
          call 0
          get_local 4
          i32.const 64
          i32.add
          get_local 9
          i32.const 8
          call 5
          drop
          i32.const 1
          i32.const 8971
          call 0
          get_local 4
          i32.const 64
          i32.add
          i32.const 8
          i32.or
          get_local 10
          i32.const 8
          call 5
          drop
          get_local 9
          get_local 4
          i32.const 8
          i32.add
          i32.const 8
          i32.add
          i64.load
          i64.const 3607749779137757184
          get_local 3
          get_local 5
          i64.load
          i64.const 8
          i64.shr_u
          tee_local 1
          get_local 4
          i32.const 64
          i32.add
          i32.const 16
          call 6
          tee_local 0
          i32.store offset=20
          block  ;; label = @4
            get_local 1
            get_local 4
            i32.const 8
            i32.add
            i32.const 16
            i32.add
            tee_local 8
            i64.load
            i64.lt_u
            br_if 0 (;@4;)
            get_local 8
            get_local 1
            i64.const 1
            i64.add
            i64.store
          end
          get_local 4
          get_local 9
          i32.store offset=56
          get_local 4
          get_local 5
          i64.load
          i64.const 8
          i64.shr_u
          tee_local 1
          i64.store offset=64
          get_local 4
          get_local 0
          i32.store offset=52
          block  ;; label = @4
            block  ;; label = @5
              get_local 4
              i32.const 36
              i32.add
              tee_local 8
              i32.load
              tee_local 5
              get_local 4
              i32.const 40
              i32.add
              i32.load
              i32.ge_u
              br_if 0 (;@5;)
              get_local 5
              get_local 1
              i64.store offset=8
              get_local 5
              get_local 0
              i32.store offset=16
              get_local 4
              i32.const 0
              i32.store offset=56
              get_local 5
              get_local 9
              i32.store
              get_local 8
              get_local 5
              i32.const 24
              i32.add
              i32.store
              get_local 4
              i32.load offset=56
              set_local 5
              get_local 4
              i32.const 0
              i32.store offset=56
              get_local 5
              br_if 1 (;@4;)
              br 2 (;@3;)
            end
            get_local 4
            i32.const 32
            i32.add
            get_local 4
            i32.const 56
            i32.add
            get_local 4
            i32.const 64
            i32.add
            get_local 4
            i32.const 52
            i32.add
            call 43
            get_local 4
            i32.load offset=56
            set_local 5
            get_local 4
            i32.const 0
            i32.store offset=56
            get_local 5
            i32.eqz
            br_if 1 (;@3;)
          end
          get_local 5
          call 74
        end
        get_local 4
        i32.load offset=32
        tee_local 8
        i32.eqz
        br_if 1 (;@1;)
      end
      block  ;; label = @2
        block  ;; label = @3
          get_local 4
          i32.const 36
          i32.add
          tee_local 9
          i32.load
          tee_local 5
          get_local 8
          i32.eq
          br_if 0 (;@3;)
          loop  ;; label = @4
            get_local 5
            i32.const -24
            i32.add
            tee_local 5
            i32.load
            set_local 0
            get_local 5
            i32.const 0
            i32.store
            block  ;; label = @5
              get_local 0
              i32.eqz
              br_if 0 (;@5;)
              get_local 0
              call 74
            end
            get_local 8
            get_local 5
            i32.ne
            br_if 0 (;@4;)
          end
          get_local 4
          i32.const 32
          i32.add
          i32.load
          set_local 5
          br 1 (;@2;)
        end
        get_local 8
        set_local 5
      end
      get_local 9
      get_local 8
      i32.store
      get_local 5
      call 74
    end
    get_local 4
    i32.const 80
    i32.add
    set_global 0)
  (func (;41;) (type 20) (param i64 i64 i32 i32)
    (local i32 i32 i32 i32 i32)
    get_global 0
    i32.const 96
    i32.sub
    tee_local 4
    set_global 0
    get_local 4
    i32.const 0
    i32.store offset=16
    get_local 4
    i64.const 0
    i64.store offset=8
    i32.const 0
    set_local 5
    i32.const 0
    set_local 6
    i32.const 0
    set_local 7
    block  ;; label = @1
      block  ;; label = @2
        get_local 2
        i32.load offset=4
        get_local 2
        i32.load
        i32.sub
        tee_local 8
        i32.eqz
        br_if 0 (;@2;)
        get_local 8
        i32.const 4
        i32.shr_s
        tee_local 5
        i32.const 268435456
        i32.ge_u
        br_if 1 (;@1;)
        get_local 4
        i32.const 16
        i32.add
        get_local 8
        call 72
        tee_local 7
        get_local 5
        i32.const 4
        i32.shl
        i32.add
        tee_local 5
        i32.store
        get_local 4
        get_local 7
        i32.store offset=8
        get_local 4
        get_local 7
        i32.store offset=12
        block  ;; label = @3
          get_local 2
          i32.const 4
          i32.add
          i32.load
          get_local 2
          i32.load
          tee_local 6
          i32.sub
          tee_local 2
          i32.const 1
          i32.lt_s
          br_if 0 (;@3;)
          get_local 7
          get_local 6
          get_local 2
          call 5
          drop
          get_local 4
          get_local 7
          get_local 2
          i32.add
          tee_local 6
          i32.store offset=12
          br 1 (;@2;)
        end
        get_local 7
        set_local 6
      end
      get_local 4
      i32.const 44
      i32.add
      get_local 6
      i32.store
      get_local 4
      i32.const 48
      i32.add
      get_local 5
      i32.store
      get_local 4
      i32.const 16
      i32.add
      i32.const 0
      i32.store
      get_local 4
      i32.const 24
      i32.add
      i32.const 36
      i32.add
      i32.const 0
      i32.store
      get_local 4
      get_local 1
      i64.store offset=32
      get_local 4
      get_local 0
      i64.store offset=24
      get_local 4
      get_local 7
      i32.store offset=40
      get_local 4
      i64.const 0
      i64.store offset=8
      get_local 4
      i64.const 0
      i64.store offset=52 align=4
      get_local 3
      i32.const 36
      i32.add
      i32.load
      get_local 3
      i32.load8_u offset=32
      tee_local 7
      i32.const 1
      i32.shr_u
      get_local 7
      i32.const 1
      i32.and
      select
      tee_local 2
      i32.const 32
      i32.add
      set_local 7
      get_local 2
      i64.extend_u/i32
      set_local 0
      get_local 4
      i32.const 52
      i32.add
      set_local 2
      loop  ;; label = @2
        get_local 7
        i32.const 1
        i32.add
        set_local 7
        get_local 0
        i64.const 7
        i64.shr_u
        tee_local 0
        i64.const 0
        i64.ne
        br_if 0 (;@2;)
      end
      block  ;; label = @2
        block  ;; label = @3
          get_local 7
          i32.eqz
          br_if 0 (;@3;)
          get_local 2
          get_local 7
          call 64
          get_local 4
          i32.const 56
          i32.add
          i32.load
          set_local 2
          get_local 4
          i32.const 52
          i32.add
          i32.load
          set_local 7
          br 1 (;@2;)
        end
        i32.const 0
        set_local 2
        i32.const 0
        set_local 7
      end
      get_local 4
      get_local 7
      i32.store offset=84
      get_local 4
      get_local 7
      i32.store offset=80
      get_local 4
      get_local 2
      i32.store offset=88
      get_local 4
      get_local 4
      i32.const 80
      i32.add
      i32.store offset=64
      get_local 4
      get_local 3
      i32.store offset=72
      get_local 4
      i32.const 72
      i32.add
      get_local 4
      i32.const 64
      i32.add
      call 65
      get_local 4
      i32.const 80
      i32.add
      get_local 4
      i32.const 24
      i32.add
      call 66
      get_local 4
      i32.load offset=80
      tee_local 7
      get_local 4
      i32.load offset=84
      get_local 7
      i32.sub
      call 13
      block  ;; label = @2
        get_local 4
        i32.load offset=80
        tee_local 7
        i32.eqz
        br_if 0 (;@2;)
        get_local 4
        get_local 7
        i32.store offset=84
        get_local 7
        call 74
      end
      block  ;; label = @2
        get_local 4
        i32.load offset=52
        tee_local 7
        i32.eqz
        br_if 0 (;@2;)
        get_local 4
        i32.const 56
        i32.add
        get_local 7
        i32.store
        get_local 7
        call 74
      end
      block  ;; label = @2
        get_local 4
        i32.load offset=40
        tee_local 7
        i32.eqz
        br_if 0 (;@2;)
        get_local 4
        i32.const 44
        i32.add
        get_local 7
        i32.store
        get_local 7
        call 74
      end
      block  ;; label = @2
        get_local 4
        i32.load offset=8
        tee_local 7
        i32.eqz
        br_if 0 (;@2;)
        get_local 4
        get_local 7
        i32.store offset=12
        get_local 7
        call 74
      end
      get_local 4
      i32.const 96
      i32.add
      set_global 0
      return
    end
    get_local 4
    i32.const 8
    i32.add
    call 81
    unreachable)
  (func (;42;) (type 12) (param i32 i32) (result i32)
    (local i32 i32 i32 i32 i32 i64 i32 i32)
    get_global 0
    i32.const 48
    i32.sub
    tee_local 2
    set_global 0
    get_local 2
    tee_local 3
    get_local 1
    i32.store offset=44
    block  ;; label = @1
      get_local 0
      i32.load offset=24
      tee_local 4
      get_local 0
      i32.const 28
      i32.add
      i32.load
      tee_local 5
      i32.eq
      br_if 0 (;@1;)
      block  ;; label = @2
        loop  ;; label = @3
          get_local 5
          i32.const -8
          i32.add
          i32.load
          get_local 1
          i32.eq
          br_if 1 (;@2;)
          get_local 4
          get_local 5
          i32.const -24
          i32.add
          tee_local 5
          i32.ne
          br_if 0 (;@3;)
          br 2 (;@1;)
        end
      end
      get_local 4
      get_local 5
      i32.eq
      br_if 0 (;@1;)
      get_local 5
      i32.const -24
      i32.add
      i32.load
      set_local 5
      get_local 3
      i32.const 48
      i32.add
      set_global 0
      get_local 5
      return
    end
    get_local 1
    i32.const 0
    i32.const 0
    call 12
    tee_local 5
    i32.const 31
    i32.shr_u
    i32.const 1
    i32.xor
    i32.const 8707
    call 0
    block  ;; label = @1
      block  ;; label = @2
        get_local 5
        i32.const 513
        i32.lt_u
        br_if 0 (;@2;)
        get_local 5
        call 83
        set_local 4
        br 1 (;@1;)
      end
      get_local 2
      get_local 5
      i32.const 15
      i32.add
      i32.const -16
      i32.and
      i32.sub
      tee_local 4
      set_global 0
    end
    get_local 1
    get_local 4
    get_local 5
    call 12
    drop
    get_local 3
    get_local 4
    i32.store offset=36
    get_local 3
    get_local 4
    i32.store offset=32
    get_local 3
    get_local 4
    get_local 5
    i32.add
    i32.store offset=40
    get_local 3
    get_local 3
    i32.const 32
    i32.add
    i32.store offset=12
    get_local 3
    get_local 3
    i32.const 44
    i32.add
    i32.store offset=16
    get_local 3
    get_local 0
    i32.store offset=8
    i32.const 32
    call 72
    tee_local 1
    get_local 0
    get_local 3
    i32.const 8
    i32.add
    call 70
    set_local 6
    get_local 3
    get_local 1
    i32.store offset=24
    get_local 3
    get_local 1
    i64.load offset=8
    i64.const 8
    i64.shr_u
    tee_local 7
    i64.store offset=8
    get_local 3
    get_local 1
    i32.load offset=20
    tee_local 8
    i32.store offset=4
    block  ;; label = @1
      block  ;; label = @2
        block  ;; label = @3
          get_local 0
          i32.const 28
          i32.add
          tee_local 9
          i32.load
          tee_local 2
          get_local 0
          i32.const 32
          i32.add
          i32.load
          i32.ge_u
          br_if 0 (;@3;)
          get_local 2
          get_local 7
          i64.store offset=8
          get_local 2
          get_local 8
          i32.store offset=16
          get_local 3
          i32.const 0
          i32.store offset=24
          get_local 2
          get_local 1
          i32.store
          get_local 9
          get_local 2
          i32.const 24
          i32.add
          i32.store
          get_local 5
          i32.const 513
          i32.ge_u
          br_if 1 (;@2;)
          br 2 (;@1;)
        end
        get_local 0
        i32.const 24
        i32.add
        get_local 3
        i32.const 24
        i32.add
        get_local 3
        i32.const 8
        i32.add
        get_local 3
        i32.const 4
        i32.add
        call 43
        get_local 5
        i32.const 513
        i32.lt_u
        br_if 1 (;@1;)
      end
      get_local 4
      call 86
    end
    get_local 3
    i32.load offset=24
    set_local 5
    get_local 3
    i32.const 0
    i32.store offset=24
    block  ;; label = @1
      get_local 5
      i32.eqz
      br_if 0 (;@1;)
      get_local 5
      call 74
    end
    get_local 3
    i32.const 48
    i32.add
    set_global 0
    get_local 6)
  (func (;43;) (type 21) (param i32 i32 i32 i32)
    (local i32 i32 i32 i32 i32)
    block  ;; label = @1
      block  ;; label = @2
        get_local 0
        i32.load offset=4
        get_local 0
        i32.load
        tee_local 4
        i32.sub
        i32.const 24
        i32.div_s
        tee_local 5
        i32.const 1
        i32.add
        tee_local 6
        i32.const 178956971
        i32.ge_u
        br_if 0 (;@2;)
        i32.const 178956970
        set_local 7
        block  ;; label = @3
          block  ;; label = @4
            get_local 0
            i32.load offset=8
            get_local 4
            i32.sub
            i32.const 24
            i32.div_s
            tee_local 4
            i32.const 89478484
            i32.gt_u
            br_if 0 (;@4;)
            get_local 6
            get_local 4
            i32.const 1
            i32.shl
            tee_local 7
            get_local 7
            get_local 6
            i32.lt_u
            select
            tee_local 7
            i32.eqz
            br_if 1 (;@3;)
          end
          get_local 7
          i32.const 24
          i32.mul
          call 72
          set_local 4
          br 2 (;@1;)
        end
        i32.const 0
        set_local 7
        i32.const 0
        set_local 4
        br 1 (;@1;)
      end
      get_local 0
      call 81
      unreachable
    end
    get_local 1
    i32.load
    set_local 6
    get_local 1
    i32.const 0
    i32.store
    get_local 4
    get_local 5
    i32.const 24
    i32.mul
    tee_local 8
    i32.add
    tee_local 1
    get_local 6
    i32.store
    get_local 1
    get_local 2
    i64.load
    i64.store offset=8
    get_local 1
    get_local 3
    i32.load
    i32.store offset=16
    get_local 4
    get_local 7
    i32.const 24
    i32.mul
    i32.add
    set_local 5
    get_local 1
    i32.const 24
    i32.add
    set_local 6
    block  ;; label = @1
      block  ;; label = @2
        get_local 0
        i32.const 4
        i32.add
        i32.load
        tee_local 2
        get_local 0
        i32.load
        tee_local 7
        i32.eq
        br_if 0 (;@2;)
        get_local 4
        get_local 8
        i32.add
        i32.const -24
        i32.add
        set_local 1
        loop  ;; label = @3
          get_local 2
          i32.const -24
          i32.add
          tee_local 4
          i32.load
          set_local 3
          get_local 4
          i32.const 0
          i32.store
          get_local 1
          get_local 3
          i32.store
          get_local 1
          i32.const 16
          i32.add
          get_local 2
          i32.const -8
          i32.add
          i32.load
          i32.store
          get_local 1
          i32.const 8
          i32.add
          get_local 2
          i32.const -16
          i32.add
          i64.load
          i64.store
          get_local 1
          i32.const -24
          i32.add
          set_local 1
          get_local 4
          set_local 2
          get_local 7
          get_local 4
          i32.ne
          br_if 0 (;@3;)
        end
        get_local 1
        i32.const 24
        i32.add
        set_local 1
        get_local 0
        i32.const 4
        i32.add
        i32.load
        set_local 7
        get_local 0
        i32.load
        set_local 2
        br 1 (;@1;)
      end
      get_local 7
      set_local 2
    end
    get_local 0
    get_local 1
    i32.store
    get_local 0
    i32.const 4
    i32.add
    get_local 6
    i32.store
    get_local 0
    i32.const 8
    i32.add
    get_local 5
    i32.store
    block  ;; label = @1
      get_local 7
      get_local 2
      i32.eq
      br_if 0 (;@1;)
      loop  ;; label = @2
        get_local 7
        i32.const -24
        i32.add
        tee_local 7
        i32.load
        set_local 1
        get_local 7
        i32.const 0
        i32.store
        block  ;; label = @3
          get_local 1
          i32.eqz
          br_if 0 (;@3;)
          get_local 1
          call 74
        end
        get_local 2
        get_local 7
        i32.ne
        br_if 0 (;@2;)
      end
    end
    block  ;; label = @1
      get_local 2
      i32.eqz
      br_if 0 (;@1;)
      get_local 2
      call 74
    end)
  (func (;44;) (type 1) (param i32 i64 i64 i32 i32)
    (local i32 i64 i32 i64 i32 i64 i32 i64 i32 f64)
    get_global 0
    i32.const 144
    i32.sub
    tee_local 5
    set_global 0
    get_local 1
    get_local 2
    i64.ne
    i32.const 8412
    call 0
    get_local 1
    call 2
    get_local 2
    call 7
    i32.const 8424
    call 0
    get_local 3
    i64.load offset=8
    set_local 6
    i32.const 0
    set_local 7
    get_local 5
    i32.const 136
    i32.add
    i32.const 0
    i32.store
    get_local 5
    get_local 6
    i64.const 8
    i64.shr_u
    tee_local 8
    i64.store offset=112
    get_local 5
    i64.const -1
    i64.store offset=120
    get_local 5
    i64.const 0
    i64.store offset=128
    get_local 5
    get_local 0
    i64.load
    i64.store offset=104
    get_local 5
    i32.const 104
    i32.add
    get_local 8
    i32.const 8443
    call 45
    set_local 9
    get_local 1
    call 8
    get_local 2
    call 8
    block  ;; label = @1
      get_local 3
      i64.load
      tee_local 10
      i64.const 4611686018427387903
      i64.add
      i64.const 9223372036854775806
      i64.gt_u
      br_if 0 (;@1;)
      i32.const 0
      set_local 11
      block  ;; label = @2
        loop  ;; label = @3
          get_local 8
          i32.wrap/i64
          i32.const 24
          i32.shl
          i32.const -1073741825
          i32.add
          i32.const 452984830
          i32.gt_u
          br_if 1 (;@2;)
          get_local 8
          i64.const 8
          i64.shr_u
          set_local 12
          block  ;; label = @4
            get_local 8
            i64.const 65280
            i64.and
            i64.const 0
            i64.eq
            br_if 0 (;@4;)
            get_local 12
            set_local 8
            i32.const 1
            set_local 7
            get_local 11
            tee_local 13
            i32.const 1
            i32.add
            set_local 11
            get_local 13
            i32.const 6
            i32.lt_s
            br_if 1 (;@3;)
            br 3 (;@1;)
          end
          get_local 12
          set_local 8
          loop  ;; label = @4
            get_local 8
            i64.const 65280
            i64.and
            i64.const 0
            i64.ne
            br_if 2 (;@2;)
            get_local 8
            i64.const 8
            i64.shr_u
            set_local 8
            get_local 11
            i32.const 6
            i32.lt_s
            set_local 7
            get_local 11
            i32.const 1
            i32.add
            tee_local 13
            set_local 11
            get_local 7
            br_if 0 (;@4;)
          end
          i32.const 1
          set_local 7
          get_local 13
          i32.const 1
          i32.add
          set_local 11
          get_local 13
          i32.const 6
          i32.lt_s
          br_if 0 (;@3;)
          br 2 (;@1;)
        end
      end
      i32.const 0
      set_local 7
    end
    get_local 7
    i32.const 8462
    call 0
    get_local 10
    i64.const 0
    i64.gt_s
    i32.const 8479
    call 0
    get_local 6
    get_local 9
    i64.load offset=8
    i64.eq
    i32.const 8352
    call 0
    block  ;; label = @1
      block  ;; label = @2
        get_local 4
        i32.load8_u
        tee_local 11
        i32.const 1
        i32.and
        br_if 0 (;@2;)
        get_local 11
        i32.const 1
        i32.shr_u
        set_local 11
        br 1 (;@1;)
      end
      get_local 4
      i32.load offset=4
      set_local 11
    end
    get_local 11
    i32.const 257
    i32.lt_u
    i32.const 8212
    call 0
    block  ;; label = @1
      get_local 0
      i64.load
      get_local 2
      i64.eq
      br_if 0 (;@1;)
      block  ;; label = @2
        block  ;; label = @3
          get_local 10
          f64.convert_s/i64
          f64.const 0x1.999999999999ap-5 (;=0.05;)
          f64.mul
          tee_local 14
          f64.abs
          f64.const 0x1p+63 (;=9.22337e+18;)
          f64.lt
          br_if 0 (;@3;)
          i64.const -9223372036854775808
          set_local 6
          br 1 (;@2;)
        end
        get_local 14
        i64.trunc_s/f64
        set_local 6
      end
      get_local 6
      i64.const 4611686018427387903
      i64.add
      i64.const 9223372036854775807
      i64.lt_u
      i32.const 8607
      call 0
      i64.const 90500637018445
      set_local 8
      i32.const 0
      set_local 11
      block  ;; label = @2
        block  ;; label = @3
          loop  ;; label = @4
            get_local 8
            i32.wrap/i64
            i32.const 24
            i32.shl
            i32.const -1073741825
            i32.add
            i32.const 452984830
            i32.gt_u
            br_if 1 (;@3;)
            get_local 8
            i64.const 8
            i64.shr_u
            set_local 12
            block  ;; label = @5
              get_local 8
              i64.const 65280
              i64.and
              i64.const 0
              i64.eq
              br_if 0 (;@5;)
              get_local 12
              set_local 8
              i32.const 1
              set_local 7
              get_local 11
              tee_local 13
              i32.const 1
              i32.add
              set_local 11
              get_local 13
              i32.const 6
              i32.lt_s
              br_if 1 (;@4;)
              br 3 (;@2;)
            end
            get_local 12
            set_local 8
            loop  ;; label = @5
              get_local 8
              i64.const 65280
              i64.and
              i64.const 0
              i64.ne
              br_if 2 (;@3;)
              get_local 8
              i64.const 8
              i64.shr_u
              set_local 8
              get_local 11
              i32.const 6
              i32.lt_s
              set_local 7
              get_local 11
              i32.const 1
              i32.add
              tee_local 13
              set_local 11
              get_local 7
              br_if 0 (;@5;)
            end
            i32.const 1
            set_local 7
            get_local 13
            i32.const 1
            i32.add
            set_local 11
            get_local 13
            i32.const 6
            i32.lt_s
            br_if 0 (;@4;)
            br 2 (;@2;)
          end
        end
        i32.const 0
        set_local 7
      end
      get_local 7
      i32.const 8192
      call 0
      get_local 5
      get_local 6
      i64.store offset=88
      get_local 3
      get_local 10
      get_local 6
      i64.sub
      i64.store
      get_local 5
      i64.const 23168163076721922
      i64.store offset=96
      get_local 0
      i64.load
      set_local 8
      get_local 5
      i32.const 48
      i32.add
      get_local 5
      i64.load offset=96
      i64.store
      get_local 5
      get_local 5
      i64.load offset=88
      i64.store offset=40
      get_local 0
      get_local 8
      get_local 5
      i32.const 40
      i32.add
      get_local 1
      call 40
    end
    get_local 5
    i32.const 72
    i32.add
    i32.const 8
    i32.add
    get_local 3
    i32.const 8
    i32.add
    tee_local 11
    i64.load
    tee_local 12
    i64.store
    get_local 3
    i64.load
    set_local 8
    get_local 5
    i32.const 24
    i32.add
    i32.const 8
    i32.add
    get_local 12
    i64.store
    get_local 5
    get_local 8
    i64.store offset=72
    get_local 5
    get_local 8
    i64.store offset=24
    get_local 0
    get_local 1
    get_local 5
    i32.const 24
    i32.add
    call 46
    get_local 5
    i32.const 56
    i32.add
    i32.const 8
    i32.add
    get_local 11
    i64.load
    tee_local 12
    i64.store
    get_local 3
    i64.load
    set_local 8
    get_local 5
    i32.const 8
    i32.add
    i32.const 8
    i32.add
    get_local 12
    i64.store
    get_local 5
    get_local 8
    i64.store offset=8
    get_local 5
    get_local 8
    i64.store offset=56
    get_local 0
    get_local 2
    get_local 5
    i32.const 8
    i32.add
    get_local 1
    call 40
    block  ;; label = @1
      get_local 5
      i32.load offset=128
      tee_local 13
      i32.eqz
      br_if 0 (;@1;)
      block  ;; label = @2
        block  ;; label = @3
          get_local 5
          i32.const 132
          i32.add
          tee_local 3
          i32.load
          tee_local 11
          get_local 13
          i32.eq
          br_if 0 (;@3;)
          loop  ;; label = @4
            get_local 11
            i32.const -24
            i32.add
            tee_local 11
            i32.load
            set_local 7
            get_local 11
            i32.const 0
            i32.store
            block  ;; label = @5
              get_local 7
              i32.eqz
              br_if 0 (;@5;)
              get_local 7
              call 74
            end
            get_local 13
            get_local 11
            i32.ne
            br_if 0 (;@4;)
          end
          get_local 5
          i32.const 128
          i32.add
          i32.load
          set_local 11
          br 1 (;@2;)
        end
        get_local 13
        set_local 11
      end
      get_local 3
      get_local 13
      i32.store
      get_local 11
      call 74
    end
    get_local 5
    i32.const 144
    i32.add
    set_global 0)
  (func (;45;) (type 22) (param i32 i64 i32) (result i32)
    (local i32 i32 i32 i32)
    block  ;; label = @1
      get_local 0
      i32.load offset=24
      tee_local 3
      get_local 0
      i32.const 28
      i32.add
      i32.load
      tee_local 4
      i32.eq
      br_if 0 (;@1;)
      block  ;; label = @2
        loop  ;; label = @3
          get_local 4
          i32.const -24
          i32.add
          tee_local 5
          i32.load
          tee_local 6
          i64.load offset=8
          i64.const 8
          i64.shr_u
          get_local 1
          i64.eq
          br_if 1 (;@2;)
          get_local 5
          set_local 4
          get_local 3
          get_local 5
          i32.ne
          br_if 0 (;@3;)
          br 2 (;@1;)
        end
      end
      get_local 3
      get_local 4
      i32.eq
      br_if 0 (;@1;)
      get_local 6
      i32.load offset=40
      get_local 0
      i32.eq
      i32.const 8656
      call 0
      get_local 6
      i32.const 0
      i32.ne
      get_local 2
      call 0
      get_local 6
      return
    end
    i32.const 0
    set_local 5
    block  ;; label = @1
      get_local 0
      i64.load
      get_local 0
      i64.load offset=8
      i64.const -4157508551318700032
      get_local 1
      call 1
      tee_local 4
      i32.const 0
      i32.lt_s
      br_if 0 (;@1;)
      get_local 0
      get_local 4
      call 38
      tee_local 5
      i32.load offset=40
      get_local 0
      i32.eq
      i32.const 8656
      call 0
    end
    get_local 5
    i32.const 0
    i32.ne
    get_local 2
    call 0
    get_local 5)
  (func (;46;) (type 23) (param i32 i64 i32)
    (local i32 i64 i64 i32 i64 i32)
    get_global 0
    i32.const 64
    i32.sub
    tee_local 3
    set_global 0
    get_local 3
    i32.const 40
    i32.add
    i32.const 0
    i32.store
    get_local 3
    get_local 1
    i64.store offset=16
    get_local 3
    i64.const -1
    i64.store offset=24
    get_local 3
    i64.const 0
    i64.store offset=32
    get_local 3
    get_local 0
    i64.load
    i64.store offset=8
    get_local 3
    i32.const 8
    i32.add
    get_local 2
    i64.load offset=8
    tee_local 4
    i64.const 8
    i64.shr_u
    i32.const 8501
    call 47
    tee_local 0
    i64.load
    get_local 2
    i64.load
    tee_local 5
    i64.ge_s
    i32.const 8525
    call 0
    block  ;; label = @1
      block  ;; label = @2
        block  ;; label = @3
          get_local 5
          get_local 0
          i64.load
          i64.ne
          br_if 0 (;@3;)
          get_local 3
          i32.const 8
          i32.add
          get_local 0
          call 48
          get_local 3
          i32.load offset=32
          tee_local 6
          br_if 1 (;@2;)
          br 2 (;@1;)
        end
        get_local 0
        i32.load offset=16
        get_local 3
        i32.const 8
        i32.add
        i32.eq
        i32.const 8735
        call 0
        get_local 3
        i64.load offset=8
        call 3
        i64.eq
        i32.const 8781
        call 0
        get_local 4
        get_local 0
        i64.load offset=8
        tee_local 7
        i64.eq
        i32.const 9125
        call 0
        get_local 0
        get_local 0
        i64.load
        get_local 5
        i64.sub
        tee_local 5
        i64.store
        get_local 5
        i64.const -4611686018427387904
        i64.gt_s
        i32.const 9173
        call 0
        get_local 0
        i64.load
        i64.const 4611686018427387904
        i64.lt_s
        i32.const 9195
        call 0
        get_local 7
        i64.const 8
        i64.shr_u
        tee_local 5
        get_local 0
        i64.load offset=8
        i64.const 8
        i64.shr_u
        i64.eq
        i32.const 8832
        call 0
        i32.const 1
        i32.const 8971
        call 0
        get_local 3
        i32.const 48
        i32.add
        get_local 0
        i32.const 8
        call 5
        drop
        i32.const 1
        i32.const 8971
        call 0
        get_local 3
        i32.const 48
        i32.add
        i32.const 8
        i32.or
        get_local 0
        i32.const 8
        i32.add
        i32.const 8
        call 5
        drop
        get_local 0
        i32.load offset=20
        get_local 1
        get_local 3
        i32.const 48
        i32.add
        i32.const 16
        call 4
        block  ;; label = @3
          get_local 5
          get_local 3
          i32.const 8
          i32.add
          i32.const 16
          i32.add
          tee_local 0
          i64.load
          i64.lt_u
          br_if 0 (;@3;)
          get_local 0
          get_local 5
          i64.const 1
          i64.add
          i64.store
        end
        get_local 3
        i32.load offset=32
        tee_local 6
        i32.eqz
        br_if 1 (;@1;)
      end
      block  ;; label = @2
        block  ;; label = @3
          get_local 3
          i32.const 36
          i32.add
          tee_local 8
          i32.load
          tee_local 0
          get_local 6
          i32.eq
          br_if 0 (;@3;)
          loop  ;; label = @4
            get_local 0
            i32.const -24
            i32.add
            tee_local 0
            i32.load
            set_local 2
            get_local 0
            i32.const 0
            i32.store
            block  ;; label = @5
              get_local 2
              i32.eqz
              br_if 0 (;@5;)
              get_local 2
              call 74
            end
            get_local 6
            get_local 0
            i32.ne
            br_if 0 (;@4;)
          end
          get_local 3
          i32.const 32
          i32.add
          i32.load
          set_local 0
          br 1 (;@2;)
        end
        get_local 6
        set_local 0
      end
      get_local 8
      get_local 6
      i32.store
      get_local 0
      call 74
    end
    get_local 3
    i32.const 64
    i32.add
    set_global 0)
  (func (;47;) (type 22) (param i32 i64 i32) (result i32)
    (local i32 i32 i32 i32)
    block  ;; label = @1
      get_local 0
      i32.load offset=24
      tee_local 3
      get_local 0
      i32.const 28
      i32.add
      i32.load
      tee_local 4
      i32.eq
      br_if 0 (;@1;)
      block  ;; label = @2
        loop  ;; label = @3
          get_local 4
          i32.const -24
          i32.add
          tee_local 5
          i32.load
          tee_local 6
          i64.load offset=8
          i64.const 8
          i64.shr_u
          get_local 1
          i64.eq
          br_if 1 (;@2;)
          get_local 5
          set_local 4
          get_local 3
          get_local 5
          i32.ne
          br_if 0 (;@3;)
          br 2 (;@1;)
        end
      end
      get_local 3
      get_local 4
      i32.eq
      br_if 0 (;@1;)
      get_local 6
      i32.load offset=16
      get_local 0
      i32.eq
      i32.const 8656
      call 0
      get_local 6
      i32.const 0
      i32.ne
      get_local 2
      call 0
      get_local 6
      return
    end
    i32.const 0
    set_local 5
    block  ;; label = @1
      get_local 0
      i64.load
      get_local 0
      i64.load offset=8
      i64.const 3607749779137757184
      get_local 1
      call 1
      tee_local 4
      i32.const 0
      i32.lt_s
      br_if 0 (;@1;)
      get_local 0
      get_local 4
      call 42
      tee_local 5
      i32.load offset=16
      get_local 0
      i32.eq
      i32.const 8656
      call 0
    end
    get_local 5
    i32.const 0
    i32.ne
    get_local 2
    call 0
    get_local 5)
  (func (;48;) (type 3) (param i32 i32)
    (local i32 i32 i32 i32 i64 i32 i32)
    get_local 1
    i32.load offset=16
    get_local 0
    i32.eq
    i32.const 8977
    call 0
    get_local 0
    i64.load
    call 3
    i64.eq
    i32.const 9022
    call 0
    get_local 0
    i32.load offset=24
    tee_local 2
    set_local 3
    block  ;; label = @1
      get_local 2
      get_local 0
      i32.const 28
      i32.add
      tee_local 4
      i32.load
      tee_local 5
      i32.eq
      br_if 0 (;@1;)
      block  ;; label = @2
        get_local 5
        i32.const -24
        i32.add
        i32.load
        i64.load offset=8
        get_local 1
        i64.load offset=8
        tee_local 6
        i64.xor
        i64.const 256
        i64.ge_u
        br_if 0 (;@2;)
        get_local 5
        set_local 3
        br 1 (;@1;)
      end
      get_local 2
      i32.const 24
      i32.add
      set_local 7
      block  ;; label = @2
        loop  ;; label = @3
          get_local 7
          get_local 5
          i32.eq
          br_if 1 (;@2;)
          get_local 5
          i32.const -48
          i32.add
          set_local 8
          get_local 5
          i32.const -24
          i32.add
          tee_local 3
          set_local 5
          get_local 8
          i32.load
          i64.load offset=8
          get_local 6
          i64.xor
          i64.const 256
          i64.ge_u
          br_if 0 (;@3;)
          br 2 (;@1;)
        end
      end
      get_local 2
      set_local 3
    end
    get_local 3
    get_local 2
    i32.ne
    i32.const 9072
    call 0
    block  ;; label = @1
      block  ;; label = @2
        block  ;; label = @3
          get_local 3
          get_local 4
          i32.load
          tee_local 2
          i32.eq
          br_if 0 (;@3;)
          get_local 3
          set_local 5
          loop  ;; label = @4
            get_local 5
            i32.load
            set_local 8
            get_local 5
            i32.const 0
            i32.store
            get_local 5
            i32.const -24
            i32.add
            tee_local 7
            i32.load
            set_local 3
            get_local 7
            get_local 8
            i32.store
            block  ;; label = @5
              get_local 3
              i32.eqz
              br_if 0 (;@5;)
              get_local 3
              call 74
            end
            get_local 5
            i32.const -8
            i32.add
            get_local 5
            i32.const 16
            i32.add
            i32.load
            i32.store
            get_local 5
            i32.const -16
            i32.add
            get_local 5
            i32.const 8
            i32.add
            i64.load
            i64.store
            get_local 2
            get_local 5
            i32.const 24
            i32.add
            tee_local 5
            i32.ne
            br_if 0 (;@4;)
          end
          get_local 5
          i32.const -24
          i32.add
          set_local 8
          get_local 0
          i32.const 28
          i32.add
          i32.load
          tee_local 3
          i32.const 24
          i32.add
          get_local 5
          i32.ne
          br_if 1 (;@2;)
          br 2 (;@1;)
        end
        get_local 3
        i32.const -24
        i32.add
        set_local 8
      end
      loop  ;; label = @2
        get_local 3
        i32.const -24
        i32.add
        tee_local 3
        i32.load
        set_local 5
        get_local 3
        i32.const 0
        i32.store
        block  ;; label = @3
          get_local 5
          i32.eqz
          br_if 0 (;@3;)
          get_local 5
          call 74
        end
        get_local 8
        get_local 3
        i32.ne
        br_if 0 (;@2;)
      end
    end
    get_local 0
    i32.const 28
    i32.add
    get_local 8
    i32.store
    get_local 1
    i32.load offset=20
    call 9)
  (func (;49;) (type 0) (param i32 i64 i32 i32)
    (local i32 i32 i64 i32)
    get_global 0
    i32.const 112
    i32.sub
    tee_local 4
    set_global 0
    get_local 4
    get_local 1
    i64.store offset=64
    get_local 0
    i64.load
    call 2
    get_local 1
    call 7
    i32.const 8424
    call 0
    get_local 1
    call 8
    get_local 4
    i32.const 56
    i32.add
    tee_local 5
    i32.const 0
    i32.store
    get_local 4
    i64.const -1
    i64.store offset=40
    get_local 4
    i64.const 0
    i64.store offset=48
    get_local 4
    get_local 0
    i64.load
    tee_local 6
    i64.store offset=24
    get_local 4
    get_local 6
    i64.store offset=32
    get_local 4
    get_local 2
    i32.store offset=12
    get_local 4
    get_local 3
    i32.store offset=16
    get_local 4
    get_local 4
    i32.const 64
    i32.add
    i32.store offset=8
    get_local 4
    get_local 1
    i64.store offset=104
    get_local 6
    call 3
    i64.eq
    i32.const 9216
    call 0
    get_local 4
    get_local 4
    i32.const 8
    i32.add
    i32.store offset=84
    get_local 4
    get_local 4
    i32.const 24
    i32.add
    i32.store offset=80
    get_local 4
    get_local 4
    i32.const 104
    i32.add
    i32.store offset=88
    i32.const 48
    call 72
    tee_local 0
    i64.const 0
    i64.store offset=8 align=4
    get_local 0
    i64.const 0
    i64.store offset=16 align=4
    get_local 0
    i64.const 0
    i64.store offset=24 align=4
    get_local 0
    get_local 4
    i32.const 24
    i32.add
    i32.store offset=32
    get_local 4
    i32.const 80
    i32.add
    get_local 0
    call 50
    get_local 4
    get_local 0
    i32.store offset=96
    get_local 4
    get_local 0
    i64.load
    tee_local 1
    i64.store offset=80
    get_local 4
    get_local 0
    i32.load offset=36
    tee_local 2
    i32.store offset=76
    block  ;; label = @1
      block  ;; label = @2
        block  ;; label = @3
          block  ;; label = @4
            block  ;; label = @5
              get_local 4
              i32.const 52
              i32.add
              tee_local 7
              i32.load
              tee_local 3
              get_local 5
              i32.load
              i32.ge_u
              br_if 0 (;@5;)
              get_local 3
              get_local 1
              i64.store offset=8
              get_local 3
              get_local 2
              i32.store offset=16
              get_local 4
              i32.const 0
              i32.store offset=96
              get_local 3
              get_local 0
              i32.store
              get_local 7
              get_local 3
              i32.const 24
              i32.add
              i32.store
              get_local 4
              i32.load offset=96
              set_local 0
              get_local 4
              i32.const 0
              i32.store offset=96
              get_local 0
              i32.eqz
              br_if 1 (;@4;)
              br 2 (;@3;)
            end
            get_local 4
            i32.const 48
            i32.add
            get_local 4
            i32.const 96
            i32.add
            get_local 4
            i32.const 80
            i32.add
            get_local 4
            i32.const 76
            i32.add
            call 51
            get_local 4
            i32.load offset=96
            set_local 0
            get_local 4
            i32.const 0
            i32.store offset=96
            get_local 0
            br_if 1 (;@3;)
          end
          get_local 4
          i32.load offset=48
          tee_local 2
          i32.eqz
          br_if 2 (;@1;)
          br 1 (;@2;)
        end
        block  ;; label = @3
          get_local 0
          i32.load8_u offset=20
          i32.const 1
          i32.and
          i32.eqz
          br_if 0 (;@3;)
          get_local 0
          i32.const 28
          i32.add
          i32.load
          call 74
        end
        block  ;; label = @3
          get_local 0
          i32.load8_u offset=8
          i32.const 1
          i32.and
          i32.eqz
          br_if 0 (;@3;)
          get_local 0
          i32.const 16
          i32.add
          i32.load
          call 74
        end
        get_local 0
        call 74
        get_local 4
        i32.load offset=48
        tee_local 2
        i32.eqz
        br_if 1 (;@1;)
      end
      block  ;; label = @2
        block  ;; label = @3
          get_local 4
          i32.const 24
          i32.add
          i32.const 28
          i32.add
          tee_local 5
          i32.load
          tee_local 3
          get_local 2
          i32.eq
          br_if 0 (;@3;)
          loop  ;; label = @4
            get_local 3
            i32.const -24
            i32.add
            tee_local 3
            i32.load
            set_local 0
            get_local 3
            i32.const 0
            i32.store
            block  ;; label = @5
              get_local 0
              i32.eqz
              br_if 0 (;@5;)
              block  ;; label = @6
                get_local 0
                i32.load8_u offset=20
                i32.const 1
                i32.and
                i32.eqz
                br_if 0 (;@6;)
                get_local 0
                i32.const 28
                i32.add
                i32.load
                call 74
              end
              block  ;; label = @6
                get_local 0
                i32.load8_u offset=8
                i32.const 1
                i32.and
                i32.eqz
                br_if 0 (;@6;)
                get_local 0
                i32.const 16
                i32.add
                i32.load
                call 74
              end
              get_local 0
              call 74
            end
            get_local 2
            get_local 3
            i32.ne
            br_if 0 (;@4;)
          end
          get_local 4
          i32.const 48
          i32.add
          i32.load
          set_local 0
          br 1 (;@2;)
        end
        get_local 2
        set_local 0
      end
      get_local 5
      get_local 2
      i32.store
      get_local 0
      call 74
    end
    get_local 4
    i32.const 112
    i32.add
    set_global 0)
  (func (;50;) (type 3) (param i32 i32)
    (local i32 i32 i32 i32 i32 i32 i32 i64)
    get_global 0
    i32.const 16
    i32.sub
    tee_local 2
    set_local 3
    get_local 2
    set_global 0
    get_local 1
    get_local 0
    i32.load offset=4
    tee_local 4
    i32.load
    i64.load
    i64.store
    get_local 0
    i32.load
    set_local 5
    get_local 1
    i32.const 8
    i32.add
    tee_local 6
    get_local 4
    i32.load offset=4
    call 78
    drop
    get_local 1
    i32.const 20
    i32.add
    tee_local 7
    get_local 4
    i32.load offset=8
    call 78
    drop
    get_local 1
    i32.const 12
    i32.add
    i32.load
    get_local 1
    i32.load8_u offset=8
    tee_local 4
    i32.const 1
    i32.shr_u
    get_local 4
    i32.const 1
    i32.and
    select
    tee_local 8
    i32.const 8
    i32.add
    set_local 4
    get_local 8
    i64.extend_u/i32
    set_local 9
    loop  ;; label = @1
      get_local 4
      i32.const 1
      i32.add
      set_local 4
      get_local 9
      i64.const 7
      i64.shr_u
      tee_local 9
      i64.const 0
      i64.ne
      br_if 0 (;@1;)
    end
    get_local 1
    i32.const 24
    i32.add
    i32.load
    get_local 1
    i32.const 20
    i32.add
    i32.load8_u
    tee_local 8
    i32.const 1
    i32.shr_u
    get_local 8
    i32.const 1
    i32.and
    select
    tee_local 8
    get_local 4
    i32.add
    set_local 4
    get_local 8
    i64.extend_u/i32
    set_local 9
    loop  ;; label = @1
      get_local 4
      i32.const 1
      i32.add
      set_local 4
      get_local 9
      i64.const 7
      i64.shr_u
      tee_local 9
      i64.const 0
      i64.ne
      br_if 0 (;@1;)
    end
    block  ;; label = @1
      block  ;; label = @2
        get_local 4
        i32.const 513
        i32.lt_u
        br_if 0 (;@2;)
        get_local 4
        call 83
        set_local 2
        br 1 (;@1;)
      end
      get_local 2
      get_local 4
      i32.const 15
      i32.add
      i32.const -16
      i32.and
      i32.sub
      tee_local 2
      set_global 0
    end
    get_local 3
    get_local 2
    i32.store
    get_local 3
    get_local 2
    get_local 4
    i32.add
    i32.store offset=8
    get_local 4
    i32.const 7
    i32.gt_s
    i32.const 8971
    call 0
    get_local 2
    get_local 1
    i32.const 8
    call 5
    drop
    get_local 3
    get_local 2
    i32.const 8
    i32.add
    i32.store offset=4
    get_local 3
    get_local 6
    call 67
    drop
    get_local 3
    get_local 7
    call 67
    drop
    get_local 1
    get_local 5
    i64.load offset=8
    i64.const 8526769848007524352
    get_local 0
    i32.load offset=8
    i64.load
    get_local 1
    i64.load
    tee_local 9
    get_local 2
    get_local 4
    call 6
    i32.store offset=36
    block  ;; label = @1
      block  ;; label = @2
        block  ;; label = @3
          get_local 4
          i32.const 513
          i32.ge_u
          br_if 0 (;@3;)
          get_local 9
          get_local 5
          i64.load offset=16
          i64.ge_u
          br_if 1 (;@2;)
          br 2 (;@1;)
        end
        get_local 2
        call 86
        get_local 9
        get_local 5
        i64.load offset=16
        i64.lt_u
        br_if 1 (;@1;)
      end
      get_local 5
      i32.const 16
      i32.add
      i64.const -2
      get_local 9
      i64.const 1
      i64.add
      get_local 9
      i64.const -3
      i64.gt_u
      select
      i64.store
      get_local 3
      i32.const 16
      i32.add
      set_global 0
      return
    end
    get_local 3
    i32.const 16
    i32.add
    set_global 0)
  (func (;51;) (type 21) (param i32 i32 i32 i32)
    (local i32 i32 i32 i32 i32)
    block  ;; label = @1
      block  ;; label = @2
        get_local 0
        i32.load offset=4
        get_local 0
        i32.load
        tee_local 4
        i32.sub
        i32.const 24
        i32.div_s
        tee_local 5
        i32.const 1
        i32.add
        tee_local 6
        i32.const 178956971
        i32.ge_u
        br_if 0 (;@2;)
        i32.const 178956970
        set_local 7
        block  ;; label = @3
          block  ;; label = @4
            get_local 0
            i32.load offset=8
            get_local 4
            i32.sub
            i32.const 24
            i32.div_s
            tee_local 4
            i32.const 89478484
            i32.gt_u
            br_if 0 (;@4;)
            get_local 6
            get_local 4
            i32.const 1
            i32.shl
            tee_local 7
            get_local 7
            get_local 6
            i32.lt_u
            select
            tee_local 7
            i32.eqz
            br_if 1 (;@3;)
          end
          get_local 7
          i32.const 24
          i32.mul
          call 72
          set_local 4
          br 2 (;@1;)
        end
        i32.const 0
        set_local 7
        i32.const 0
        set_local 4
        br 1 (;@1;)
      end
      get_local 0
      call 81
      unreachable
    end
    get_local 1
    i32.load
    set_local 6
    get_local 1
    i32.const 0
    i32.store
    get_local 4
    get_local 5
    i32.const 24
    i32.mul
    tee_local 8
    i32.add
    tee_local 1
    get_local 6
    i32.store
    get_local 1
    get_local 2
    i64.load
    i64.store offset=8
    get_local 1
    get_local 3
    i32.load
    i32.store offset=16
    get_local 4
    get_local 7
    i32.const 24
    i32.mul
    i32.add
    set_local 5
    get_local 1
    i32.const 24
    i32.add
    set_local 6
    block  ;; label = @1
      block  ;; label = @2
        get_local 0
        i32.const 4
        i32.add
        i32.load
        tee_local 2
        get_local 0
        i32.load
        tee_local 7
        i32.eq
        br_if 0 (;@2;)
        get_local 4
        get_local 8
        i32.add
        i32.const -24
        i32.add
        set_local 1
        loop  ;; label = @3
          get_local 2
          i32.const -24
          i32.add
          tee_local 4
          i32.load
          set_local 3
          get_local 4
          i32.const 0
          i32.store
          get_local 1
          get_local 3
          i32.store
          get_local 1
          i32.const 16
          i32.add
          get_local 2
          i32.const -8
          i32.add
          i32.load
          i32.store
          get_local 1
          i32.const 8
          i32.add
          get_local 2
          i32.const -16
          i32.add
          i64.load
          i64.store
          get_local 1
          i32.const -24
          i32.add
          set_local 1
          get_local 4
          set_local 2
          get_local 7
          get_local 4
          i32.ne
          br_if 0 (;@3;)
        end
        get_local 1
        i32.const 24
        i32.add
        set_local 1
        get_local 0
        i32.const 4
        i32.add
        i32.load
        set_local 7
        get_local 0
        i32.load
        set_local 2
        br 1 (;@1;)
      end
      get_local 7
      set_local 2
    end
    get_local 0
    get_local 1
    i32.store
    get_local 0
    i32.const 4
    i32.add
    get_local 6
    i32.store
    get_local 0
    i32.const 8
    i32.add
    get_local 5
    i32.store
    block  ;; label = @1
      get_local 7
      get_local 2
      i32.eq
      br_if 0 (;@1;)
      loop  ;; label = @2
        get_local 7
        i32.const -24
        i32.add
        tee_local 7
        i32.load
        set_local 1
        get_local 7
        i32.const 0
        i32.store
        block  ;; label = @3
          get_local 1
          i32.eqz
          br_if 0 (;@3;)
          block  ;; label = @4
            get_local 1
            i32.load8_u offset=20
            i32.const 1
            i32.and
            i32.eqz
            br_if 0 (;@4;)
            get_local 1
            i32.const 28
            i32.add
            i32.load
            call 74
          end
          block  ;; label = @4
            get_local 1
            i32.load8_u offset=8
            i32.const 1
            i32.and
            i32.eqz
            br_if 0 (;@4;)
            get_local 1
            i32.const 16
            i32.add
            i32.load
            call 74
          end
          get_local 1
          call 74
        end
        get_local 2
        get_local 7
        i32.ne
        br_if 0 (;@2;)
      end
    end
    block  ;; label = @1
      get_local 2
      i32.eqz
      br_if 0 (;@1;)
      get_local 2
      call 74
    end)
  (func (;52;) (type 24) (param i64 i64 i64)
    (local i32 i64)
    get_global 0
    i32.const 64
    i32.sub
    tee_local 3
    set_global 0
    call 36
    i64.const 7
    set_local 4
    loop  ;; label = @1
      get_local 4
      i64.const 1
      i64.add
      tee_local 4
      i64.const 13
      i64.ne
      br_if 0 (;@1;)
    end
    block  ;; label = @1
      block  ;; label = @2
        block  ;; label = @3
          block  ;; label = @4
            i64.const -6569208335818555392
            get_local 2
            i64.eq
            br_if 0 (;@4;)
            get_local 1
            get_local 0
            i64.ne
            br_if 1 (;@3;)
            br 2 (;@2;)
          end
          i64.const 5
          set_local 4
          loop  ;; label = @4
            get_local 4
            i64.const 1
            i64.add
            tee_local 4
            i64.const 13
            i64.ne
            br_if 0 (;@4;)
          end
          i64.const 6138663577826885632
          get_local 1
          i64.eq
          i32.const 8543
          call 0
          get_local 1
          get_local 0
          i64.eq
          br_if 1 (;@2;)
        end
        i64.const 7
        set_local 4
        loop  ;; label = @3
          get_local 4
          i64.const 1
          i64.add
          tee_local 4
          i64.const 13
          i64.ne
          br_if 0 (;@3;)
        end
        i64.const -6569208335818555392
        get_local 2
        i64.ne
        br_if 1 (;@1;)
      end
      get_local 3
      get_local 0
      i64.store offset=56
      block  ;; label = @2
        block  ;; label = @3
          get_local 2
          i64.const -3617168760277827584
          i64.eq
          br_if 0 (;@3;)
          get_local 2
          i64.const 8516769789752901632
          i64.eq
          br_if 1 (;@2;)
          get_local 2
          i64.const 3626220865949007872
          i64.ne
          br_if 2 (;@1;)
          get_local 3
          i32.const 0
          i32.store offset=52
          get_local 3
          i32.const 1
          i32.store offset=48
          get_local 3
          get_local 3
          i64.load offset=48
          i64.store offset=8
          get_local 3
          i32.const 56
          i32.add
          get_local 3
          i32.const 8
          i32.add
          call 53
          drop
          br 2 (;@1;)
        end
        get_local 3
        i32.const 0
        i32.store offset=36
        get_local 3
        i32.const 2
        i32.store offset=32
        get_local 3
        get_local 3
        i64.load offset=32
        i64.store offset=24
        get_local 3
        i32.const 56
        i32.add
        get_local 3
        i32.const 24
        i32.add
        call 54
        drop
        br 1 (;@1;)
      end
      get_local 3
      i32.const 0
      i32.store offset=44
      get_local 3
      i32.const 3
      i32.store offset=40
      get_local 3
      get_local 3
      i64.load offset=40
      i64.store offset=16
      get_local 3
      i32.const 56
      i32.add
      get_local 3
      i32.const 16
      i32.add
      call 55
      drop
    end
    i32.const 0
    call 82
    get_local 3
    i32.const 64
    i32.add
    set_global 0)
  (func (;53;) (type 12) (param i32 i32) (result i32)
    (local i32 i32)
    get_global 0
    i32.const 64
    i32.sub
    tee_local 2
    set_global 0
    get_local 2
    tee_local 3
    get_local 0
    i32.store offset=44
    get_local 3
    get_local 1
    i64.load align=4
    i64.store offset=32
    block  ;; label = @1
      block  ;; label = @2
        block  ;; label = @3
          block  ;; label = @4
            call 10
            tee_local 1
            i32.eqz
            br_if 0 (;@4;)
            get_local 1
            i32.const 513
            i32.lt_u
            br_if 1 (;@3;)
            get_local 1
            call 83
            set_local 2
            br 2 (;@2;)
          end
          i32.const 0
          set_local 2
          br 2 (;@1;)
        end
        get_local 2
        get_local 1
        i32.const 15
        i32.add
        i32.const -16
        i32.and
        i32.sub
        tee_local 2
        set_global 0
      end
      get_local 2
      get_local 1
      call 11
      drop
    end
    get_local 3
    i32.const 16
    i32.add
    i64.const 0
    i64.store
    get_local 3
    i32.const 24
    i32.add
    i64.const 0
    i64.store
    get_local 3
    i64.const 0
    i64.store
    get_local 3
    i64.const 0
    i64.store offset=8
    get_local 3
    get_local 2
    get_local 1
    i32.add
    i32.store offset=56
    get_local 3
    get_local 2
    i32.store offset=48
    get_local 1
    i32.const 7
    i32.gt_u
    i32.const 8730
    call 0
    get_local 3
    get_local 2
    i32.const 8
    call 5
    drop
    get_local 3
    get_local 2
    i32.const 8
    i32.add
    i32.store offset=52
    get_local 3
    i32.const 48
    i32.add
    get_local 3
    i32.const 8
    i32.add
    call 56
    drop
    get_local 3
    i32.const 48
    i32.add
    get_local 3
    i32.const 20
    i32.add
    call 56
    drop
    block  ;; label = @1
      get_local 1
      i32.const 513
      i32.lt_u
      br_if 0 (;@1;)
      get_local 2
      call 86
    end
    get_local 3
    get_local 3
    i32.const 32
    i32.add
    i32.store offset=52
    get_local 3
    get_local 3
    i32.const 44
    i32.add
    i32.store offset=48
    get_local 3
    i32.const 48
    i32.add
    get_local 3
    call 57
    block  ;; label = @1
      get_local 3
      i32.load8_u offset=20
      i32.const 1
      i32.and
      i32.eqz
      br_if 0 (;@1;)
      get_local 3
      i32.const 28
      i32.add
      i32.load
      call 74
    end
    block  ;; label = @1
      get_local 3
      i32.load8_u offset=8
      i32.const 1
      i32.and
      i32.eqz
      br_if 0 (;@1;)
      get_local 3
      i32.const 16
      i32.add
      i32.load
      call 74
    end
    get_local 3
    i32.const 64
    i32.add
    set_global 0
    i32.const 1)
  (func (;54;) (type 12) (param i32 i32) (result i32)
    (local i32 i32 i32 i32 i64 i64)
    get_global 0
    i32.const 96
    i32.sub
    tee_local 2
    set_global 0
    get_local 2
    tee_local 3
    get_local 0
    i32.store offset=60
    get_local 3
    get_local 1
    i64.load align=4
    i64.store offset=48
    i32.const 0
    set_local 1
    i32.const 0
    set_local 4
    block  ;; label = @1
      call 10
      tee_local 5
      i32.eqz
      br_if 0 (;@1;)
      block  ;; label = @2
        block  ;; label = @3
          get_local 5
          i32.const 513
          i32.lt_u
          br_if 0 (;@3;)
          get_local 5
          call 83
          set_local 4
          br 1 (;@2;)
        end
        get_local 2
        get_local 5
        i32.const 15
        i32.add
        i32.const -16
        i32.and
        i32.sub
        tee_local 4
        set_global 0
      end
      get_local 4
      get_local 5
      call 11
      drop
    end
    get_local 3
    i32.const 24
    i32.add
    i64.const 1398362884
    i64.store
    get_local 3
    i64.const 0
    i64.store offset=8
    get_local 3
    i64.const 0
    i64.store
    get_local 3
    i64.const 0
    i64.store offset=16
    i32.const 1
    i32.const 8607
    call 0
    i64.const 5462355
    set_local 6
    block  ;; label = @1
      block  ;; label = @2
        loop  ;; label = @3
          get_local 6
          i32.wrap/i64
          i32.const 24
          i32.shl
          i32.const -1073741825
          i32.add
          i32.const 452984830
          i32.gt_u
          br_if 1 (;@2;)
          get_local 6
          i64.const 8
          i64.shr_u
          set_local 7
          block  ;; label = @4
            get_local 6
            i64.const 65280
            i64.and
            i64.const 0
            i64.eq
            br_if 0 (;@4;)
            get_local 7
            set_local 6
            i32.const 1
            set_local 2
            get_local 1
            tee_local 0
            i32.const 1
            i32.add
            set_local 1
            get_local 0
            i32.const 6
            i32.lt_s
            br_if 1 (;@3;)
            br 3 (;@1;)
          end
          get_local 7
          set_local 6
          loop  ;; label = @4
            get_local 6
            i64.const 65280
            i64.and
            i64.const 0
            i64.ne
            br_if 2 (;@2;)
            get_local 6
            i64.const 8
            i64.shr_u
            set_local 6
            get_local 1
            i32.const 6
            i32.lt_s
            set_local 2
            get_local 1
            i32.const 1
            i32.add
            tee_local 0
            set_local 1
            get_local 2
            br_if 0 (;@4;)
          end
          i32.const 1
          set_local 2
          get_local 0
          i32.const 1
          i32.add
          set_local 1
          get_local 0
          i32.const 6
          i32.lt_s
          br_if 0 (;@3;)
          br 2 (;@1;)
        end
      end
      i32.const 0
      set_local 2
    end
    get_local 2
    i32.const 8192
    call 0
    get_local 3
    i32.const 40
    i32.add
    i32.const 0
    i32.store
    get_local 3
    i64.const 0
    i64.store offset=32
    get_local 3
    get_local 4
    i32.store offset=68
    get_local 3
    get_local 4
    i32.store offset=64
    get_local 3
    get_local 4
    get_local 5
    i32.add
    i32.store offset=72
    get_local 3
    get_local 3
    i32.const 64
    i32.add
    i32.store offset=80
    get_local 3
    get_local 3
    i32.store offset=88
    get_local 3
    i32.const 88
    i32.add
    get_local 3
    i32.const 80
    i32.add
    call 59
    block  ;; label = @1
      get_local 5
      i32.const 513
      i32.lt_u
      br_if 0 (;@1;)
      get_local 4
      call 86
    end
    get_local 3
    get_local 3
    i32.const 48
    i32.add
    i32.store offset=68
    get_local 3
    get_local 3
    i32.const 60
    i32.add
    i32.store offset=64
    get_local 3
    i32.const 64
    i32.add
    get_local 3
    call 60
    block  ;; label = @1
      get_local 3
      i32.load8_u offset=32
      i32.const 1
      i32.and
      i32.eqz
      br_if 0 (;@1;)
      get_local 3
      i32.const 40
      i32.add
      i32.load
      call 74
    end
    get_local 3
    i32.const 96
    i32.add
    set_global 0
    i32.const 1)
  (func (;55;) (type 12) (param i32 i32) (result i32)
    (local i32 i32 i32 i32 i64 i64)
    get_global 0
    i32.const 80
    i32.sub
    tee_local 2
    set_global 0
    get_local 2
    tee_local 3
    get_local 0
    i32.store offset=60
    get_local 3
    get_local 1
    i64.load align=4
    i64.store offset=48
    i32.const 0
    set_local 1
    i32.const 0
    set_local 4
    block  ;; label = @1
      call 10
      tee_local 5
      i32.eqz
      br_if 0 (;@1;)
      block  ;; label = @2
        block  ;; label = @3
          get_local 5
          i32.const 513
          i32.lt_u
          br_if 0 (;@3;)
          get_local 5
          call 83
          set_local 4
          br 1 (;@2;)
        end
        get_local 2
        get_local 5
        i32.const 15
        i32.add
        i32.const -16
        i32.and
        i32.sub
        tee_local 4
        set_global 0
      end
      get_local 4
      get_local 5
      call 11
      drop
    end
    get_local 3
    i32.const 24
    i32.add
    i64.const 1398362884
    i64.store
    get_local 3
    i64.const 0
    i64.store offset=16
    get_local 3
    i64.const 0
    i64.store offset=8
    i32.const 1
    i32.const 8607
    call 0
    i64.const 5462355
    set_local 6
    block  ;; label = @1
      block  ;; label = @2
        loop  ;; label = @3
          get_local 6
          i32.wrap/i64
          i32.const 24
          i32.shl
          i32.const -1073741825
          i32.add
          i32.const 452984830
          i32.gt_u
          br_if 1 (;@2;)
          get_local 6
          i64.const 8
          i64.shr_u
          set_local 7
          block  ;; label = @4
            get_local 6
            i64.const 65280
            i64.and
            i64.const 0
            i64.eq
            br_if 0 (;@4;)
            get_local 7
            set_local 6
            i32.const 1
            set_local 2
            get_local 1
            tee_local 0
            i32.const 1
            i32.add
            set_local 1
            get_local 0
            i32.const 6
            i32.lt_s
            br_if 1 (;@3;)
            br 3 (;@1;)
          end
          get_local 7
          set_local 6
          loop  ;; label = @4
            get_local 6
            i64.const 65280
            i64.and
            i64.const 0
            i64.ne
            br_if 2 (;@2;)
            get_local 6
            i64.const 8
            i64.shr_u
            set_local 6
            get_local 1
            i32.const 6
            i32.lt_s
            set_local 2
            get_local 1
            i32.const 1
            i32.add
            tee_local 0
            set_local 1
            get_local 2
            br_if 0 (;@4;)
          end
          i32.const 1
          set_local 2
          get_local 0
          i32.const 1
          i32.add
          set_local 1
          get_local 0
          i32.const 6
          i32.lt_s
          br_if 0 (;@3;)
          br 2 (;@1;)
        end
      end
      i32.const 0
      set_local 2
    end
    get_local 2
    i32.const 8192
    call 0
    get_local 3
    i32.const 40
    i32.add
    i32.const 0
    i32.store
    get_local 3
    i64.const 0
    i64.store offset=32
    get_local 3
    get_local 4
    get_local 5
    i32.add
    i32.store offset=72
    get_local 3
    get_local 4
    i32.store offset=64
    get_local 5
    i32.const 7
    i32.gt_u
    i32.const 8730
    call 0
    get_local 3
    i32.const 8
    i32.add
    get_local 4
    i32.const 8
    call 5
    drop
    get_local 5
    i32.const -8
    i32.and
    tee_local 1
    i32.const 8
    i32.ne
    i32.const 8730
    call 0
    get_local 3
    i32.const 8
    i32.add
    i32.const 8
    i32.add
    get_local 4
    i32.const 8
    i32.add
    i32.const 8
    call 5
    drop
    get_local 1
    i32.const 16
    i32.ne
    i32.const 8730
    call 0
    get_local 3
    i32.const 8
    i32.add
    i32.const 16
    i32.add
    get_local 4
    i32.const 16
    i32.add
    i32.const 8
    call 5
    drop
    get_local 3
    get_local 4
    i32.const 24
    i32.add
    i32.store offset=68
    get_local 3
    i32.const 64
    i32.add
    get_local 3
    i32.const 8
    i32.add
    i32.const 24
    i32.add
    call 56
    drop
    block  ;; label = @1
      get_local 5
      i32.const 513
      i32.lt_u
      br_if 0 (;@1;)
      get_local 4
      call 86
    end
    get_local 3
    get_local 3
    i32.const 48
    i32.add
    i32.store offset=68
    get_local 3
    get_local 3
    i32.const 60
    i32.add
    i32.store offset=64
    get_local 3
    i32.const 64
    i32.add
    get_local 3
    i32.const 8
    i32.add
    call 58
    block  ;; label = @1
      get_local 3
      i32.load8_u offset=32
      i32.const 1
      i32.and
      i32.eqz
      br_if 0 (;@1;)
      get_local 3
      i32.const 40
      i32.add
      i32.load
      call 74
    end
    get_local 3
    i32.const 80
    i32.add
    set_global 0
    i32.const 1)
  (func (;56;) (type 12) (param i32 i32) (result i32)
    (local i32 i32 i32 i32 i32 i32)
    get_global 0
    i32.const 32
    i32.sub
    tee_local 2
    set_global 0
    get_local 2
    i32.const 0
    i32.store offset=24
    get_local 2
    i64.const 0
    i64.store offset=16
    get_local 0
    get_local 2
    i32.const 16
    i32.add
    call 71
    drop
    block  ;; label = @1
      block  ;; label = @2
        block  ;; label = @3
          block  ;; label = @4
            block  ;; label = @5
              block  ;; label = @6
                block  ;; label = @7
                  block  ;; label = @8
                    get_local 2
                    i32.load offset=20
                    get_local 2
                    i32.load offset=16
                    tee_local 3
                    i32.sub
                    tee_local 4
                    i32.eqz
                    br_if 0 (;@8;)
                    get_local 2
                    i32.const 8
                    i32.add
                    i32.const 0
                    i32.store
                    get_local 2
                    i64.const 0
                    i64.store
                    get_local 4
                    i32.const -16
                    i32.ge_u
                    br_if 5 (;@3;)
                    get_local 4
                    i32.const 10
                    i32.gt_u
                    br_if 1 (;@7;)
                    get_local 2
                    get_local 4
                    i32.const 1
                    i32.shl
                    i32.store8
                    get_local 2
                    i32.const 1
                    i32.or
                    set_local 5
                    br 2 (;@6;)
                  end
                  get_local 1
                  i32.load8_u
                  i32.const 1
                  i32.and
                  br_if 2 (;@5;)
                  get_local 1
                  i32.const 0
                  i32.store16
                  get_local 1
                  i32.const 8
                  i32.add
                  set_local 3
                  br 3 (;@4;)
                end
                get_local 4
                i32.const 16
                i32.add
                i32.const -16
                i32.and
                tee_local 6
                call 72
                set_local 5
                get_local 2
                get_local 6
                i32.const 1
                i32.or
                i32.store
                get_local 2
                get_local 5
                i32.store offset=8
                get_local 2
                get_local 4
                i32.store offset=4
              end
              get_local 4
              set_local 7
              get_local 5
              set_local 6
              loop  ;; label = @6
                get_local 6
                get_local 3
                i32.load8_u
                i32.store8
                get_local 6
                i32.const 1
                i32.add
                set_local 6
                get_local 3
                i32.const 1
                i32.add
                set_local 3
                get_local 7
                i32.const -1
                i32.add
                tee_local 7
                br_if 0 (;@6;)
              end
              get_local 5
              get_local 4
              i32.add
              i32.const 0
              i32.store8
              block  ;; label = @6
                block  ;; label = @7
                  get_local 1
                  i32.load8_u
                  i32.const 1
                  i32.and
                  br_if 0 (;@7;)
                  get_local 1
                  i32.const 0
                  i32.store16
                  br 1 (;@6;)
                end
                get_local 1
                i32.load offset=8
                i32.const 0
                i32.store8
                get_local 1
                i32.const 0
                i32.store offset=4
              end
              get_local 1
              i32.const 0
              call 80
              get_local 1
              i32.const 8
              i32.add
              get_local 2
              i32.const 8
              i32.add
              i32.load
              i32.store
              get_local 1
              get_local 2
              i64.load
              i64.store align=4
              get_local 2
              i32.load offset=16
              tee_local 3
              i32.eqz
              br_if 4 (;@1;)
              br 3 (;@2;)
            end
            get_local 1
            i32.load offset=8
            i32.const 0
            i32.store8
            get_local 1
            i32.const 0
            i32.store offset=4
            get_local 1
            i32.const 8
            i32.add
            set_local 3
          end
          get_local 1
          i32.const 0
          call 80
          get_local 3
          i32.const 0
          i32.store
          get_local 1
          i64.const 0
          i64.store align=4
          get_local 2
          i32.load offset=16
          tee_local 3
          br_if 1 (;@2;)
          br 2 (;@1;)
        end
        get_local 2
        call 76
        unreachable
      end
      get_local 2
      get_local 3
      i32.store offset=20
      get_local 3
      call 74
    end
    get_local 2
    i32.const 32
    i32.add
    set_global 0
    get_local 0)
  (func (;57;) (type 3) (param i32 i32)
    (local i32 i64 i32 i32 i32 i32)
    get_global 0
    i32.const 64
    i32.sub
    tee_local 2
    set_global 0
    get_local 1
    i64.load
    set_local 3
    get_local 2
    i32.const 16
    i32.add
    get_local 1
    i32.const 8
    i32.add
    call 77
    set_local 4
    get_local 2
    get_local 1
    i32.const 20
    i32.add
    call 77
    set_local 1
    get_local 0
    i32.load
    i32.load
    get_local 0
    i32.load offset=4
    tee_local 0
    i32.load offset=4
    tee_local 5
    i32.const 1
    i32.shr_s
    i32.add
    set_local 6
    get_local 0
    i32.load
    set_local 0
    block  ;; label = @1
      get_local 5
      i32.const 1
      i32.and
      i32.eqz
      br_if 0 (;@1;)
      get_local 6
      i32.load
      get_local 0
      i32.add
      i32.load
      set_local 0
    end
    get_local 6
    get_local 3
    get_local 2
    i32.const 48
    i32.add
    get_local 4
    call 77
    tee_local 5
    get_local 2
    i32.const 32
    i32.add
    get_local 1
    call 77
    tee_local 7
    get_local 0
    call_indirect (type 0)
    block  ;; label = @1
      block  ;; label = @2
        block  ;; label = @3
          block  ;; label = @4
            block  ;; label = @5
              block  ;; label = @6
                block  ;; label = @7
                  get_local 2
                  i32.load8_u offset=32
                  i32.const 1
                  i32.and
                  br_if 0 (;@7;)
                  get_local 2
                  i32.load8_u offset=48
                  i32.const 1
                  i32.and
                  br_if 1 (;@6;)
                  br 2 (;@5;)
                end
                get_local 7
                i32.load offset=8
                call 74
                get_local 2
                i32.load8_u offset=48
                i32.const 1
                i32.and
                i32.eqz
                br_if 1 (;@5;)
              end
              get_local 5
              i32.load offset=8
              call 74
              i32.const 1
              set_local 0
              get_local 1
              i32.load8_u
              i32.const 1
              i32.and
              i32.eqz
              br_if 1 (;@4;)
              br 2 (;@3;)
            end
            i32.const 1
            set_local 0
            get_local 1
            i32.load8_u
            i32.const 1
            i32.and
            br_if 1 (;@3;)
          end
          get_local 4
          i32.load8_u
          get_local 0
          i32.and
          br_if 1 (;@2;)
          br 2 (;@1;)
        end
        get_local 1
        i32.load offset=8
        call 74
        get_local 4
        i32.load8_u
        get_local 0
        i32.and
        i32.eqz
        br_if 1 (;@1;)
      end
      get_local 4
      i32.load offset=8
      call 74
      get_local 2
      i32.const 64
      i32.add
      set_global 0
      return
    end
    get_local 2
    i32.const 64
    i32.add
    set_global 0)
  (func (;58;) (type 3) (param i32 i32)
    (local i32 i32 i64 i32 i32)
    get_global 0
    i32.const 96
    i32.sub
    tee_local 2
    set_global 0
    get_local 2
    i32.const 32
    i32.add
    i32.const 8
    i32.add
    tee_local 3
    get_local 1
    i32.const 16
    i32.add
    i64.load
    i64.store
    get_local 2
    get_local 1
    i64.load offset=8
    i64.store offset=32
    get_local 1
    i64.load
    set_local 4
    get_local 2
    i32.const 16
    i32.add
    get_local 1
    i32.const 24
    i32.add
    call 77
    set_local 1
    get_local 2
    i32.const 48
    i32.add
    i32.const 8
    i32.add
    get_local 3
    i64.load
    i64.store
    get_local 2
    get_local 2
    i64.load offset=32
    i64.store offset=48
    get_local 0
    i32.load
    i32.load
    get_local 0
    i32.load offset=4
    tee_local 0
    i32.load offset=4
    tee_local 5
    i32.const 1
    i32.shr_s
    i32.add
    set_local 3
    get_local 0
    i32.load
    set_local 0
    block  ;; label = @1
      get_local 5
      i32.const 1
      i32.and
      i32.eqz
      br_if 0 (;@1;)
      get_local 3
      i32.load
      get_local 0
      i32.add
      i32.load
      set_local 0
    end
    get_local 2
    i32.const 80
    i32.add
    i32.const 8
    i32.add
    tee_local 6
    get_local 2
    i32.const 48
    i32.add
    i32.const 8
    i32.add
    i64.load
    i64.store
    get_local 2
    get_local 2
    i64.load offset=48
    i64.store offset=80
    get_local 2
    i32.const 64
    i32.add
    get_local 1
    call 77
    set_local 5
    get_local 2
    i32.const 8
    i32.add
    get_local 6
    i64.load
    i64.store
    get_local 2
    get_local 2
    i64.load offset=80
    i64.store
    get_local 3
    get_local 4
    get_local 2
    get_local 5
    get_local 0
    call_indirect (type 0)
    block  ;; label = @1
      block  ;; label = @2
        block  ;; label = @3
          get_local 2
          i32.load8_u offset=64
          i32.const 1
          i32.and
          br_if 0 (;@3;)
          get_local 1
          i32.load8_u
          i32.const 1
          i32.and
          br_if 1 (;@2;)
          br 2 (;@1;)
        end
        get_local 5
        i32.load offset=8
        call 74
        get_local 1
        i32.load8_u
        i32.const 1
        i32.and
        i32.eqz
        br_if 1 (;@1;)
      end
      get_local 1
      i32.load offset=8
      call 74
      get_local 2
      i32.const 96
      i32.add
      set_global 0
      return
    end
    get_local 2
    i32.const 96
    i32.add
    set_global 0)
  (func (;59;) (type 3) (param i32 i32)
    (local i32 i32)
    get_local 0
    i32.load
    set_local 2
    get_local 1
    i32.load
    tee_local 3
    i32.load offset=8
    get_local 3
    i32.load offset=4
    i32.sub
    i32.const 7
    i32.gt_u
    i32.const 8730
    call 0
    get_local 2
    get_local 3
    i32.load offset=4
    i32.const 8
    call 5
    drop
    get_local 3
    get_local 3
    i32.load offset=4
    i32.const 8
    i32.add
    i32.store offset=4
    get_local 0
    i32.load
    set_local 0
    get_local 1
    i32.load
    tee_local 3
    i32.load offset=8
    get_local 3
    i32.load offset=4
    i32.sub
    i32.const 7
    i32.gt_u
    i32.const 8730
    call 0
    get_local 0
    i32.const 8
    i32.add
    get_local 3
    i32.load offset=4
    i32.const 8
    call 5
    drop
    get_local 3
    get_local 3
    i32.load offset=4
    i32.const 8
    i32.add
    i32.store offset=4
    get_local 1
    i32.load
    tee_local 3
    i32.load offset=8
    get_local 3
    i32.load offset=4
    i32.sub
    i32.const 7
    i32.gt_u
    i32.const 8730
    call 0
    get_local 0
    i32.const 16
    i32.add
    get_local 3
    i32.load offset=4
    i32.const 8
    call 5
    drop
    get_local 3
    get_local 3
    i32.load offset=4
    i32.const 8
    i32.add
    tee_local 2
    i32.store offset=4
    get_local 3
    i32.load offset=8
    get_local 2
    i32.sub
    i32.const 7
    i32.gt_u
    i32.const 8730
    call 0
    get_local 0
    i32.const 24
    i32.add
    get_local 3
    i32.load offset=4
    i32.const 8
    call 5
    drop
    get_local 3
    get_local 3
    i32.load offset=4
    i32.const 8
    i32.add
    i32.store offset=4
    get_local 1
    i32.load
    get_local 0
    i32.const 32
    i32.add
    call 56
    drop)
  (func (;60;) (type 3) (param i32 i32)
    (local i32 i32 i64 i64 i32 i32)
    get_global 0
    i32.const 96
    i32.sub
    tee_local 2
    set_global 0
    get_local 2
    i32.const 32
    i32.add
    i32.const 8
    i32.add
    tee_local 3
    get_local 1
    i32.const 24
    i32.add
    i64.load
    i64.store
    get_local 2
    get_local 1
    i64.load offset=16
    i64.store offset=32
    get_local 1
    i64.load offset=8
    set_local 4
    get_local 1
    i64.load
    set_local 5
    get_local 2
    i32.const 16
    i32.add
    get_local 1
    i32.const 32
    i32.add
    call 77
    set_local 1
    get_local 2
    i32.const 48
    i32.add
    i32.const 8
    i32.add
    get_local 3
    i64.load
    i64.store
    get_local 2
    get_local 2
    i64.load offset=32
    i64.store offset=48
    get_local 0
    i32.load
    i32.load
    get_local 0
    i32.load offset=4
    tee_local 0
    i32.load offset=4
    tee_local 6
    i32.const 1
    i32.shr_s
    i32.add
    set_local 3
    get_local 0
    i32.load
    set_local 0
    block  ;; label = @1
      get_local 6
      i32.const 1
      i32.and
      i32.eqz
      br_if 0 (;@1;)
      get_local 3
      i32.load
      get_local 0
      i32.add
      i32.load
      set_local 0
    end
    get_local 2
    i32.const 80
    i32.add
    i32.const 8
    i32.add
    tee_local 7
    get_local 2
    i32.const 48
    i32.add
    i32.const 8
    i32.add
    i64.load
    i64.store
    get_local 2
    get_local 2
    i64.load offset=48
    i64.store offset=80
    get_local 2
    i32.const 64
    i32.add
    get_local 1
    call 77
    set_local 6
    get_local 2
    i32.const 8
    i32.add
    get_local 7
    i64.load
    i64.store
    get_local 2
    get_local 2
    i64.load offset=80
    i64.store
    get_local 3
    get_local 5
    get_local 4
    get_local 2
    get_local 6
    get_local 0
    call_indirect (type 1)
    block  ;; label = @1
      block  ;; label = @2
        block  ;; label = @3
          get_local 2
          i32.load8_u offset=64
          i32.const 1
          i32.and
          br_if 0 (;@3;)
          get_local 1
          i32.load8_u
          i32.const 1
          i32.and
          br_if 1 (;@2;)
          br 2 (;@1;)
        end
        get_local 6
        i32.load offset=8
        call 74
        get_local 1
        i32.load8_u
        i32.const 1
        i32.and
        i32.eqz
        br_if 1 (;@1;)
      end
      get_local 1
      i32.load offset=8
      call 74
      get_local 2
      i32.const 96
      i32.add
      set_global 0
      return
    end
    get_local 2
    i32.const 96
    i32.add
    set_global 0)
  (func (;61;) (type 25) (param i32) (result i32)
    (local i64 i32 i64 i32 i32 i32)
    get_local 0
    i64.const 1398362884
    i64.store offset=8
    get_local 0
    i64.const 0
    i64.store
    i32.const 1
    i32.const 8607
    call 0
    get_local 0
    i64.load offset=8
    i64.const 8
    i64.shr_u
    set_local 1
    i32.const 0
    set_local 2
    block  ;; label = @1
      block  ;; label = @2
        loop  ;; label = @3
          get_local 1
          i32.wrap/i64
          i32.const 24
          i32.shl
          i32.const -1073741825
          i32.add
          i32.const 452984830
          i32.gt_u
          br_if 1 (;@2;)
          get_local 1
          i64.const 8
          i64.shr_u
          set_local 3
          block  ;; label = @4
            get_local 1
            i64.const 65280
            i64.and
            i64.const 0
            i64.eq
            br_if 0 (;@4;)
            get_local 3
            set_local 1
            i32.const 1
            set_local 4
            get_local 2
            tee_local 5
            i32.const 1
            i32.add
            set_local 2
            get_local 5
            i32.const 6
            i32.lt_s
            br_if 1 (;@3;)
            br 3 (;@1;)
          end
          get_local 3
          set_local 1
          loop  ;; label = @4
            get_local 1
            i64.const 65280
            i64.and
            i64.const 0
            i64.ne
            br_if 2 (;@2;)
            get_local 1
            i64.const 8
            i64.shr_u
            set_local 1
            get_local 2
            i32.const 6
            i32.lt_s
            set_local 4
            get_local 2
            i32.const 1
            i32.add
            tee_local 5
            set_local 2
            get_local 4
            br_if 0 (;@4;)
          end
          i32.const 1
          set_local 4
          get_local 5
          i32.const 1
          i32.add
          set_local 2
          get_local 5
          i32.const 6
          i32.lt_s
          br_if 0 (;@3;)
          br 2 (;@1;)
        end
      end
      i32.const 0
      set_local 4
    end
    get_local 4
    i32.const 8192
    call 0
    get_local 0
    i32.const 24
    i32.add
    tee_local 2
    i64.const 1398362884
    i64.store
    get_local 0
    i64.const 0
    i64.store offset=16
    i32.const 1
    i32.const 8607
    call 0
    get_local 2
    i64.load
    i64.const 8
    i64.shr_u
    set_local 1
    i32.const 0
    set_local 2
    block  ;; label = @1
      block  ;; label = @2
        loop  ;; label = @3
          get_local 1
          i32.wrap/i64
          i32.const 24
          i32.shl
          i32.const -1073741825
          i32.add
          i32.const 452984830
          i32.gt_u
          br_if 2 (;@1;)
          block  ;; label = @4
            get_local 1
            i64.const 8
            i64.shr_u
            set_local 3
            block  ;; label = @5
              get_local 1
              i64.const 65280
              i64.and
              i64.const 0
              i64.eq
              br_if 0 (;@5;)
              get_local 3
              set_local 1
              i32.const 1
              set_local 6
              get_local 2
              tee_local 4
              i32.const 1
              i32.add
              set_local 2
              get_local 4
              i32.const 6
              i32.lt_s
              br_if 2 (;@3;)
              br 1 (;@4;)
            end
            get_local 3
            set_local 1
            loop  ;; label = @5
              get_local 1
              i64.const 65280
              i64.and
              i64.const 0
              i64.ne
              br_if 3 (;@2;)
              get_local 1
              i64.const 8
              i64.shr_u
              set_local 1
              get_local 2
              i32.const 6
              i32.lt_s
              set_local 4
              get_local 2
              i32.const 1
              i32.add
              tee_local 5
              set_local 2
              get_local 4
              br_if 0 (;@5;)
            end
            i32.const 1
            set_local 6
            get_local 5
            i32.const 1
            i32.add
            set_local 2
            get_local 5
            i32.const 6
            i32.lt_s
            br_if 1 (;@3;)
          end
        end
        get_local 6
        i32.const 8192
        call 0
        get_local 0
        return
      end
      i32.const 0
      i32.const 8192
      call 0
      get_local 0
      return
    end
    i32.const 0
    i32.const 8192
    call 0
    get_local 0)
  (func (;62;) (type 3) (param i32 i32)
    (local i32 i32 i32)
    get_local 0
    i32.load
    set_local 2
    get_local 1
    i32.load
    tee_local 3
    i32.load offset=8
    get_local 3
    i32.load offset=4
    i32.sub
    i32.const 7
    i32.gt_u
    i32.const 8730
    call 0
    get_local 2
    get_local 3
    i32.load offset=4
    i32.const 8
    call 5
    drop
    get_local 3
    get_local 3
    i32.load offset=4
    i32.const 8
    i32.add
    tee_local 4
    i32.store offset=4
    get_local 3
    i32.load offset=8
    get_local 4
    i32.sub
    i32.const 7
    i32.gt_u
    i32.const 8730
    call 0
    get_local 2
    i32.const 8
    i32.add
    get_local 3
    i32.load offset=4
    i32.const 8
    call 5
    drop
    get_local 3
    get_local 3
    i32.load offset=4
    i32.const 8
    i32.add
    i32.store offset=4
    get_local 0
    i32.load offset=4
    set_local 2
    get_local 1
    i32.load
    tee_local 3
    i32.load offset=8
    get_local 3
    i32.load offset=4
    i32.sub
    i32.const 7
    i32.gt_u
    i32.const 8730
    call 0
    get_local 2
    get_local 3
    i32.load offset=4
    i32.const 8
    call 5
    drop
    get_local 3
    get_local 3
    i32.load offset=4
    i32.const 8
    i32.add
    tee_local 4
    i32.store offset=4
    get_local 3
    i32.load offset=8
    get_local 4
    i32.sub
    i32.const 7
    i32.gt_u
    i32.const 8730
    call 0
    get_local 2
    i32.const 8
    i32.add
    get_local 3
    i32.load offset=4
    i32.const 8
    call 5
    drop
    get_local 3
    get_local 3
    i32.load offset=4
    i32.const 8
    i32.add
    i32.store offset=4
    get_local 0
    i32.load offset=8
    set_local 0
    get_local 1
    i32.load
    tee_local 3
    i32.load offset=8
    get_local 3
    i32.load offset=4
    i32.sub
    i32.const 7
    i32.gt_u
    i32.const 8730
    call 0
    get_local 0
    get_local 3
    i32.load offset=4
    i32.const 8
    call 5
    drop
    get_local 3
    get_local 3
    i32.load offset=4
    i32.const 8
    i32.add
    i32.store offset=4)
  (func (;63;) (type 21) (param i32 i32 i32 i32)
    (local i32 i32 i32 i32 i32)
    block  ;; label = @1
      block  ;; label = @2
        get_local 0
        i32.load offset=4
        get_local 0
        i32.load
        tee_local 4
        i32.sub
        i32.const 24
        i32.div_s
        tee_local 5
        i32.const 1
        i32.add
        tee_local 6
        i32.const 178956971
        i32.ge_u
        br_if 0 (;@2;)
        i32.const 178956970
        set_local 7
        block  ;; label = @3
          block  ;; label = @4
            get_local 0
            i32.load offset=8
            get_local 4
            i32.sub
            i32.const 24
            i32.div_s
            tee_local 4
            i32.const 89478484
            i32.gt_u
            br_if 0 (;@4;)
            get_local 6
            get_local 4
            i32.const 1
            i32.shl
            tee_local 7
            get_local 7
            get_local 6
            i32.lt_u
            select
            tee_local 7
            i32.eqz
            br_if 1 (;@3;)
          end
          get_local 7
          i32.const 24
          i32.mul
          call 72
          set_local 4
          br 2 (;@1;)
        end
        i32.const 0
        set_local 7
        i32.const 0
        set_local 4
        br 1 (;@1;)
      end
      get_local 0
      call 81
      unreachable
    end
    get_local 1
    i32.load
    set_local 6
    get_local 1
    i32.const 0
    i32.store
    get_local 4
    get_local 5
    i32.const 24
    i32.mul
    tee_local 8
    i32.add
    tee_local 1
    get_local 6
    i32.store
    get_local 1
    get_local 2
    i64.load
    i64.store offset=8
    get_local 1
    get_local 3
    i32.load
    i32.store offset=16
    get_local 4
    get_local 7
    i32.const 24
    i32.mul
    i32.add
    set_local 5
    get_local 1
    i32.const 24
    i32.add
    set_local 6
    block  ;; label = @1
      block  ;; label = @2
        get_local 0
        i32.const 4
        i32.add
        i32.load
        tee_local 2
        get_local 0
        i32.load
        tee_local 7
        i32.eq
        br_if 0 (;@2;)
        get_local 4
        get_local 8
        i32.add
        i32.const -24
        i32.add
        set_local 1
        loop  ;; label = @3
          get_local 2
          i32.const -24
          i32.add
          tee_local 4
          i32.load
          set_local 3
          get_local 4
          i32.const 0
          i32.store
          get_local 1
          get_local 3
          i32.store
          get_local 1
          i32.const 16
          i32.add
          get_local 2
          i32.const -8
          i32.add
          i32.load
          i32.store
          get_local 1
          i32.const 8
          i32.add
          get_local 2
          i32.const -16
          i32.add
          i64.load
          i64.store
          get_local 1
          i32.const -24
          i32.add
          set_local 1
          get_local 4
          set_local 2
          get_local 7
          get_local 4
          i32.ne
          br_if 0 (;@3;)
        end
        get_local 1
        i32.const 24
        i32.add
        set_local 1
        get_local 0
        i32.const 4
        i32.add
        i32.load
        set_local 7
        get_local 0
        i32.load
        set_local 2
        br 1 (;@1;)
      end
      get_local 7
      set_local 2
    end
    get_local 0
    get_local 1
    i32.store
    get_local 0
    i32.const 4
    i32.add
    get_local 6
    i32.store
    get_local 0
    i32.const 8
    i32.add
    get_local 5
    i32.store
    block  ;; label = @1
      get_local 7
      get_local 2
      i32.eq
      br_if 0 (;@1;)
      loop  ;; label = @2
        get_local 7
        i32.const -24
        i32.add
        tee_local 7
        i32.load
        set_local 1
        get_local 7
        i32.const 0
        i32.store
        block  ;; label = @3
          get_local 1
          i32.eqz
          br_if 0 (;@3;)
          get_local 1
          call 74
        end
        get_local 2
        get_local 7
        i32.ne
        br_if 0 (;@2;)
      end
    end
    block  ;; label = @1
      get_local 2
      i32.eqz
      br_if 0 (;@1;)
      get_local 2
      call 74
    end)
  (func (;64;) (type 3) (param i32 i32)
    (local i32 i32 i32 i32 i32 i32)
    block  ;; label = @1
      block  ;; label = @2
        block  ;; label = @3
          block  ;; label = @4
            block  ;; label = @5
              get_local 0
              i32.load offset=8
              tee_local 2
              get_local 0
              i32.load offset=4
              tee_local 3
              i32.sub
              get_local 1
              i32.ge_u
              br_if 0 (;@5;)
              get_local 3
              get_local 0
              i32.load
              tee_local 4
              i32.sub
              tee_local 5
              get_local 1
              i32.add
              tee_local 6
              i32.const -1
              i32.le_s
              br_if 2 (;@3;)
              i32.const 2147483647
              set_local 7
              block  ;; label = @6
                get_local 2
                get_local 4
                i32.sub
                tee_local 2
                i32.const 1073741822
                i32.gt_u
                br_if 0 (;@6;)
                get_local 6
                get_local 2
                i32.const 1
                i32.shl
                tee_local 2
                get_local 2
                get_local 6
                i32.lt_u
                select
                tee_local 7
                i32.eqz
                br_if 2 (;@4;)
              end
              get_local 7
              call 72
              set_local 2
              br 3 (;@2;)
            end
            get_local 0
            i32.const 4
            i32.add
            set_local 0
            loop  ;; label = @5
              get_local 3
              i32.const 0
              i32.store8
              get_local 0
              get_local 0
              i32.load
              i32.const 1
              i32.add
              tee_local 3
              i32.store
              get_local 1
              i32.const -1
              i32.add
              tee_local 1
              br_if 0 (;@5;)
              br 4 (;@1;)
            end
          end
          i32.const 0
          set_local 7
          i32.const 0
          set_local 2
          br 1 (;@2;)
        end
        get_local 0
        call 81
        unreachable
      end
      get_local 2
      get_local 7
      i32.add
      set_local 7
      get_local 3
      get_local 1
      i32.add
      get_local 4
      i32.sub
      set_local 4
      get_local 2
      get_local 5
      i32.add
      tee_local 5
      set_local 3
      loop  ;; label = @2
        get_local 3
        i32.const 0
        i32.store8
        get_local 3
        i32.const 1
        i32.add
        set_local 3
        get_local 1
        i32.const -1
        i32.add
        tee_local 1
        br_if 0 (;@2;)
      end
      get_local 2
      get_local 4
      i32.add
      set_local 4
      get_local 5
      get_local 0
      i32.const 4
      i32.add
      tee_local 6
      i32.load
      get_local 0
      i32.load
      tee_local 1
      i32.sub
      tee_local 3
      i32.sub
      set_local 2
      block  ;; label = @2
        get_local 3
        i32.const 1
        i32.lt_s
        br_if 0 (;@2;)
        get_local 2
        get_local 1
        get_local 3
        call 5
        drop
        get_local 0
        i32.load
        set_local 1
      end
      get_local 0
      get_local 2
      i32.store
      get_local 6
      get_local 4
      i32.store
      get_local 0
      i32.const 8
      i32.add
      get_local 7
      i32.store
      get_local 1
      i32.eqz
      br_if 0 (;@1;)
      get_local 1
      call 74
      return
    end)
  (func (;65;) (type 3) (param i32 i32)
    (local i32 i32)
    get_local 0
    i32.load
    set_local 2
    get_local 1
    i32.load
    tee_local 3
    i32.load offset=8
    get_local 3
    i32.load offset=4
    i32.sub
    i32.const 7
    i32.gt_s
    i32.const 8971
    call 0
    get_local 3
    i32.load offset=4
    get_local 2
    i32.const 8
    call 5
    drop
    get_local 3
    get_local 3
    i32.load offset=4
    i32.const 8
    i32.add
    i32.store offset=4
    get_local 0
    i32.load
    set_local 0
    get_local 1
    i32.load
    tee_local 3
    i32.load offset=8
    get_local 3
    i32.load offset=4
    i32.sub
    i32.const 7
    i32.gt_s
    i32.const 8971
    call 0
    get_local 3
    i32.load offset=4
    get_local 0
    i32.const 8
    i32.add
    i32.const 8
    call 5
    drop
    get_local 3
    get_local 3
    i32.load offset=4
    i32.const 8
    i32.add
    i32.store offset=4
    get_local 1
    i32.load
    tee_local 3
    i32.load offset=8
    get_local 3
    i32.load offset=4
    i32.sub
    i32.const 7
    i32.gt_s
    i32.const 8971
    call 0
    get_local 3
    i32.load offset=4
    get_local 0
    i32.const 16
    i32.add
    i32.const 8
    call 5
    drop
    get_local 3
    get_local 3
    i32.load offset=4
    i32.const 8
    i32.add
    tee_local 2
    i32.store offset=4
    get_local 3
    i32.load offset=8
    get_local 2
    i32.sub
    i32.const 7
    i32.gt_s
    i32.const 8971
    call 0
    get_local 3
    i32.load offset=4
    get_local 0
    i32.const 24
    i32.add
    i32.const 8
    call 5
    drop
    get_local 3
    get_local 3
    i32.load offset=4
    i32.const 8
    i32.add
    i32.store offset=4
    get_local 1
    i32.load
    get_local 0
    i32.const 32
    i32.add
    call 67
    drop)
  (func (;66;) (type 3) (param i32 i32)
    (local i32 i32 i32 i32 i32 i32 i64)
    get_global 0
    i32.const 16
    i32.sub
    tee_local 2
    set_global 0
    get_local 0
    i32.const 0
    i32.store offset=8
    get_local 0
    i64.const 0
    i64.store align=4
    i32.const 16
    set_local 3
    get_local 1
    i32.const 16
    i32.add
    set_local 4
    get_local 1
    i32.const 20
    i32.add
    i32.load
    tee_local 5
    get_local 1
    i32.load offset=16
    tee_local 6
    i32.sub
    tee_local 7
    i32.const 4
    i32.shr_s
    i64.extend_u/i32
    set_local 8
    loop  ;; label = @1
      get_local 3
      i32.const 1
      i32.add
      set_local 3
      get_local 8
      i64.const 7
      i64.shr_u
      tee_local 8
      i64.const 0
      i64.ne
      br_if 0 (;@1;)
    end
    block  ;; label = @1
      get_local 6
      get_local 5
      i32.eq
      br_if 0 (;@1;)
      get_local 7
      i32.const -16
      i32.and
      get_local 3
      i32.add
      set_local 3
    end
    get_local 1
    i32.load offset=28
    tee_local 5
    get_local 3
    i32.sub
    get_local 1
    i32.const 32
    i32.add
    i32.load
    tee_local 6
    i32.sub
    set_local 3
    get_local 1
    i32.const 28
    i32.add
    set_local 7
    get_local 6
    get_local 5
    i32.sub
    i64.extend_u/i32
    set_local 8
    loop  ;; label = @1
      get_local 3
      i32.const -1
      i32.add
      set_local 3
      get_local 8
      i64.const 7
      i64.shr_u
      tee_local 8
      i64.const 0
      i64.ne
      br_if 0 (;@1;)
    end
    i32.const 0
    set_local 5
    block  ;; label = @1
      block  ;; label = @2
        get_local 3
        i32.eqz
        br_if 0 (;@2;)
        get_local 0
        i32.const 0
        get_local 3
        i32.sub
        call 64
        get_local 0
        i32.const 4
        i32.add
        i32.load
        set_local 5
        get_local 0
        i32.load
        set_local 3
        br 1 (;@1;)
      end
      i32.const 0
      set_local 3
    end
    get_local 2
    get_local 3
    i32.store
    get_local 2
    get_local 5
    i32.store offset=8
    get_local 5
    get_local 3
    i32.sub
    tee_local 0
    i32.const 7
    i32.gt_s
    i32.const 8971
    call 0
    get_local 3
    get_local 1
    i32.const 8
    call 5
    drop
    get_local 0
    i32.const -8
    i32.add
    i32.const 7
    i32.gt_s
    i32.const 8971
    call 0
    get_local 3
    i32.const 8
    i32.add
    get_local 1
    i32.const 8
    i32.add
    i32.const 8
    call 5
    drop
    get_local 2
    get_local 3
    i32.const 16
    i32.add
    i32.store offset=4
    get_local 2
    get_local 4
    call 68
    get_local 7
    call 69
    drop
    get_local 2
    i32.const 16
    i32.add
    set_global 0)
  (func (;67;) (type 12) (param i32 i32) (result i32)
    (local i32 i32 i64 i32 i32 i32 i32)
    get_global 0
    i32.const 16
    i32.sub
    tee_local 2
    set_global 0
    get_local 1
    i32.load offset=4
    get_local 1
    i32.load8_u
    tee_local 3
    i32.const 1
    i32.shr_u
    get_local 3
    i32.const 1
    i32.and
    select
    i64.extend_u/i32
    set_local 4
    get_local 0
    i32.load offset=4
    set_local 5
    get_local 0
    i32.const 8
    i32.add
    set_local 6
    get_local 0
    i32.const 4
    i32.add
    set_local 3
    loop  ;; label = @1
      get_local 4
      i32.wrap/i64
      set_local 7
      get_local 2
      get_local 4
      i64.const 7
      i64.shr_u
      tee_local 4
      i64.const 0
      i64.ne
      tee_local 8
      i32.const 7
      i32.shl
      get_local 7
      i32.const 127
      i32.and
      i32.or
      i32.store8 offset=15
      get_local 6
      i32.load
      get_local 5
      i32.sub
      i32.const 0
      i32.gt_s
      i32.const 8971
      call 0
      get_local 3
      i32.load
      get_local 2
      i32.const 15
      i32.add
      i32.const 1
      call 5
      drop
      get_local 3
      get_local 3
      i32.load
      i32.const 1
      i32.add
      tee_local 5
      i32.store
      get_local 8
      br_if 0 (;@1;)
    end
    block  ;; label = @1
      get_local 1
      i32.const 4
      i32.add
      i32.load
      get_local 1
      i32.load8_u
      tee_local 3
      i32.const 1
      i32.shr_u
      get_local 3
      i32.const 1
      i32.and
      tee_local 7
      select
      tee_local 3
      i32.eqz
      br_if 0 (;@1;)
      get_local 1
      i32.load offset=8
      set_local 8
      get_local 0
      i32.const 8
      i32.add
      i32.load
      get_local 5
      i32.sub
      get_local 3
      i32.ge_s
      i32.const 8971
      call 0
      get_local 0
      i32.const 4
      i32.add
      tee_local 5
      i32.load
      get_local 8
      get_local 1
      i32.const 1
      i32.add
      get_local 7
      select
      get_local 3
      call 5
      drop
      get_local 5
      get_local 5
      i32.load
      get_local 3
      i32.add
      i32.store
    end
    get_local 2
    i32.const 16
    i32.add
    set_global 0
    get_local 0)
  (func (;68;) (type 12) (param i32 i32) (result i32)
    (local i32 i64 i32 i32 i32 i32)
    get_global 0
    i32.const 16
    i32.sub
    tee_local 2
    set_global 0
    get_local 1
    i32.load offset=4
    get_local 1
    i32.load
    i32.sub
    i32.const 4
    i32.shr_s
    i64.extend_u/i32
    set_local 3
    get_local 0
    i32.load offset=4
    set_local 4
    get_local 0
    i32.const 8
    i32.add
    set_local 5
    loop  ;; label = @1
      get_local 3
      i32.wrap/i64
      set_local 6
      get_local 2
      get_local 3
      i64.const 7
      i64.shr_u
      tee_local 3
      i64.const 0
      i64.ne
      tee_local 7
      i32.const 7
      i32.shl
      get_local 6
      i32.const 127
      i32.and
      i32.or
      i32.store8 offset=15
      get_local 5
      i32.load
      get_local 4
      i32.sub
      i32.const 0
      i32.gt_s
      i32.const 8971
      call 0
      get_local 0
      i32.const 4
      i32.add
      tee_local 6
      i32.load
      get_local 2
      i32.const 15
      i32.add
      i32.const 1
      call 5
      drop
      get_local 6
      get_local 6
      i32.load
      i32.const 1
      i32.add
      tee_local 4
      i32.store
      get_local 7
      br_if 0 (;@1;)
    end
    block  ;; label = @1
      get_local 1
      i32.load
      tee_local 7
      get_local 1
      i32.const 4
      i32.add
      i32.load
      tee_local 1
      i32.eq
      br_if 0 (;@1;)
      get_local 0
      i32.const 4
      i32.add
      set_local 6
      loop  ;; label = @2
        get_local 0
        i32.const 8
        i32.add
        tee_local 5
        i32.load
        get_local 4
        i32.sub
        i32.const 7
        i32.gt_s
        i32.const 8971
        call 0
        get_local 6
        i32.load
        get_local 7
        i32.const 8
        call 5
        drop
        get_local 6
        get_local 6
        i32.load
        i32.const 8
        i32.add
        tee_local 4
        i32.store
        get_local 5
        i32.load
        get_local 4
        i32.sub
        i32.const 7
        i32.gt_s
        i32.const 8971
        call 0
        get_local 6
        i32.load
        get_local 7
        i32.const 8
        i32.add
        i32.const 8
        call 5
        drop
        get_local 6
        get_local 6
        i32.load
        i32.const 8
        i32.add
        tee_local 4
        i32.store
        get_local 7
        i32.const 16
        i32.add
        tee_local 7
        get_local 1
        i32.ne
        br_if 0 (;@2;)
      end
    end
    get_local 2
    i32.const 16
    i32.add
    set_global 0
    get_local 0)
  (func (;69;) (type 12) (param i32 i32) (result i32)
    (local i32 i64 i32 i32 i32 i32 i32)
    get_global 0
    i32.const 16
    i32.sub
    tee_local 2
    set_global 0
    get_local 1
    i32.load offset=4
    get_local 1
    i32.load
    i32.sub
    i64.extend_u/i32
    set_local 3
    get_local 0
    i32.load offset=4
    set_local 4
    get_local 0
    i32.const 8
    i32.add
    set_local 5
    get_local 0
    i32.const 4
    i32.add
    set_local 6
    loop  ;; label = @1
      get_local 3
      i32.wrap/i64
      set_local 7
      get_local 2
      get_local 3
      i64.const 7
      i64.shr_u
      tee_local 3
      i64.const 0
      i64.ne
      tee_local 8
      i32.const 7
      i32.shl
      get_local 7
      i32.const 127
      i32.and
      i32.or
      i32.store8 offset=15
      get_local 5
      i32.load
      get_local 4
      i32.sub
      i32.const 0
      i32.gt_s
      i32.const 8971
      call 0
      get_local 6
      i32.load
      get_local 2
      i32.const 15
      i32.add
      i32.const 1
      call 5
      drop
      get_local 6
      get_local 6
      i32.load
      i32.const 1
      i32.add
      tee_local 4
      i32.store
      get_local 8
      br_if 0 (;@1;)
    end
    get_local 0
    i32.const 8
    i32.add
    i32.load
    get_local 4
    i32.sub
    get_local 1
    i32.const 4
    i32.add
    i32.load
    get_local 1
    i32.load
    tee_local 7
    i32.sub
    tee_local 6
    i32.ge_s
    i32.const 8971
    call 0
    get_local 0
    i32.const 4
    i32.add
    tee_local 4
    i32.load
    get_local 7
    get_local 6
    call 5
    drop
    get_local 4
    get_local 4
    i32.load
    get_local 6
    i32.add
    i32.store
    get_local 2
    i32.const 16
    i32.add
    set_global 0
    get_local 0)
  (func (;70;) (type 7) (param i32 i32 i32) (result i32)
    (local i64 i32 i64 i32 i32)
    get_local 0
    i64.const 1398362884
    i64.store offset=8
    get_local 0
    i64.const 0
    i64.store
    i32.const 1
    i32.const 8607
    call 0
    get_local 0
    i64.load offset=8
    i64.const 8
    i64.shr_u
    set_local 3
    i32.const 0
    set_local 4
    block  ;; label = @1
      block  ;; label = @2
        loop  ;; label = @3
          get_local 3
          i32.wrap/i64
          i32.const 24
          i32.shl
          i32.const -1073741825
          i32.add
          i32.const 452984830
          i32.gt_u
          br_if 1 (;@2;)
          get_local 3
          i64.const 8
          i64.shr_u
          set_local 5
          block  ;; label = @4
            get_local 3
            i64.const 65280
            i64.and
            i64.const 0
            i64.eq
            br_if 0 (;@4;)
            get_local 5
            set_local 3
            i32.const 1
            set_local 6
            get_local 4
            tee_local 7
            i32.const 1
            i32.add
            set_local 4
            get_local 7
            i32.const 6
            i32.lt_s
            br_if 1 (;@3;)
            br 3 (;@1;)
          end
          get_local 5
          set_local 3
          loop  ;; label = @4
            get_local 3
            i64.const 65280
            i64.and
            i64.const 0
            i64.ne
            br_if 2 (;@2;)
            get_local 3
            i64.const 8
            i64.shr_u
            set_local 3
            get_local 4
            i32.const 6
            i32.lt_s
            set_local 6
            get_local 4
            i32.const 1
            i32.add
            tee_local 7
            set_local 4
            get_local 6
            br_if 0 (;@4;)
          end
          i32.const 1
          set_local 6
          get_local 7
          i32.const 1
          i32.add
          set_local 4
          get_local 7
          i32.const 6
          i32.lt_s
          br_if 0 (;@3;)
          br 2 (;@1;)
        end
      end
      i32.const 0
      set_local 6
    end
    get_local 6
    i32.const 8192
    call 0
    get_local 0
    get_local 1
    i32.store offset=16
    get_local 2
    i32.load offset=4
    tee_local 4
    i32.load offset=8
    get_local 4
    i32.load offset=4
    i32.sub
    i32.const 7
    i32.gt_u
    i32.const 8730
    call 0
    get_local 0
    get_local 4
    i32.load offset=4
    i32.const 8
    call 5
    drop
    get_local 4
    get_local 4
    i32.load offset=4
    i32.const 8
    i32.add
    tee_local 6
    i32.store offset=4
    get_local 4
    i32.load offset=8
    get_local 6
    i32.sub
    i32.const 7
    i32.gt_u
    i32.const 8730
    call 0
    get_local 0
    i32.const 8
    i32.add
    get_local 4
    i32.load offset=4
    i32.const 8
    call 5
    drop
    get_local 4
    get_local 4
    i32.load offset=4
    i32.const 8
    i32.add
    i32.store offset=4
    get_local 0
    get_local 2
    i32.load offset=8
    i32.load
    i32.store offset=20
    get_local 0)
  (func (;71;) (type 12) (param i32 i32) (result i32)
    (local i32 i32 i64 i32 i32 i32)
    get_local 0
    i32.load offset=4
    set_local 2
    i32.const 0
    set_local 3
    i64.const 0
    set_local 4
    get_local 0
    i32.const 8
    i32.add
    set_local 5
    get_local 0
    i32.const 4
    i32.add
    set_local 6
    loop  ;; label = @1
      get_local 2
      get_local 5
      i32.load
      i32.lt_u
      i32.const 9302
      call 0
      get_local 6
      i32.load
      tee_local 2
      i32.load8_u
      set_local 7
      get_local 6
      get_local 2
      i32.const 1
      i32.add
      tee_local 2
      i32.store
      get_local 4
      get_local 7
      i32.const 127
      i32.and
      get_local 3
      i32.const 255
      i32.and
      tee_local 3
      i32.shl
      i64.extend_u/i32
      i64.or
      set_local 4
      get_local 3
      i32.const 7
      i32.add
      set_local 3
      get_local 7
      i32.const 128
      i32.and
      br_if 0 (;@1;)
    end
    block  ;; label = @1
      block  ;; label = @2
        get_local 1
        i32.load offset=4
        tee_local 3
        get_local 1
        i32.load
        tee_local 7
        i32.sub
        tee_local 5
        get_local 4
        i32.wrap/i64
        tee_local 6
        i32.ge_u
        br_if 0 (;@2;)
        get_local 1
        get_local 6
        get_local 5
        i32.sub
        call 64
        get_local 0
        i32.const 4
        i32.add
        i32.load
        set_local 2
        get_local 1
        i32.const 4
        i32.add
        i32.load
        set_local 3
        get_local 1
        i32.load
        set_local 7
        br 1 (;@1;)
      end
      get_local 5
      get_local 6
      i32.le_u
      br_if 0 (;@1;)
      get_local 1
      i32.const 4
      i32.add
      get_local 7
      get_local 6
      i32.add
      tee_local 3
      i32.store
    end
    get_local 0
    i32.const 8
    i32.add
    i32.load
    get_local 2
    i32.sub
    get_local 3
    get_local 7
    i32.sub
    tee_local 2
    i32.ge_u
    i32.const 8730
    call 0
    get_local 7
    get_local 0
    i32.const 4
    i32.add
    tee_local 3
    i32.load
    get_local 2
    call 5
    drop
    get_local 3
    get_local 3
    i32.load
    get_local 2
    i32.add
    i32.store
    get_local 0)
  (func (;72;) (type 25) (param i32) (result i32)
    (local i32 i32)
    block  ;; label = @1
      get_local 0
      i32.const 1
      get_local 0
      select
      tee_local 1
      call 83
      tee_local 0
      br_if 0 (;@1;)
      loop  ;; label = @2
        i32.const 0
        set_local 0
        i32.const 0
        i32.load offset=9308
        tee_local 2
        i32.eqz
        br_if 1 (;@1;)
        get_local 2
        call_indirect (type 2)
        get_local 1
        call 83
        tee_local 0
        i32.eqz
        br_if 0 (;@2;)
      end
    end
    get_local 0)
  (func (;73;) (type 25) (param i32) (result i32)
    get_local 0
    call 72)
  (func (;74;) (type 10) (param i32)
    block  ;; label = @1
      get_local 0
      i32.eqz
      br_if 0 (;@1;)
      get_local 0
      call 86
    end)
  (func (;75;) (type 10) (param i32)
    get_local 0
    call 74)
  (func (;76;) (type 10) (param i32)
    call 14
    unreachable)
  (func (;77;) (type 12) (param i32 i32) (result i32)
    (local i32 i32 i32)
    get_local 0
    i64.const 0
    i64.store align=4
    get_local 0
    i32.const 8
    i32.add
    tee_local 2
    i32.const 0
    i32.store
    block  ;; label = @1
      get_local 1
      i32.load8_u
      i32.const 1
      i32.and
      br_if 0 (;@1;)
      get_local 0
      get_local 1
      i64.load align=4
      i64.store align=4
      get_local 2
      get_local 1
      i32.const 8
      i32.add
      i32.load
      i32.store
      get_local 0
      return
    end
    block  ;; label = @1
      get_local 1
      i32.load offset=4
      tee_local 2
      i32.const -16
      i32.ge_u
      br_if 0 (;@1;)
      get_local 1
      i32.load offset=8
      set_local 3
      block  ;; label = @2
        block  ;; label = @3
          get_local 2
          i32.const 11
          i32.ge_u
          br_if 0 (;@3;)
          get_local 0
          get_local 2
          i32.const 1
          i32.shl
          i32.store8
          get_local 0
          i32.const 1
          i32.add
          set_local 1
          get_local 2
          br_if 1 (;@2;)
          get_local 1
          get_local 2
          i32.add
          i32.const 0
          i32.store8
          get_local 0
          return
        end
        get_local 2
        i32.const 16
        i32.add
        i32.const -16
        i32.and
        tee_local 4
        call 72
        set_local 1
        get_local 0
        get_local 4
        i32.const 1
        i32.or
        i32.store
        get_local 0
        get_local 1
        i32.store offset=8
        get_local 0
        get_local 2
        i32.store offset=4
      end
      get_local 1
      get_local 3
      get_local 2
      call 5
      drop
      get_local 1
      get_local 2
      i32.add
      i32.const 0
      i32.store8
      get_local 0
      return
    end
    call 14
    unreachable)
  (func (;78;) (type 12) (param i32 i32) (result i32)
    (local i32 i32 i32 i32 i32 i32)
    block  ;; label = @1
      block  ;; label = @2
        block  ;; label = @3
          block  ;; label = @4
            get_local 0
            get_local 1
            i32.eq
            br_if 0 (;@4;)
            get_local 1
            i32.load offset=4
            get_local 1
            i32.load8_u
            tee_local 2
            i32.const 1
            i32.shr_u
            get_local 2
            i32.const 1
            i32.and
            tee_local 3
            select
            set_local 2
            get_local 1
            i32.const 1
            i32.add
            set_local 4
            get_local 1
            i32.load offset=8
            set_local 5
            i32.const 10
            set_local 1
            block  ;; label = @5
              get_local 0
              i32.load8_u
              tee_local 6
              i32.const 1
              i32.and
              tee_local 7
              i32.eqz
              br_if 0 (;@5;)
              get_local 0
              i32.load
              i32.const -2
              i32.and
              i32.const -1
              i32.add
              set_local 1
            end
            get_local 5
            get_local 4
            get_local 3
            select
            set_local 3
            block  ;; label = @5
              block  ;; label = @6
                block  ;; label = @7
                  get_local 2
                  get_local 1
                  i32.le_u
                  br_if 0 (;@7;)
                  get_local 7
                  br_if 1 (;@6;)
                  get_local 6
                  i32.const 1
                  i32.shr_u
                  set_local 4
                  br 2 (;@5;)
                end
                get_local 7
                br_if 3 (;@3;)
                get_local 0
                i32.const 1
                i32.add
                set_local 1
                get_local 2
                br_if 4 (;@2;)
                br 5 (;@1;)
              end
              get_local 0
              i32.load offset=4
              set_local 4
            end
            get_local 0
            get_local 1
            get_local 2
            get_local 1
            i32.sub
            get_local 4
            i32.const 0
            get_local 4
            get_local 2
            get_local 3
            call 79
          end
          get_local 0
          return
        end
        get_local 0
        i32.load offset=8
        set_local 1
        get_local 2
        i32.eqz
        br_if 1 (;@1;)
      end
      get_local 1
      get_local 3
      get_local 2
      call 16
      drop
    end
    get_local 1
    get_local 2
    i32.add
    i32.const 0
    i32.store8
    block  ;; label = @1
      get_local 0
      i32.load8_u
      i32.const 1
      i32.and
      br_if 0 (;@1;)
      get_local 0
      get_local 2
      i32.const 1
      i32.shl
      i32.store8
      get_local 0
      return
    end
    get_local 0
    get_local 2
    i32.store offset=4
    get_local 0)
  (func (;79;) (type 26) (param i32 i32 i32 i32 i32 i32 i32 i32)
    (local i32 i32 i32)
    block  ;; label = @1
      i32.const -18
      get_local 1
      i32.sub
      get_local 2
      i32.lt_u
      br_if 0 (;@1;)
      block  ;; label = @2
        block  ;; label = @3
          block  ;; label = @4
            get_local 0
            i32.load8_u
            i32.const 1
            i32.and
            br_if 0 (;@4;)
            get_local 0
            i32.const 1
            i32.add
            set_local 8
            i32.const -17
            set_local 9
            get_local 1
            i32.const 2147483622
            i32.le_u
            br_if 1 (;@3;)
            br 2 (;@2;)
          end
          get_local 0
          i32.load offset=8
          set_local 8
          i32.const -17
          set_local 9
          get_local 1
          i32.const 2147483622
          i32.gt_u
          br_if 1 (;@2;)
        end
        i32.const 11
        set_local 9
        get_local 1
        i32.const 1
        i32.shl
        tee_local 10
        get_local 2
        get_local 1
        i32.add
        tee_local 2
        get_local 2
        get_local 10
        i32.lt_u
        select
        tee_local 2
        i32.const 11
        i32.lt_u
        br_if 0 (;@2;)
        get_local 2
        i32.const 16
        i32.add
        i32.const -16
        i32.and
        set_local 9
      end
      get_local 9
      call 72
      set_local 2
      block  ;; label = @2
        get_local 4
        i32.eqz
        br_if 0 (;@2;)
        get_local 2
        get_local 8
        get_local 4
        call 5
        drop
      end
      block  ;; label = @2
        get_local 6
        i32.eqz
        br_if 0 (;@2;)
        get_local 2
        get_local 4
        i32.add
        get_local 7
        get_local 6
        call 5
        drop
      end
      block  ;; label = @2
        get_local 3
        get_local 5
        i32.sub
        tee_local 3
        get_local 4
        i32.sub
        tee_local 7
        i32.eqz
        br_if 0 (;@2;)
        get_local 2
        get_local 4
        i32.add
        get_local 6
        i32.add
        get_local 8
        get_local 4
        i32.add
        get_local 5
        i32.add
        get_local 7
        call 5
        drop
      end
      block  ;; label = @2
        get_local 1
        i32.const 10
        i32.eq
        br_if 0 (;@2;)
        get_local 8
        call 74
      end
      get_local 0
      get_local 2
      i32.store offset=8
      get_local 0
      get_local 9
      i32.const 1
      i32.or
      i32.store
      get_local 0
      get_local 3
      get_local 6
      i32.add
      tee_local 4
      i32.store offset=4
      get_local 2
      get_local 4
      i32.add
      i32.const 0
      i32.store8
      return
    end
    call 14
    unreachable)
  (func (;80;) (type 3) (param i32 i32)
    (local i32 i32 i32 i32 i32 i32 i32)
    block  ;; label = @1
      block  ;; label = @2
        block  ;; label = @3
          block  ;; label = @4
            get_local 1
            i32.const -16
            i32.ge_u
            br_if 0 (;@4;)
            block  ;; label = @5
              block  ;; label = @6
                get_local 0
                i32.load8_u
                tee_local 2
                i32.const 1
                i32.and
                br_if 0 (;@6;)
                get_local 2
                i32.const 1
                i32.shr_u
                set_local 3
                i32.const 10
                set_local 4
                br 1 (;@5;)
              end
              get_local 0
              i32.load
              tee_local 2
              i32.const -2
              i32.and
              i32.const -1
              i32.add
              set_local 4
              get_local 0
              i32.load offset=4
              set_local 3
            end
            i32.const 10
            set_local 5
            block  ;; label = @5
              get_local 3
              get_local 1
              get_local 3
              get_local 1
              i32.gt_u
              select
              tee_local 1
              i32.const 11
              i32.lt_u
              br_if 0 (;@5;)
              get_local 1
              i32.const 16
              i32.add
              i32.const -16
              i32.and
              i32.const -1
              i32.add
              set_local 5
            end
            block  ;; label = @5
              block  ;; label = @6
                block  ;; label = @7
                  get_local 5
                  get_local 4
                  i32.eq
                  br_if 0 (;@7;)
                  block  ;; label = @8
                    get_local 5
                    i32.const 10
                    i32.ne
                    br_if 0 (;@8;)
                    i32.const 1
                    set_local 6
                    get_local 0
                    i32.const 1
                    i32.add
                    set_local 1
                    get_local 0
                    i32.load offset=8
                    set_local 4
                    i32.const 0
                    set_local 7
                    i32.const 1
                    set_local 8
                    get_local 2
                    i32.const 1
                    i32.and
                    br_if 3 (;@5;)
                    br 5 (;@3;)
                  end
                  get_local 5
                  i32.const 1
                  i32.add
                  call 72
                  set_local 1
                  get_local 5
                  get_local 4
                  i32.gt_u
                  br_if 1 (;@6;)
                  get_local 1
                  br_if 1 (;@6;)
                end
                return
              end
              block  ;; label = @6
                get_local 0
                i32.load8_u
                tee_local 2
                i32.const 1
                i32.and
                br_if 0 (;@6;)
                i32.const 1
                set_local 7
                get_local 0
                i32.const 1
                i32.add
                set_local 4
                i32.const 0
                set_local 6
                i32.const 1
                set_local 8
                get_local 2
                i32.const 1
                i32.and
                i32.eqz
                br_if 3 (;@3;)
                br 1 (;@5;)
              end
              get_local 0
              i32.load offset=8
              set_local 4
              i32.const 1
              set_local 6
              i32.const 1
              set_local 7
              i32.const 1
              set_local 8
              get_local 2
              i32.const 1
              i32.and
              i32.eqz
              br_if 2 (;@3;)
            end
            get_local 0
            i32.load offset=4
            i32.const 1
            i32.add
            tee_local 2
            i32.eqz
            br_if 3 (;@1;)
            br 2 (;@2;)
          end
          call 14
          unreachable
        end
        get_local 2
        i32.const 254
        i32.and
        get_local 8
        i32.shr_u
        i32.const 1
        i32.add
        tee_local 2
        i32.eqz
        br_if 1 (;@1;)
      end
      get_local 1
      get_local 4
      get_local 2
      call 5
      drop
    end
    block  ;; label = @1
      get_local 6
      i32.eqz
      br_if 0 (;@1;)
      get_local 4
      call 74
    end
    block  ;; label = @1
      get_local 7
      i32.eqz
      br_if 0 (;@1;)
      get_local 0
      get_local 3
      i32.store offset=4
      get_local 0
      get_local 1
      i32.store offset=8
      get_local 0
      get_local 5
      i32.const 1
      i32.add
      i32.const 1
      i32.or
      i32.store
      return
    end
    get_local 0
    get_local 3
    i32.const 1
    i32.shl
    i32.store8)
  (func (;81;) (type 10) (param i32)
    call 14
    unreachable)
  (func (;82;) (type 10) (param i32))
  (func (;83;) (type 25) (param i32) (result i32)
    i32.const 9320
    get_local 0
    call 84)
  (func (;84;) (type 12) (param i32 i32) (result i32)
    (local i32 i32 i32 i32 i32 i32 i32 i32 i32 i32 i32 i32)
    block  ;; label = @1
      get_local 1
      i32.eqz
      br_if 0 (;@1;)
      block  ;; label = @2
        get_local 0
        i32.load offset=8384
        tee_local 2
        br_if 0 (;@2;)
        i32.const 16
        set_local 2
        get_local 0
        i32.const 8384
        i32.add
        i32.const 16
        i32.store
      end
      get_local 1
      i32.const 8
      i32.add
      get_local 1
      i32.const 4
      i32.add
      i32.const 7
      i32.and
      tee_local 3
      i32.sub
      get_local 1
      get_local 3
      select
      set_local 3
      block  ;; label = @2
        block  ;; label = @3
          block  ;; label = @4
            get_local 0
            i32.load offset=8388
            tee_local 4
            get_local 2
            i32.ge_u
            br_if 0 (;@4;)
            get_local 0
            get_local 4
            i32.const 12
            i32.mul
            i32.add
            i32.const 8192
            i32.add
            set_local 1
            block  ;; label = @5
              get_local 4
              br_if 0 (;@5;)
              get_local 0
              i32.const 8196
              i32.add
              tee_local 2
              i32.load
              br_if 0 (;@5;)
              get_local 1
              i32.const 8192
              i32.store
              get_local 2
              get_local 0
              i32.store
            end
            get_local 3
            i32.const 4
            i32.add
            set_local 4
            loop  ;; label = @5
              block  ;; label = @6
                get_local 1
                i32.load offset=8
                tee_local 2
                get_local 4
                i32.add
                get_local 1
                i32.load
                i32.gt_u
                br_if 0 (;@6;)
                get_local 1
                i32.load offset=4
                get_local 2
                i32.add
                tee_local 2
                get_local 2
                i32.load
                i32.const -2147483648
                i32.and
                get_local 3
                i32.or
                i32.store
                get_local 1
                i32.const 8
                i32.add
                tee_local 1
                get_local 1
                i32.load
                get_local 4
                i32.add
                i32.store
                get_local 2
                get_local 2
                i32.load
                i32.const -2147483648
                i32.or
                i32.store
                get_local 2
                i32.const 4
                i32.add
                tee_local 1
                br_if 3 (;@3;)
              end
              get_local 0
              call 85
              tee_local 1
              br_if 0 (;@5;)
            end
          end
          i32.const 2147483644
          get_local 3
          i32.sub
          set_local 5
          get_local 0
          i32.const 8392
          i32.add
          set_local 6
          get_local 0
          i32.const 8384
          i32.add
          set_local 7
          get_local 0
          i32.load offset=8392
          tee_local 8
          set_local 2
          loop  ;; label = @4
            get_local 0
            get_local 2
            i32.const 12
            i32.mul
            i32.add
            tee_local 1
            i32.const 8200
            i32.add
            i32.load
            get_local 1
            i32.const 8192
            i32.add
            tee_local 9
            i32.load
            i32.eq
            i32.const 8227
            call 0
            get_local 1
            i32.const 8196
            i32.add
            i32.load
            tee_local 10
            i32.const 4
            i32.add
            set_local 2
            loop  ;; label = @5
              get_local 10
              get_local 9
              i32.load
              i32.add
              set_local 11
              get_local 2
              i32.const -4
              i32.add
              tee_local 12
              i32.load
              tee_local 13
              i32.const 2147483647
              i32.and
              set_local 1
              block  ;; label = @6
                get_local 13
                i32.const 0
                i32.lt_s
                br_if 0 (;@6;)
                block  ;; label = @7
                  get_local 1
                  get_local 3
                  i32.ge_u
                  br_if 0 (;@7;)
                  loop  ;; label = @8
                    get_local 2
                    get_local 1
                    i32.add
                    tee_local 4
                    get_local 11
                    i32.ge_u
                    br_if 1 (;@7;)
                    get_local 4
                    i32.load
                    tee_local 4
                    i32.const 0
                    i32.lt_s
                    br_if 1 (;@7;)
                    get_local 1
                    get_local 4
                    i32.const 2147483647
                    i32.and
                    i32.add
                    i32.const 4
                    i32.add
                    tee_local 1
                    get_local 3
                    i32.lt_u
                    br_if 0 (;@8;)
                  end
                end
                get_local 12
                get_local 1
                get_local 3
                get_local 1
                get_local 3
                i32.lt_u
                select
                get_local 13
                i32.const -2147483648
                i32.and
                i32.or
                i32.store
                block  ;; label = @7
                  get_local 1
                  get_local 3
                  i32.le_u
                  br_if 0 (;@7;)
                  get_local 2
                  get_local 3
                  i32.add
                  get_local 5
                  get_local 1
                  i32.add
                  i32.const 2147483647
                  i32.and
                  i32.store
                end
                get_local 1
                get_local 3
                i32.ge_u
                br_if 4 (;@2;)
              end
              get_local 2
              get_local 1
              i32.add
              i32.const 4
              i32.add
              tee_local 2
              get_local 11
              i32.lt_u
              br_if 0 (;@5;)
            end
            i32.const 0
            set_local 1
            get_local 6
            i32.const 0
            get_local 6
            i32.load
            i32.const 1
            i32.add
            tee_local 2
            get_local 2
            get_local 7
            i32.load
            i32.eq
            select
            tee_local 2
            i32.store
            get_local 2
            get_local 8
            i32.ne
            br_if 0 (;@4;)
          end
        end
        get_local 1
        return
      end
      get_local 12
      get_local 12
      i32.load
      i32.const -2147483648
      i32.or
      i32.store
      get_local 2
      return
    end
    i32.const 0)
  (func (;85;) (type 25) (param i32) (result i32)
    (local i32 i32 i32 i32 i32 i32 i32 i32)
    get_local 0
    i32.load offset=8388
    set_local 1
    block  ;; label = @1
      block  ;; label = @2
        i32.const 0
        i32.load8_u offset=9312
        i32.eqz
        br_if 0 (;@2;)
        i32.const 0
        i32.load offset=9316
        set_local 2
        br 1 (;@1;)
      end
      memory.size
      set_local 2
      i32.const 0
      i32.const 1
      i32.store8 offset=9312
      i32.const 0
      get_local 2
      i32.const 16
      i32.shl
      tee_local 2
      i32.store offset=9316
    end
    get_local 2
    set_local 3
    block  ;; label = @1
      block  ;; label = @2
        block  ;; label = @3
          block  ;; label = @4
            get_local 2
            i32.const 65535
            i32.add
            i32.const 16
            i32.shr_u
            tee_local 4
            memory.size
            tee_local 5
            i32.le_u
            br_if 0 (;@4;)
            get_local 4
            get_local 5
            i32.sub
            memory.grow
            drop
            i32.const 0
            set_local 5
            get_local 4
            memory.size
            i32.ne
            br_if 1 (;@3;)
            i32.const 0
            i32.load offset=9316
            set_local 3
          end
          i32.const 0
          set_local 5
          i32.const 0
          get_local 3
          i32.store offset=9316
          get_local 2
          i32.const 0
          i32.lt_s
          br_if 0 (;@3;)
          get_local 1
          i32.const 12
          i32.mul
          set_local 4
          block  ;; label = @4
            block  ;; label = @5
              get_local 2
              i32.const 65535
              i32.and
              tee_local 5
              i32.const 64512
              i32.gt_u
              br_if 0 (;@5;)
              get_local 2
              i32.const 65536
              i32.add
              get_local 5
              i32.sub
              set_local 5
              br 1 (;@4;)
            end
            get_local 2
            i32.const 131072
            i32.add
            get_local 2
            i32.const 131071
            i32.and
            i32.sub
            set_local 5
          end
          get_local 0
          get_local 4
          i32.add
          set_local 4
          get_local 5
          get_local 2
          i32.sub
          set_local 2
          block  ;; label = @4
            i32.const 0
            i32.load8_u offset=9312
            br_if 0 (;@4;)
            memory.size
            set_local 3
            i32.const 0
            i32.const 1
            i32.store8 offset=9312
            i32.const 0
            get_local 3
            i32.const 16
            i32.shl
            tee_local 3
            i32.store offset=9316
          end
          get_local 4
          i32.const 8192
          i32.add
          set_local 4
          get_local 2
          i32.const 0
          i32.lt_s
          br_if 1 (;@2;)
          get_local 3
          set_local 6
          block  ;; label = @4
            get_local 2
            i32.const 7
            i32.add
            i32.const -8
            i32.and
            tee_local 7
            get_local 3
            i32.add
            i32.const 65535
            i32.add
            i32.const 16
            i32.shr_u
            tee_local 5
            memory.size
            tee_local 8
            i32.le_u
            br_if 0 (;@4;)
            get_local 5
            get_local 8
            i32.sub
            memory.grow
            drop
            get_local 5
            memory.size
            i32.ne
            br_if 2 (;@2;)
            i32.const 0
            i32.load offset=9316
            set_local 6
          end
          i32.const 0
          get_local 6
          get_local 7
          i32.add
          i32.store offset=9316
          get_local 3
          i32.const -1
          i32.eq
          br_if 1 (;@2;)
          get_local 0
          get_local 1
          i32.const 12
          i32.mul
          i32.add
          tee_local 1
          i32.const 8196
          i32.add
          i32.load
          tee_local 6
          get_local 4
          i32.load
          tee_local 5
          i32.add
          get_local 3
          i32.eq
          br_if 2 (;@1;)
          block  ;; label = @4
            get_local 5
            get_local 1
            i32.const 8200
            i32.add
            tee_local 7
            i32.load
            tee_local 1
            i32.eq
            br_if 0 (;@4;)
            get_local 6
            get_local 1
            i32.add
            tee_local 6
            get_local 6
            i32.load
            i32.const -2147483648
            i32.and
            i32.const -4
            get_local 1
            i32.sub
            get_local 5
            i32.add
            i32.or
            i32.store
            get_local 7
            get_local 4
            i32.load
            i32.store
            get_local 6
            get_local 6
            i32.load
            i32.const 2147483647
            i32.and
            i32.store
          end
          get_local 0
          i32.const 8388
          i32.add
          tee_local 4
          get_local 4
          i32.load
          i32.const 1
          i32.add
          tee_local 4
          i32.store
          get_local 0
          get_local 4
          i32.const 12
          i32.mul
          i32.add
          tee_local 0
          i32.const 8192
          i32.add
          tee_local 5
          get_local 2
          i32.store
          get_local 0
          i32.const 8196
          i32.add
          get_local 3
          i32.store
        end
        get_local 5
        return
      end
      block  ;; label = @2
        get_local 4
        i32.load
        tee_local 5
        get_local 0
        get_local 1
        i32.const 12
        i32.mul
        i32.add
        tee_local 3
        i32.const 8200
        i32.add
        tee_local 1
        i32.load
        tee_local 2
        i32.eq
        br_if 0 (;@2;)
        get_local 3
        i32.const 8196
        i32.add
        i32.load
        get_local 2
        i32.add
        tee_local 3
        get_local 3
        i32.load
        i32.const -2147483648
        i32.and
        i32.const -4
        get_local 2
        i32.sub
        get_local 5
        i32.add
        i32.or
        i32.store
        get_local 1
        get_local 4
        i32.load
        i32.store
        get_local 3
        get_local 3
        i32.load
        i32.const 2147483647
        i32.and
        i32.store
      end
      get_local 0
      get_local 0
      i32.const 8388
      i32.add
      tee_local 2
      i32.load
      i32.const 1
      i32.add
      tee_local 3
      i32.store offset=8384
      get_local 2
      get_local 3
      i32.store
      i32.const 0
      return
    end
    get_local 4
    get_local 5
    get_local 2
    i32.add
    i32.store
    get_local 4)
  (func (;86;) (type 10) (param i32)
    (local i32 i32 i32)
    block  ;; label = @1
      block  ;; label = @2
        get_local 0
        i32.eqz
        br_if 0 (;@2;)
        i32.const 0
        i32.load offset=17704
        tee_local 1
        i32.const 1
        i32.lt_s
        br_if 0 (;@2;)
        i32.const 17512
        set_local 2
        get_local 1
        i32.const 12
        i32.mul
        i32.const 17512
        i32.add
        set_local 3
        loop  ;; label = @3
          get_local 2
          i32.const 4
          i32.add
          i32.load
          tee_local 1
          i32.eqz
          br_if 1 (;@2;)
          block  ;; label = @4
            get_local 1
            i32.const 4
            i32.add
            get_local 0
            i32.gt_u
            br_if 0 (;@4;)
            get_local 1
            get_local 2
            i32.load
            i32.add
            get_local 0
            i32.gt_u
            br_if 3 (;@1;)
          end
          get_local 2
          i32.const 12
          i32.add
          tee_local 2
          get_local 3
          i32.lt_u
          br_if 0 (;@3;)
        end
      end
      return
    end
    get_local 0
    i32.const -4
    i32.add
    tee_local 2
    get_local 2
    i32.load
    i32.const 2147483647
    i32.and
    i32.store)
  (table (;0;) 4 4 anyfunc)
  (memory (;0;) 1)
  (global (;0;) (mut i32) (i32.const 8192))
  (global (;1;) i32 (i32.const 17716))
  (global (;2;) i32 (i32.const 17716))
  (export "memory" (memory 0))
  (export "__heap_base" (global 1))
  (export "__data_end" (global 2))
  (export "apply" (func 52))
  (export "_Znwj" (func 72))
  (export "_ZdlPv" (func 74))
  (export "_Znaj" (func 73))
  (export "_ZdaPv" (func 75))
  (elem (i32.const 1) 49 44 37)
  (data (i32.const 8192) "invalid symbol name\00")
  (data (i32.const 8212) "memo too large\00malloc_from_freed was designed to only be called after _heap was completely allocated\00")
  (data (i32.const 8313) "symbol does not exist\00")
  (data (i32.const 8335) "invalid quantity\00")
  (data (i32.const 8352) "symbol precision mismatch\00")
  (data (i32.const 8378) "quantity exceeds available supply\00")
  (data (i32.const 8412) "not to self\00")
  (data (i32.const 8424) "to account invalid\00")
  (data (i32.const 8443) "unable to find key\00")
  (data (i32.const 8462) "quantity invalid\00")
  (data (i32.const 8479) "not positive quantity\00")
  (data (i32.const 8501) "no balance object found\00")
  (data (i32.const 8525) "overdrawn balance\00")
  (data (i32.const 8543) "onerror action's are only valid from the \22eosio\22 system account\00")
  (data (i32.const 8607) "magnitude of asset amount must be less than 2^62\00")
  (data (i32.const 8656) "object passed to iterator_to is not in multi_index\00")
  (data (i32.const 8707) "error reading iterator\00")
  (data (i32.const 8730) "read\00")
  (data (i32.const 8735) "object passed to modify is not in multi_index\00")
  (data (i32.const 8781) "cannot modify objects in table of another contract\00")
  (data (i32.const 8832) "updater cannot change primary key when modifying an object\00")
  (data (i32.const 8891) "attempt to add asset with different symbol\00")
  (data (i32.const 8934) "addition underflow\00")
  (data (i32.const 8953) "addition overflow\00")
  (data (i32.const 8971) "write\00")
  (data (i32.const 8977) "object passed to erase is not in multi_index\00")
  (data (i32.const 9022) "cannot erase objects in table of another contract\00")
  (data (i32.const 9072) "attempt to remove object that was not in multi_index\00")
  (data (i32.const 9125) "attempt to subtract asset with different symbol\00")
  (data (i32.const 9173) "subtraction underflow\00")
  (data (i32.const 9195) "subtraction overflow\00")
  (data (i32.const 9216) "cannot create objects in table of another contract\00")
  (data (i32.const 9267) "cannot pass end iterator to modify\00")
  (data (i32.const 9302) "get\00"))
